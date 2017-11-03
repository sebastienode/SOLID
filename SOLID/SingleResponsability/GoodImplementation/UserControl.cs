using System;

namespace SOLID.SingleResponsability.GoodImplementation
{
    public class UserControl
    {
        private IUserDataAccess _userDataAccess;

        public UserControl() : this(new UserDatabaseAccess())
        { }

        public UserControl(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public User GetUserById(int id)
        {
            var user = _userDataAccess.GetUserById(id);

            if (user == null)
            {
                throw new Exception($"User not found for the id: {id}");
            }

            return user;
        }

        public bool SaveUser(User user)
        {
            if (user.Login.Length < 4 || user.Password.Length < 8)
                return false;
            else
                return _userDataAccess.Save(user) == 1;
        }
    }
}
