using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace CSharp.Professional.Serealizations.XML
{
    [XmlRoot("root")]
    public class MyClassData
    {
        private string str = "s1";
        List<string> items = new List<string>();

        [XmlAttribute("WorkStr")]
        public string Str { get { return str; } set { str = value; } }

        [XmlAttribute("int")]
        public int I { get; set; } = 1;

        [XmlElement("Pos")]
        public Point Position { get; set; } = new Point(12, 15);

        [XmlIgnore]
        public string Password { get; set; } = "1234567890";

        [XmlArray("Lists")]
        [XmlArrayItem("Item")]
        public List<string> MyList { get { return items; } set { items = value; } }
    }
}
