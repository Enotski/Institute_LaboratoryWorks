using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using OP_ClassLib;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Laba_7.Controls
{

    sealed class DocumentsDeserializeActivity<TResult> : CodeActivity<IList<TResult>> where TResult : class
    {
        [RequiredArgument]
        public InArgument<string> FilePath { get; set; }

        public DocumentsDeserializeActivity() { }
        protected override IList<TResult> Execute(CodeActivityContext context)
        {
            XmlReader reader = new XmlTextReader(FilePath.Get(context));
            XmlSerializer serializer = new XmlSerializer(typeof(List<TResult>));
            var responce = (IList<TResult>)serializer.Deserialize(reader);
            reader.Close();

            return responce;
        }
    }
}
