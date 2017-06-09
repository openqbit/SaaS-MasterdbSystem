using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace OpenQbit.Masterdb.Common.Model
{
    public  class ResourceHierachyDetails
    {
        //main key
        public int ID { get; set; }

        public int RID { get; set; }

        public int PRID { get; set; }

        public int ResourceHierachyID { get; set; }


        [ForeignKey("RID")]
        public virtual Resorce ChildResorce { get; set; }

        [ForeignKey("PRID")]
        public virtual Resorce ParentResorce { get; set; }
        public virtual ResourceHierachy ResourceHierachy { get; set; }
    }
}
