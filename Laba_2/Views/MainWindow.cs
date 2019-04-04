using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using OP_ClassLib;
using Laba_2.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Laba_2
{
    public partial class MainWindow : Form
    {
        Services serviceToUse = Services.client;
        GetDocsSwitcher getDocsType = GetDocsSwitcher.all;
        MyAsmxService.DocumentsWebService asmxService;
        BindingList<Document> bList = new BindingList<Document>();
        string filePath = @"..\..\DataStore\LocalDocumentsStore.xml";
        public static FileInfo info;

        public MainWindow()
        {
            InitializeComponent();
            DataGridViewDocumentsTable.DataSource = bList;
            info = new FileInfo(filePath);
        }      

        private async void button_RefreshFile_Click(object sender, EventArgs e)
        {
            await SideWorker.SerializeXml(info.FullName, bList);
        }
        private async void button_LoadFromFile_Click(object sender, EventArgs e)
        {
            List<Document> newList = new List<Document>();

            if (serviceToUse == Services.asmx)
            {
                asmxService = new MyAsmxService.DocumentsWebService();
                MyAsmxService.Document[] docData = null;

                if (getDocsType == GetDocsSwitcher.all)
                {
                    docData = asmxService.GetAllDocuments(info.FullName);
                }
                else if (getDocsType == GetDocsSwitcher.invoices)
                {
                    docData = asmxService.GetSpecialDocuments(info.FullName, "Invoice");
                }
                else if (getDocsType == GetDocsSwitcher.reciepts)
                {
                    docData = asmxService.GetSpecialDocuments(info.FullName, "Reciept");
                }
                else if (getDocsType == GetDocsSwitcher.bills)
                {
                    docData = asmxService.GetSpecialDocuments(info.FullName, "Bill");
                }

                newList = docData.Select(CastToClientDocuments).ToList();
            }
            else if (serviceToUse == Services.client)
            {
                newList = await SideWorker.DeserializeXml(filePath);          
            }
            foreach (var d in newList)
                bList.Add(d);
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData(textBoxSearch.Text);
        }
        // добавление
        private void button_Add_Click(object sender, EventArgs e)
        {
            object selectedDoc = DocSelectComboBox.SelectedItem;
            if (selectedDoc.ToString() is "Квитанция")
            {
                RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                RecConst.docList = bList;
                RecConst.serviceToUse = serviceToUse;
                RecConst.Show();
            }
            else if (selectedDoc.ToString() is "Счет")
            {
                BillConstructorWindow BillConst = new BillConstructorWindow();
                BillConst.docList = bList;
                BillConst.serviceToUse = serviceToUse;
                BillConst.Show();
            }
            else if (selectedDoc.ToString() is "Накладная")
            {
                InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                InvConst.docList = bList;
                InvConst.serviceToUse = serviceToUse;
                InvConst.Show();
            }
        }
        // вывод
        private void DataGirdViewDocumentsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGridViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = bList.First(doc => doc.DocId == currentDocId);

            if (currentDoc != null)
                DocumentPrintLabel.Text = currentDoc.Print();
        }
        // редактирование
        private void DataGirdViewDocumentsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGridViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = bList.First(doc => doc.DocId == currentDocId);

            if (currentDoc != null)
            {
                if (currentDoc is Reciept)
                {
                    RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                    RecConst.reciept = (Reciept)currentDoc;
                    RecConst.docList = bList;
                    RecConst.toEdit = true;
                    RecConst.serviceToUse = serviceToUse;
                    RecConst.Show();
                }
                else if (currentDoc is Bill)
                {
                    BillConstructorWindow BillConst = new BillConstructorWindow();
                    BillConst.bill = (Bill)currentDoc;
                    BillConst.docList = bList;
                    BillConst.toEdit = true;
                    BillConst.serviceToUse = serviceToUse;
                    BillConst.Show();
                }
                else if (currentDoc is Invoice)
                {
                    InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                    InvConst.invoice = (Invoice)currentDoc;
                    InvConst.docList = bList;
                    InvConst.toEdit = true;
                    InvConst.serviceToUse = serviceToUse;
                    InvConst.Show();
                }
            }
        }

        // поиск(фильтрация таблицы)
        private void SearchData(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                DataGridViewDocumentsTable.DataSource = bList;
            else
            {
                var tmpSource = new BindingList<Document>(new BindingList<Document>(bList.Where(m => m.DocId.ToLower().Contains(value.ToLower())).ToList()));
                DataGridViewDocumentsTable.DataSource = tmpSource;
            }
        }
        private void RadioButtonWcfService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = Services.wcf;
            panelLoadDocumentsRbts.Enabled = true;
            panelLoadDocumentsRbts.Visible = true;
        }
        private void radioButtonAsmxService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = Services.asmx;
            panelLoadDocumentsRbts.Enabled = true;
            panelLoadDocumentsRbts.Visible = true;
        }
        private void RadioButtonClientService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = Services.client;
            panelLoadDocumentsRbts.Enabled = false;
            panelLoadDocumentsRbts.Visible = false;
        }

        public enum Services
        {
            asmx,
            wcf,
            client
        }
        public enum GetDocsSwitcher
        {
            all,
            invoices,
            bills,
            reciepts
        }
        public Document CastToClientDocuments(MyAsmxService.Document dataToCast)
        {
            if (dataToCast is MyAsmxService.Bill)
            {
                Bill convertedBill = new Bill(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Bill)dataToCast).ClientId);
                convertedBill.GoodsSum = ((MyAsmxService.Bill)dataToCast).GoodsSum;

                foreach (var p in ((MyAsmxService.Bill)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                return convertedBill;
            }
            else if (dataToCast is MyAsmxService.Reciept)
            {
                Reciept convertedBill = new Reciept(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Reciept)dataToCast).PaymentName);
                convertedBill.GoodsSum = ((MyAsmxService.Reciept)dataToCast).GoodsSum;
                foreach (var p in ((MyAsmxService.Reciept)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                return convertedBill;
            }
            else if (dataToCast is MyAsmxService.Invoice)
            {
                Invoice convertedBill = new Invoice(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Invoice)dataToCast).ProviderId, ((MyAsmxService.Invoice)dataToCast).ClientId);
                convertedBill.GoodsSum = ((MyAsmxService.Invoice)dataToCast).GoodsSum;
                foreach (var p in ((MyAsmxService.Invoice)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                return convertedBill;
            }
            else
                return default;
        }
        private void RadioButtonGetBills_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = GetDocsSwitcher.bills;
        }
        private void RadioButtonGetReciepts_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = GetDocsSwitcher.reciepts;
        }
        private void RadioButtonGetInvoices_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = GetDocsSwitcher.invoices;
        }
        private void RadioButtonGetAllDocs_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = GetDocsSwitcher.all;
        }
    }   
}
