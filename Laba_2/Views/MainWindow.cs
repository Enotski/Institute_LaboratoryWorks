using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using OP_ClassLib;
using Laba_2.Controls;

namespace Laba_2
{
    public partial class MainWindow : Form
    {
        BindingList<Document> bList = new BindingList<Document>();
        string filePath = @"..\..\DataStore\LocalDocumentsStore.xml";
        public MainWindow()
        {
            InitializeComponent();
            DataGridViewDocumentsTable.DataSource = bList;
        }      

        private void button_RefreshFile_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(filePath);
            SideWorker.SerializeXml(info.FullName, bList);
        }
        private async void button_LoadFromFile_Click(object sender, EventArgs e)
        {
            var newlist = await SideWorker.DeserializeXml(filePath);
            foreach(var d in newlist)
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
                RecConst.Show();
            }
            else if (selectedDoc.ToString() is "Счет")
            {
                BillConstructorWindow BillConst = new BillConstructorWindow();
                BillConst.docList = bList;
                BillConst.Show();
            }
            else if (selectedDoc.ToString() is "Накладная")
            {
                InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                InvConst.docList = bList;

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
                    RecConst.Show();
                }
                else if (currentDoc is Bill)
                {
                    BillConstructorWindow BillConst = new BillConstructorWindow();
                    BillConst.bill = (Bill)currentDoc;
                    BillConst.docList = bList;
                    BillConst.toEdit = true;
                    BillConst.Show();
                }
                else if (currentDoc is Invoice)
                {
                    InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                    InvConst.invoice = (Invoice)currentDoc;
                    InvConst.docList = bList;
                    InvConst.toEdit = true;
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
    }
}
