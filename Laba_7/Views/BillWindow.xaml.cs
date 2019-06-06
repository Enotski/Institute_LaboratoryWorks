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
        public ObservableCollection<Document> docList;
        public Bill bill = new Bill();
        ObservableCollection<ModelProduct> pList;
        public DataGrid mainWinGrid;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcfClient wcfService = MainWindow.wcfClient;
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

        private async void ButtonDocAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SideWorker.ValidationForm(docConstructor.Children))
            {
                string[] docData = new string[]
                {
                    txtBoxDocId.Text,
                    txtBoxDocDate.Text,
                    txtBoxDocProvider.Text,
                    txtBoxDocClient.Text,
                    txtBoxDocClientId.Text
                };
                SideWorker.DocInotialize(docData, bill, pList.Select(SideWorker.CastToLibraryProducts).ToList());
                if (!toEdit)
                {
                    await SideWorker.CreateDocumentSequence("Bill", docData, bill.Products, docList.ToList(), MainWindow.info.FullName);
                    docList.Add(bill);
                }

                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    asmxService.SetDocumentBillAsync(docData, bill.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    MyWcfService.ArrayOfString toWcf = new MyWcfService.ArrayOfString
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocClientId.Text
                    };
                    await wcfService.SetDocumentBillAsync(toWcf, bill.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }   
                
                mainWinGrid.Items.Refresh();
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
