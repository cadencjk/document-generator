using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Model
{
    public class DocumentGeneratorXml
    {
        public List<PlaceHolder> PlaceHolders { get; set; }
    }

    public class PlaceHolder
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
