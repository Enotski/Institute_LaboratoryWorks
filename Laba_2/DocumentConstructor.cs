using OP_ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2
{
    public partial class DocumentConstructor : Form
    {
        public DocumentConstructor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void ShowPanel(string docPanel)
        {
            if (docPanel is "Reciept")
            {
                RecieptPanel.Enabled = true;
                RecieptPanel.Visible = true;
            }
            else if (docPanel is "Bill")
            {
                BillPanel.Enabled = true;
                BillPanel.Visible = true;
            }
            else if (docPanel is "Invoice")
            {
                InvoicePanel.Enabled = true;
                InvoicePanel.Visible = true;
            }
        }
    }
}
