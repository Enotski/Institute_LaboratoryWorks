using Laba_7.Controls;
using OP_ClassLib;
using System;
using System.Collections.Generic;
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
        BindingList<Product> pList;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcf wcfService = MainWindow.wcfService;
        public BillWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SideWorker.ValidationForm(docConstructor.Children))
            {
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
                    docList.Add(bill);
                this.Close();
            }
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
            pList = new BindingList<Product>(bill.Products);
            dataGridProducts.ItemsSource = pList;
            bill.SetProductList(pList.ToList());
            TextBoxBinding();
            txtBoxDocClientId.Text = bill.ClientId;
        }

        private void DataGridProducts_CurrentCellChanged(object sender, EventArgs e)
        {
            var product = ((DataGrid)sender).CurrentItem as Product;

            bill.CalcProductSum(bill.Products.FindIndex(p => p.Equals(product)));
            bill.CalcGoodsSum();
            txtBoxDocGoodsSum.Text = bill.GoodsSum.ToString();
        }
    }
}
