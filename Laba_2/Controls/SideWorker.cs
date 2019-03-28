using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using OP_ClassLib;
using System.ComponentModel;

namespace Laba_2.Controls
{
    class SideWorker
    {
        // xml десериализация
        public static async Task<List<Document>> DeserializeXml(string filePath)
        {
            List<Document> newList = await Task.Run(() =>
            {
                XmlReader reader = new XmlTextReader(filePath);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
                var res = (List<Document>)serializer.Deserialize(reader);
                reader.Close();
                return res;
            });
            return newList;
        }
        // xml сереализация
        public static async Task SerializeXml(string filePath, BindingList<Document> bList)
        {
            await Task.Run(() =>
            {
                XmlWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
                serializer.Serialize(writer, bList.ToList());
                writer.Close();
            });
        }
        // валидация формы
        public static bool ValidationForm(Control.ControlCollection controls)
        {
            foreach (var control in controls)
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
