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
        public List<Document> _docList;
        public RecieptConstructorWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                Reciept reciept = new Reciept(textBoxProviderName.Text, textBoxClientName.Text, textBoxDocId.Text, textBoxDocDate.Text, textBoxPaymentName.Text);
                _docList.Add(reciept);
                this.Close();
            }
        }

        private bool ValidationForm()
        {
            foreach(var control in RecieptPanel.Controls)
            {
                if(control is TextBox)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
