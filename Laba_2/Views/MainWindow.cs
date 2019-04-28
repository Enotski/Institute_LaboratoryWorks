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
        SideWorker.ServicesSwitcher serviceToUse = SideWorker.ServicesSwitcher.client;
        SideWorker.GetDocsSwitcher getDocsType = SideWorker.GetDocsSwitcher.special;
        public static MyAsmxService.DocumentsWebService asmxService;
        BindingList<Document> bList = new BindingList<Document>();
        string filePath = @"..\..\DataStore\LocalDocumentsStore.xml";
        string docToGet;
        public static FileInfo info;
        MyAsmxService.Document[] docData = null;

        public MainWindow()
        {
            InitializeComponent();
            DataGridViewDocumentsTable.DataSource = bList;
            info = new FileInfo(filePath);
            asmxService = new MyAsmxService.DocumentsWebService();
            asmxService.GetAllDocumentsCompleted += AsmxService_GetAllDocumentsCompleted;
            asmxService.GetSpecialDocumentsCompleted += AsmxService_GetSpecialDocumentsCompleted;
            asmxService.GetSpecialDocumentCompleted += AsmxService_GetSpecialDocumentCompleted;
        }

        private void AsmxService_GetSpecialDocumentCompleted(object sender, MyAsmxService.GetSpecialDocumentCompletedEventArgs e)
        {
            docData = e.Result;
            var newList = docData.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                bList.Add(d);
            SearchData(docToGet);
        }
        private void AsmxService_GetSpecialDocumentsCompleted(object sender, MyAsmxService.GetSpecialDocumentsCompletedEventArgs e)
        {
            docData = e.Result;
            var newList = docData.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                bList.Add(d);
        }
        private void AsmxService_GetAllDocumentsCompleted(object sender, MyAsmxService.GetAllDocumentsCompletedEventArgs e)
        {
            docData = e.Result;
            var newList = docData.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                bList.Add(d);
        }

        private async void button_RefreshFile_Click(object sender, EventArgs e)
        {
            // только для клиента
            await SideWorker.SerializeXml(info.FullName, bList);
        }
        private async void button_LoadFromFile_Click(object sender, EventArgs e)
        {
            List<Document> newList = new List<Document>();

            if (serviceToUse == SideWorker.ServicesSwitcher.asmx)
            {
                if (getDocsType == SideWorker.GetDocsSwitcher.all)
                {
                    asmxService.GetAllDocumentsAsync();
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.invoices)
                {
                    asmxService.GetSpecialDocumentsAsync("Invoice");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.reciepts)
                {
                    asmxService.GetSpecialDocumentsAsync("Reciept");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.bills)
                {
                    asmxService.GetSpecialDocumentsAsync("Bill");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.special)
                {
                    asmxService.GetSpecialDocumentAsync(docToGet);
                }            
            }
            else if (serviceToUse == SideWorker.ServicesSwitcher.client)
            {
                newList = await SideWorker.DeserializeXml(filePath);
                foreach (var d in newList)
                    bList.Add(d);
            }           
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
       {
            SearchData(textBoxSearch.Text);
            docToGet = textBoxSearch.Text;
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
        #region события радио-кнопок (переключение между сервисами и тд.)
        private void RadioButtonWcfService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.wcf;
        }
        private void radioButtonAsmxService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.asmx;
        }
        private void RadioButtonClientService_CheckedChanged(object sender, EventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.client;

            panelLoadDocumentsRbts.Enabled = !panelLoadDocumentsRbts.Enabled;
            panelLoadDocumentsRbts.Visible = !panelLoadDocumentsRbts.Visible;

            textBoxServiceUrl.Enabled = !textBoxServiceUrl.Enabled;
            textBoxServiceUrl.Visible = !textBoxServiceUrl.Visible;

            button_RefreshFile.Enabled = !button_RefreshFile.Enabled;
            button_RefreshFile.Visible = !button_RefreshFile.Visible;
        }
        private void RadioButtonGetBills_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.bills;
        }
        private void RadioButtonGetReciepts_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.reciepts;
        }
        private void RadioButtonGetInvoices_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.invoices;
        }
        private void RadioButtonGetAllDocs_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.all;
        }
        private void TextBoxServiceUrl_TextChanged(object sender, EventArgs e)
        {
            asmxService.Url = ((TextBox)sender).Text;
        }
        private void RadioButtonGetSpecialDoc_CheckedChanged(object sender, EventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.special;
        }
        #endregion
    }
}
