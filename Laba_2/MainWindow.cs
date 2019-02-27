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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            object doc = DocSelectComboBox.SelectedItem;
            if(doc is null)
                MessageBox.Show("Выберите документ!");
            else
            {
                DocumentConstructor docConst = new DocumentConstructor();
                if(doc.ToString() == "Квитанция")
                {
                    docConst.ShowPanel("Reciept");
                }
                else if (doc.ToString() == "Счет")
                {
                    docConst.ShowPanel("Bill");
                }
                else if (doc.ToString() == "Накладная")
                {
                    docConst.ShowPanel("Invoice");
                }
                docConst.Show();
            }
        }
    }
}
