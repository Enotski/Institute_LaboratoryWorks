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
        public DataGrid mainWinGrid;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcfClient wcfService = MainWindow.wcfClient;
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
                        txtBoxDocPayment.Text
                    };
                SideWorker.DocInotialize(docData, reciept, pList.Select(SideWorker.CastToLibraryProducts).ToList());
                if (!toEdit)
                {
                    await SideWorker.CreateDocumentSequence("Reciept", docData, reciept.Products, docList.ToList(), MainWindow.info.FullName);
                    docList.Add(reciept);
                }
                mainWinGrid.Items.Refresh();

                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    asmxService.SetDocumentRecieptAsync(docData, reciept.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    MyWcfService.ArrayOfString toWcf = new MyWcfService.ArrayOfString
                    {
                        txtBoxDocId.Text,
                        txtBoxDocDate.Text,
                        txtBoxDocProvider.Text,
                        txtBoxDocClient.Text,
                        txtBoxDocPayment.Text
                    };
                    await wcfService.SetDocumentRecieptAsync(toWcf, reciept.Products.Select(SideWorker.CastToWcfProducts).ToArray());
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
