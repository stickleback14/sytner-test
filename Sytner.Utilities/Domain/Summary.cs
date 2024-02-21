using System;
using System.Collections.Generic;
using System.Text;

namespace Sytner.Utilities.Domain
{
    public class Summary : BaseEntity<int>
    {
        public int Above { get; set; }
        public int Below { get; set; }
        public string Description { get; set; }
    }
}
