using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Common.Model
{
    public  class Details
    {
        public int ID { get; set; }

        public int RID { get; set; }

        public int PRID { get; set; }

        public int ResourceHierachyID { get; set; }


        public virtual Resorce R { get; set; }
        public virtual ResourceHierachy ResourceHierachy { get; set; }
    }
}
