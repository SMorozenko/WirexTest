using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirex.Engine
{
    struct CompositeKey
    {
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public DateTime DateTime { get; set; }

        public override int GetHashCode()
        {
            return Int1.GetHashCode() ^ Int2.GetHashCode() ^ DateTime.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CompositeKey)
            {
                CompositeKey compositeKey = (CompositeKey)obj;

                return ((this.Int1 == compositeKey.Int1) &&
                        (this.Int2 == compositeKey.Int2) &&
                        (this.DateTime == compositeKey.DateTime));
            }

            return false;
        }
    }
}
