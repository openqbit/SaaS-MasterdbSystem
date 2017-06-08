using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Common.Model
{
     public class Resorce
    {
        public int ID { get; set; }
        public int TypeID { get; set; }

        public virtual ResourceType Type { get; set; }

        [Column(TypeName = "xml")]
        public string DetailsXml { get; set; }

        [NotMapped]
        public XDocument DetailsElement
        {
            get { return DetailsXml != null ? XDocument.Parse(DetailsXml) : null; }
            set { DetailsXml = value.ToString(); }
        }
    }
}
