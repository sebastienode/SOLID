using System.Collections.Generic;
using System.Linq;

namespace SOLID.SingleResponsability.GoodImplementation
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public HashSet<Role> Roles { get; private set; }
        public HashSet<Right> Rights { get; private set; }

        public User()
        {
            Roles = new HashSet<Role>();
            Rights = new HashSet<Right>();
        }

        public bool HasRight(Right right)
        {
            return Roles.Any(r => r.HasRight(right)) || Rights.Contains(right);
        }
    }
}
