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
        public List<Document> DocList = new List<Document>();

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
            string currentDocId = DocumentsTableList.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);
            DocumentPrintLabel.Text = currentDoc.Print();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            docTable.Columns.Add("№", typeof(int));
            docTable.Columns.Add("Дата", typeof(string));
            docTable.Columns.Add("Тип", typeof(string));

            TableInitialize(docTable);

            DocumentsTableList.DataSource = docTable;
        }
        private void TableInitialize(DataTable dt)
        {
            dt.Clear();
            string typeName = "";
            foreach (var doc in DocList)
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
            TableInitialize(docTable);
            DocumentsTableList.Update();
            DocumentsTableList.Refresh();
        }
    }
}
