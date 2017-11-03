using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SingleResponsability.GoodImplementation
{
    public class Right
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            var right = obj as Right;
            return right != null && right.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
