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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public bool toEdit;
        public SideWorker.ServicesSwitcher serviceToUse;
        public Invoice invoice = new Invoice();
        public ObservableCollection<Document> docList;
        ObservableCollection<ModelProduct> pList;
        public DataGrid mainWinGrid;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcfClient wcfService = MainWindow.wcfClient;
        public InvoiceWindow()
        {
            InitializeComponent();
        }
        private void TextBoxBinding()
        {
            txtBoxDocId.Text = invoice.DocId;
            txtBoxDocDate.Text = invoice.DocDate.ToString();
            txtBoxDocProvider.Text = invoice.Provider;
            txtBoxDocClient.Text = invoice.Client;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            pList = new ObservableCollection<ModelProduct>(invoice.Products.Select(SideWorker.CastToModelProducts));
            dataGridProducts.ItemsSource = pList;
            TextBoxBinding();
            txtBoxDocProviderId.Text = invoice.ProviderId;
            txtBoxDocClientId.Text = invoice.ClientId;
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
                        txtBoxDocProviderId.Text,
                        txtBoxDocClientId.Text
                   };
                SideWorker.DocInotialize(docData, invoice, pList.Select(SideWorker.CastToLibraryProducts).ToList());
                if (!toEdit)
                {
                    await SideWorker.CreateDocumentSequence("Invoice", docData, invoice.Products, docList.ToList(), MainWindow.info.FullName);
                    docList.Add(invoice);
                }
                mainWinGrid.Items.Refresh();

                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    asmxService.SetDocumentInvoiceAsync(docData, invoice.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    MyWcfService.ArrayOfString toWcf = new MyWcfService.ArrayOfString
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocProviderId.Text,
                        txtBoxDocClientId.Text
                    };
                    await wcfService.SetDocumentInvoiceAsync(toWcf, invoice.Products.Select(SideWorker.CastToWcfProducts).ToArray());
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
