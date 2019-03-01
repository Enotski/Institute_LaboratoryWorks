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
        List<Document> DocList = new List<Document>
        {
            new Bill("Loktev", "Parovik", "989121", "12.12.2012", "88912311"),
            new Bill("Loktev", "Parovik", "986912", "12.12.2012", "88912311"),
            new Reciept("Loktev", "Parovik", "554910", "12.12.2012", "88912311"),
            new Invoice("Loktev", "Parovik", "390012", "12.12.2012", "88912311", "99011211"),
            new Reciept("Loktev", "Parovik", "189643", "12.12.2012", "88912311"),
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DocumentsTableList.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);
            DocumentPrintLabel.Text = currentDoc.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object doc = DocSelectComboBox.SelectedItem;
            if(doc is null)
                MessageBox.Show("Выберите документ!");
            else
            {
                DocumentConstructorWindow docConst = new DocumentConstructorWindow();
                if(doc.ToString() == "Квитанция")
                {
                    docConst.ShowPanel("Reciept");
                }
                else if (doc.ToString() == "Счет")
                {
                    docConst.ShowPanel("Bill");
                }
                else if (doc.ToString() == "Накладная")
                {
                    docConst.ShowPanel("Invoice");
                }
                docConst.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DataTable docTable = new DataTable();

            docTable.Columns.Add("№", typeof(int));
            docTable.Columns.Add("Дата", typeof(string));
            docTable.Columns.Add("Тип", typeof(string));
            
            string typeName = "";
            foreach (var doc in DocList)
            {
                if(doc.GetType().Name == "Bill")
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

                docTable.Rows.Add(int.Parse(doc.DocId), doc.DocDate.ToLocalTime(), typeName);
            }

            DocumentsTableList.DataSource = docTable;
        }

        private void ButtonDocShow_Click(object sender, EventArgs e)
        {
        }
    }
}
