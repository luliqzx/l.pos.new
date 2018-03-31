using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class TEntity<TID> : BaseT<TID>
    {
        public virtual string CreateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual string CreateTerimal { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual string UpdateTerminal { get; set; }
        public virtual DateTime? Timestamp { get; set; }
    }
}
