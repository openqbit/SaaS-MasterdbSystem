using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Common.Model
{
    public  class ResourceHierachy
    {
        public int ID { get; set; }

        public int ResourceHierachyTypeID { get; set; }

        public virtual ResourceHierachyType Type { get; set; }
    }
}
