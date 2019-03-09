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
    public partial class RecieptConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public List<Product> productList = new List<Product>();
        public Reciept reciept = new Reciept();

        Product _p;
        BindingList<Product> rList;
        BindingSource source;

        public RecieptConstructorWindow()
        {
            InitializeComponent();
        }
        private void TextBoxBinding()
        {
            textBoxDocId.DataBindings.Add("Text", reciept, "DocId");
            textBoxDocDate.DataBindings.Add("Text", reciept, "DocDate");
            textBoxProviderName.DataBindings.Add("Text", reciept, "Provider");
            textBoxClientName.DataBindings.Add("Text", reciept, "Client");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                if (!toEdit)
                    docList.Add(reciept);
                this.Close();
            }
        }    
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pIndx = e.RowIndex;
            DataGridViewRow productRow = dataGridViewProducts.Rows[pIndx];
            ProductInitialize(productRow);
        }

        private bool ValidationForm()
        {
            foreach (var control in RecieptPanel.Controls)
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
        private void ProductInitialize(DataGridViewRow productRow)
        {
            foreach (DataGridViewCell cell in productRow.Cells)
            {
                if (!cell.ReadOnly && cell.Value == null)
                    return;
            }
            DataGridViewCellCollection dataCells = productRow.Cells;

            double priceCell = reciept.CalcProductSum(dataCells[0].Value.ToString());
            dataCells[4].Value = priceCell;
            reciept.CalcGoodsSum();
            ProductSumLable.Text = reciept.GoodsSum.ToString();
        }

        private void RecieptConstructorWindow_Shown(object sender, EventArgs e)
        {
            rList = new BindingList<Product>(productList);
            source = new BindingSource(rList, null);
            dataGridViewProducts.DataSource = source;
            reciept.SetProductList(productList);

            TextBoxBinding();
            textBoxPaymentName.DataBindings.Add("Text", reciept, "PaymentName");
        }

        private void dataGridViewProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _p = new Product();
            reciept.SetProduct(_p);
        }
    }
}
