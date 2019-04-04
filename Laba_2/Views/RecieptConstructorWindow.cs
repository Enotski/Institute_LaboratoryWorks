using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Laba_2.Controls;
using OP_ClassLib;

namespace Laba_2
{
    public partial class RecieptConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public Reciept reciept = new Reciept();
        BindingList<Product> pList;
        public MainWindow.Services serviceToUse;

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
            if (SideWorker.ValidationForm(RecieptPanel.Controls))
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

        private void ProductInitialize(DataGridViewRow productRow)
        {
            DataGridViewCellCollection dataCells = productRow.Cells;
            if(dataCells[0].Value != null)
            {
                dataCells[4].Value = reciept.CalcProductSum(dataCells[0].Value.ToString()).ToString();
                reciept.CalcGoodsSum();
                ProductSumLable.Text = reciept.GoodsSum.ToString();
            }
        }

        private void RecieptConstructorWindow_Shown(object sender, EventArgs e)
        {
            pList = new BindingList<Product>(reciept.Products);
            dataGridViewProducts.DataSource = pList;
            reciept.SetProductList(pList.ToList());

            TextBoxBinding();
            textBoxPaymentName.DataBindings.Add("Text", reciept, "PaymentName");
        }
    }
}
