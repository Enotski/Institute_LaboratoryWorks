using Laba_7.Controls;
using Laba_7.Models;
using OP_ClassLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laba_7.Views
{
    /// <summary>
    /// Interaction logic for BillWindow.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        public bool toEdit;
        public SideWorker.ServicesSwitcher serviceToUse;
        public BindingList<Document> docList;
        public Bill bill = new Bill();
        ObservableCollection<ModelProduct> pList;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcf wcfService = MainWindow.wcfService;
        public BillWindow()
        {
            InitializeComponent();
        }
        private void TextBoxBinding()
        {
            txtBoxDocId.Text = bill.DocId;
            txtBoxDocDate.Text = bill.DocDate.ToString();
            txtBoxDocProvider.Text = bill.Provider;
            txtBoxDocClient.Text = bill.Client;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            pList = new ObservableCollection<ModelProduct>(bill.Products.Select(SideWorker.CastToModelProducts));
            dataGridProducts.ItemsSource = pList;
            TextBoxBinding();
            txtBoxDocClientId.Text = bill.ClientId;
        }

        private void ButtonDocAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SideWorker.ValidationForm(docConstructor.Children))
            {
                bill.Products = pList.Select(SideWorker.CastToLibraryProducts).ToList();
                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип
                    asmxService.SetDocumentBillAsync(docData, bill.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип

                    wcfService.SetDocumentBillAsync(docData, bill.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }
                else if (!toEdit)
                {
                    bill = new Bill(
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocClientId.Text
                        );
                    docList.Add(bill);
                    bill.Products = pList.Select(SideWorker.CastToLibraryProducts).ToList();
                }
                    
                this.Close();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGridProducts_LostFocus(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            foreach(var p in pList)
            {
                sum += p.Sum;
            }
            txtBoxDocGoodsSum.Text = sum.ToString();
        }
    }
}
