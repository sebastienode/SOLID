using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SingleResponsability.GoodImplementation
{
    public class Role
    {
        public string Name { get; set; }
        public HashSet<Right> Rights { get; private set; }

        public Role(string name)
        {
            Name = name;
            Rights = new HashSet<Right>();
        }

        public bool HasRight(Right right)
        {
            return Rights.Contains(right);
        }
    }
}
