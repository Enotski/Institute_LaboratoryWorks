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
    /// Interaction logic for Reciept.xaml
    /// </summary>
    public partial class RecieptWindow : Window
    {
        public bool toEdit;
        public SideWorker.ServicesSwitcher serviceToUse;
        public ObservableCollection<Document> docList;
        public Reciept reciept = new Reciept();
        ObservableCollection<ModelProduct> pList;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcf wcfService = MainWindow.wcfService;
        public RecieptWindow()
        {
            InitializeComponent();
        }
        private void TextBoxBinding()
        {
            txtBoxDocId.Text = reciept.DocId;
            txtBoxDocDate.Text = reciept.DocDate.ToString();
            txtBoxDocProvider.Text = reciept.Provider;
            txtBoxDocClient.Text = reciept.Client;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            pList = new ObservableCollection<ModelProduct>(reciept.Products.Select(SideWorker.CastToModelProducts));
            dataGridProducts.ItemsSource = pList;
            TextBoxBinding();
            txtBoxDocPayment.Text = reciept.PaymentName;
        }

        private void ButtonDocAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SideWorker.ValidationForm(docConstructor.Children))
            {
                reciept.Products = pList.Select(SideWorker.CastToLibraryProducts).ToList();

                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocPayment.Text
                    };
                    // конвертируем список продуктов в подходящий тип
                    asmxService.SetDocumentRecieptAsync(docData, reciept.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
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
                        txtBoxDocPayment.Text
                    };
                    // конвертируем список продуктов в подходящий тип

                    wcfService.SetDocumentRecieptAsync(docData, reciept.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }
                reciept.SetDocId(txtBoxDocId.Text);
                reciept.SetDocDate(txtBoxDocDate.Text);
                reciept.SetParticipants(txtBoxDocProvider.Text, txtBoxDocClient.Text);
                reciept.SetPaymentName(txtBoxDocPayment.Text);
                reciept.SetProductList(pList.Select(SideWorker.CastToLibraryProducts).ToList());
                if (!toEdit)
                {
                    docList.Add(reciept);
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
            foreach (var p in pList)
            {
                sum += p.Sum;
            }
            txtBoxDocGoodsSum.Text = sum.ToString();
        }
    }
}
