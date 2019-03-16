using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Laba_2.Controls;
using OP_ClassLib;

namespace Laba_2
{
    public partial class BillConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public Bill bill = new Bill();
        BindingList<Product> pList;

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
            if (SideWorker.ValidationForm(BillPanel.Controls))
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
        private void BillConstructorWindow_Shown(object sender, EventArgs e)
        {
            pList = new BindingList<Product>(bill.Products);
            dataGridViewProducts.DataSource = pList;
            bill.SetProductList(pList.ToList());

            TextBoxBinding();
            textBoxClientId.DataBindings.Add("Text", bill, "ClientId");
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
            DataGridViewCellCollection dataCells = productRow.Cells;
            dataCells[4].Value = bill.CalcProductSum(dataCells[0].Value.ToString()).ToString();
            bill.CalcGoodsSum();
            ProductSumLable.Text = bill.GoodsSum.ToString();
        }
    }
}
