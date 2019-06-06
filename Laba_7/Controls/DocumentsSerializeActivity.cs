using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using OP_ClassLib;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace Laba_7.Controls
{

    public sealed class DocumentsSerializeActivity : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> FilePath { get; set; }
        [RequiredArgument]
        public InArgument<IList<Document>> AllDocuments { get; set; }

        protected override void Execute(CodeActivityContext context)
        {           
            var filePath = FilePath.Get(context);
            XmlWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
            serializer.Serialize(writer, AllDocuments.Get<IList<Document>>(context));
            writer.Close();
        }
    }
}
