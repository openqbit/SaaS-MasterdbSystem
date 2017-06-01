using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OpenQbit.Masterdb.Common.Models

{
  public  class Resorce
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
