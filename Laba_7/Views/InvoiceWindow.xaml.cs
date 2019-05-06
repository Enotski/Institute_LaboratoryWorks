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
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcf wcfService = MainWindow.wcfService;
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

        private void ButtonDocAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SideWorker.ValidationForm(docConstructor.Children))
            {
                invoice.Products = pList.Select(SideWorker.CastToLibraryProducts).ToList();
                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocProviderId.Text,
                        txtBoxDocClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип
                    asmxService.SetDocumentInvoiceAsync(docData, invoice.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
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
                        txtBoxDocProviderId.Text,
                        txtBoxDocClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип

                    wcfService.SetDocumentInvoiceAsync(docData, invoice.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }
                invoice.SetDocId(txtBoxDocId.Text);
                invoice.SetDocDate(txtBoxDocDate.Text);
                invoice.SetParticipants(txtBoxDocProvider.Text, txtBoxDocClient.Text);
                invoice.SetProviderId(txtBoxDocProviderId.Text);
                invoice.SetClientId(txtBoxDocClientId.Text);
                invoice.SetProductList(pList.Select(SideWorker.CastToLibraryProducts).ToList());

                if (!toEdit)
                {
                    docList.Add(invoice);
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
