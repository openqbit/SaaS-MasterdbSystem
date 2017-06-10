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
        //rid
        public int RID { get; set; }
        //prid
        public int PRID { get; set; }
        //resourceid
        public int ResourceHierachyID { get; set; }

        //foreign key for rid
        [ForeignKey("RID")]
      //  [InverseProperty]
        public virtual Resorce ChildResorce { get; set; }
        //foreign key for prid
        [ForeignKey("PRID")]
        //return the resource key
        public virtual Resorce ParentResorce { get; set; }
        //return the hierachy key not name
        public virtual ResourceHierachy ResourceHierachy { get; set; }
    }
}
