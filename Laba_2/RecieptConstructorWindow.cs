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
        public BindingList<Document> docList;
        public List<Product> productList = new List<Product>();
        ProductEditor _pEditor;
        Product _p;

        public RecieptConstructorWindow()
        {
            InitializeComponent();
            _pEditor = new ProductEditor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                Reciept reciept = new Reciept(textBoxProviderName.Text, textBoxClientName.Text, textBoxDocId.Text, textBoxDocDate.Text, textBoxPaymentName.Text);
                reciept.SetProductList(productList);
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

            _p = new Product();
            DataGridViewCellCollection dataCells = productRow.Cells;

            _pEditor.SetProductName(dataCells[0].Value.ToString(), _p);
            _pEditor.SetProductMeasureUnit(dataCells[1].Value.ToString(), _p);
            _pEditor.SetProductCount(dataCells[2].Value.ToString(), _p);
            _pEditor.SetProductPrice(dataCells[3].Value.ToString(), _p);
            _pEditor.SetProduct(productList, _p);

            double priceCell = _pEditor.CalcProductSum(dataCells[0].Value.ToString(), productList);
            dataCells[4].Value = priceCell;
            ProductSumLable.Text = _pEditor.CalcGoodsSum(productList).ToString();
        }
    }
}
