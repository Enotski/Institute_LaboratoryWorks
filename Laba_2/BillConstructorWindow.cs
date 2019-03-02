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
        public List<Document> _docList;
        public BillConstructorWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                Bill reciept = new Bill(textBoxProviderName.Text, textBoxClientName.Text, textBoxDocId.Text, textBoxDocDate.Text, textBoxClientId.Text);
                _docList.Add(reciept);
                this.Close();
            }
        }
    }
}
