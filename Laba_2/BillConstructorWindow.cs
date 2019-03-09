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
    public partial class BillConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public List<Product> productList = new List<Product>();
        public Bill bill = new Bill();

        Product _p;
        BindingList<Product> bList;
        BindingSource source;

        public BillConstructorWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                if(!toEdit)
                    docList.Add(bill);
                this.Close();
            }
        }

        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pIndx = e.RowIndex;
            DataGridViewRow productRow = dataGridViewProducts.Rows[pIndx];
            ProductInitialize(productRow);
        }

        private bool ValidationForm()
        {
            foreach (var control in BillPanel.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)control).Text))
                    {
                        MessageBox.Show("Заполните все поля");
                        return false;
                    }
                }
            }
            return true;
        }
        private void TextBoxBinding()
        {
            textBoxDocId.DataBindings.Add("Text", bill, "DocId");
            textBoxDocDate.DataBindings.Add("Text", bill, "DocDate");
            textBoxProviderName.DataBindings.Add("Text", bill, "Provider");
            textBoxClientName.DataBindings.Add("Text", bill, "Client");
        }
        private void ProductInitialize(DataGridViewRow productRow)
        {
            foreach (DataGridViewCell cell in productRow.Cells)
            {
                if (!cell.ReadOnly && cell.Value == null)
                    return;
            }
            DataGridViewCellCollection dataCells = productRow.Cells;

            double priceCell = bill.CalcProductSum(dataCells[0].Value.ToString());
            dataCells[4].Value = priceCell;
            bill.CalcGoodsSum();
            ProductSumLable.Text = bill.GoodsSum.ToString();
        }

        private void BillConstructorWindow_Shown(object sender, EventArgs e)
        {
            bList = new BindingList<Product>(productList);
            source = new BindingSource(bList, null);
            dataGridViewProducts.DataSource = source;
            bill.SetProductList(productList);

            TextBoxBinding();
            textBoxClientId.DataBindings.Add("Text", bill, "ClientId");
        }

        private void dataGridViewProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _p = new Product();
            bill.SetProduct(_p);
        }
    }
}
