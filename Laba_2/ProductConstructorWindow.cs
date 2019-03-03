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
    public partial class ProductConstructorWindow : Form
    {
        public List<Product> pList;
        public Control productTable;

        public ProductConstructorWindow(InvoiceConstructorWindow invConstWin)
        {
            InitializeComponent();

        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {

            }
        }
        private bool ValidationForm()
        {
            foreach (var control in this.Controls)
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
    }
}
