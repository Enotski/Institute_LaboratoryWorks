using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using OP_ClassLib;

namespace Laba_2
{
    public partial class MainWindow : Form
    {
        // edit...
        private List<Product> products = new List<Product>
        {
            new Product("кросы", "шт", 2, 3500),
            new Product("перчатки", "шт", 10, 300),
            new Product("акции", "шт", 21, 1200)
        };
        public List<Document> DocList = new List<Document>
        {
            new Invoice("man", "man", "4312", "1/1/1111", "2", "3"),
            new Invoice("man", "man", "8891", "1/1/1111", "2", "3"),
            new Bill("man", "man", "7881", "1/1/1111", "2")
        };
        // edit...

        BindingList<Document> bList;
        BindingSource source;

        // edit...
        string filePath = @"..\..\LocalDocumentsStore.xml";
        public MainWindow()
        {
            // edit...
            ((Invoice)DocList[0]).Products = products;
            ((Invoice)DocList[1]).Products = products;
            ((Bill)DocList[2]).Products = products;

            InitializeComponent();
            bList = new BindingList<Document>(DocList);
            source = new BindingSource(bList, null);
            DataGirdViewDocumentsTable.DataSource = source;
        }      



        // поиск
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData(textBoxSearch.Text);
        }

        private void SearchData(string value)
        {
            foreach (DataGridViewRow row in DataGirdViewDocumentsTable.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(value))
                {
                    row.Selected = true;
                    break;
                }
                else
                    row.Selected = false;
            }
        }

        // добавление
        private void button_Add_Click(object sender, EventArgs e)
        {
            object selectedDoc = DocSelectComboBox.SelectedItem;
            if (selectedDoc.ToString() is "Квитанция")
            {
                RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                RecConst.docList = bList;
                RecConst.Show();
            }
            else if (selectedDoc.ToString() is "Счет")
            {
                BillConstructorWindow BillConst = new BillConstructorWindow();
                BillConst.docList = bList;
                BillConst.Show();
            }
            else if (selectedDoc.ToString() is "Накладная")
            {
                InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                InvConst.docList = bList;
                InvConst.Show();
            }
        }

        private void button_RefreshFile_Click(object sender, EventArgs e)
        {
            RefreshXml(filePath);
        }

        private void button_LoadFromFile_Click(object sender, EventArgs e)
        {

        }

        private async void LoadFromXml(string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
        }

        private async void RefreshXml(string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            FileInfo info = new FileInfo(filePath);

            XmlSerializer formatter = new XmlSerializer(typeof(Document));
            xDoc.Load(info.FullName);
            using (FileStream fs = new FileStream(info.FullName, FileMode.Append))
            {
                await Task.Run(() =>
                {
                    foreach (var doc in bList)
                    {
                        formatter.Serialize(fs, doc);
                    }
                });
            }
        }
        private void PushToXml(XmlDocument xDoc, Document toFile)
        {
            #region
            //XmlElement xRoot = xDoc.DocumentElement;
            //// создаем новый элемент user
            //XmlElement node = xDoc.CreateElement("document");
            //// создаем атрибут name
            //XmlAttribute typeAttr = xDoc.CreateAttribute("type");
            //// создаем элементы company и age
            //XmlElement idElem = xDoc.CreateElement("id");
            //XmlElement dateElem = xDoc.CreateElement("Date");
            //XmlElement providerElem = xDoc.CreateElement("provider");
            //XmlElement clientElem = xDoc.CreateElement("client");
            //// создаем текстовые значения для элементов и атрибута
            //XmlText typeText = xDoc.CreateTextNode(toFile.Type);
            //XmlText idText = xDoc.CreateTextNode(toFile.DocId);
            //XmlText dateText = xDoc.CreateTextNode(toFile.DocDate.ToString());
            //XmlText providerText = xDoc.CreateTextNode(toFile.Provider);
            //XmlText clientText = xDoc.CreateTextNode(toFile.Client);

            ////добавляем узлы
            //typeAttr.AppendChild(typeText);
            //idElem.AppendChild(idText);
            //dateElem.AppendChild(dateText);
            //providerElem.AppendChild(providerText);
            //clientElem.AppendChild(clientText);

            //node.Attributes.Append(typeAttr);
            //node.AppendChild(idElem);
            //node.AppendChild(dateElem);
            //node.AppendChild(providerElem);
            //node.AppendChild(clientElem);
            //xRoot.AppendChild(node);
            #endregion

        }

        private void DataGirdViewDocumentsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGirdViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);

            if (currentDoc != null)
                DocumentPrintLabel.Text = currentDoc.Print();
        }

        private void DataGirdViewDocumentsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDocId = DataGirdViewDocumentsTable.CurrentRow.Cells[0].Value.ToString();
            Document currentDoc = DocList.Find(doc => doc.DocId == currentDocId);

            if (currentDoc != null)
            {
                if (currentDoc is Reciept)
                {
                    RecieptConstructorWindow RecConst = new RecieptConstructorWindow();
                    RecConst.docList = bList;
                    RecConst.reciept = (Reciept)currentDoc;
                    RecConst.productList = ((Reciept)currentDoc).Products;
                    RecConst.toEdit = true;
                    RecConst.Show();
                }
                else if (currentDoc is Bill)
                {
                    BillConstructorWindow BillConst = new BillConstructorWindow();
                    BillConst.bill = (Bill)currentDoc;
                    BillConst.productList = ((Bill)currentDoc).Products;
                    BillConst.docList = bList;
                    BillConst.toEdit = true;
                    BillConst.Show();
                }
                else if (currentDoc is Invoice)
                {
                    InvoiceConstructorWindow InvConst = new InvoiceConstructorWindow();
                    InvConst.invoice = (Invoice)currentDoc;
                    InvConst.productList = ((Invoice)currentDoc).Products;
                    InvConst.docList = bList;
                    InvConst.toEdit = true;
                    InvConst.Show();
                }
            }
        }
    }
}
