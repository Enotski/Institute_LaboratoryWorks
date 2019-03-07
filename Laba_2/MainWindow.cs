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
        public List<Document> DocList = new List<Document>
        {
            new Invoice("man", "man", "4312", "1/1/1111", "2", "3"),
            new Invoice("man", "man", "8891", "1/1/1111", "2", "3"),
            new Bill("man", "man", "7881", "1/1/1111", "2"),
        };
        BindingList<Document> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new BindingList<Document>(DocList);
            BindingSource source = new BindingSource(list, null);
            DataGirdViewDocumentsTable.DataSource = source;
        }      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGirdViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);

            if(currentDoc != null)
                DocumentPrintLabel.Text = currentDoc.Print();
        }

        // поиск
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

        // добавление
        private void button_Add_Click(object sender, EventArgs e)
        {
            object selectedDoc = DocSelectComboBox.SelectedItem;
            if (selectedDoc.ToString() is "Квитанция")
            {
                RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                RecConst.docList = list;
                RecConst.Show();
            }
            else if (selectedDoc.ToString() is "Счет")
            {
                BillConstructorWindow BillConst = new BillConstructorWindow();
                BillConst.docList = list;
                BillConst.Show();
            }
            else if (selectedDoc.ToString() is "Накладная")
            {
                InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                InvConst.docList = list;
                InvConst.Show();
            }
        }
        // удаление
        private void button_Remove_Click(object sender, EventArgs e)
        {
            object toRemove = DataGirdViewDocumentsTable.CurrentRow.DataBoundItem;
            DocList.Remove(toRemove as Document);
            DataGirdViewDocumentsTable.Update();
            DataGirdViewDocumentsTable.Refresh();
        }
    }
}
