using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OP_ClassLib;

namespace Laba_2
{
    public partial class MainWindow : Form
    {
        DataTable docTable = new DataTable();
        public List<Document> DocList = new List<Document>
        {
            new Invoice("p", "c", "4312", "1/1/1111", "2", "3"),
            new Invoice("p", "c", "8891", "1/1/1111", "2", "3"),
            new Bill("p", "c", "7881", "1/1/1111", "2"),
            new Reciept("p", "c", "9142", "1/1/1111", "2"),
            new Reciept("p", "c", "6531", "1/1/1111", "2"),
            new Invoice("p", "c", "8732", "1/1/1111", "2", "3"),
            new Reciept("p", "c", "0091", "1/1/1111", "2"),
            new Bill("p", "c", "1167", "1/1/1111", "2"),
        };

        public MainWindow()
        {
            InitializeComponent();
            
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            object selectedDoc = DocSelectComboBox.SelectedItem;
            if (selectedDoc.ToString() is "Квитанция")
            {
                RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                RecConst.docList = DocList;
                RecConst.Show();
            }
            else if (selectedDoc.ToString() is "Счет")
            {
                BillConstructorWindow BillConst = new BillConstructorWindow();
                BillConst.docList = DocList;
                BillConst.Show();
            }
            else if (selectedDoc.ToString() is "Накладная")
            {
                InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                InvConst.docList = DocList;
                InvConst.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGirdViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);
            DocumentPrintLabel.Text = currentDoc.Print();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            docTable.Columns.Add("№", typeof(int));
            docTable.Columns.Add("Дата", typeof(string));
            docTable.Columns.Add("Тип", typeof(string));

            TableInitialize(docTable, DocList);

            DataGirdViewDocumentsTable.DataSource = docTable;
        }
        private void TableInitialize(DataTable dt, List<Document> documents)
        {
            dt.Clear();
            string typeName = "";
            foreach (var doc in documents)
            {
                if (doc.GetType().Name == "Bill")
                {
                    typeName = "Счет";
                }
                else if (doc.GetType().Name == "Reciept")
                {
                    typeName = "Квитанция";
                }
                else if (doc.GetType().Name == "Invoice")
                {
                    typeName = "Накладная";
                }

                dt.Rows.Add(int.Parse(doc.DocId), doc.DocDate.ToLocalTime(), typeName);
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            TableInitialize(docTable, DocList);
            DataGirdViewDocumentsTable.Update();
            DataGirdViewDocumentsTable.Refresh();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData(textBoxSearch.Text);
        }

        private void SearchData(string value)
        {
            foreach (DataGridViewRow row in DataGirdViewDocumentsTable.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(value))
                {
                    row.Selected = true;
                    break;
                }
                else
                    row.Selected = false;
            }
        }
    }
}
