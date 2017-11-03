using System.Data.SqlClient;

namespace SOLID.SingleResponsability.GoodImplementation
{
    public class UserDatabaseAccess : IUserDataAccess
    {
        public const string DataBaseConnection = "MyDatabaseConnection";

        public int Save(User user)
        {
            var cnx = new SqlConnection(DataBaseConnection);
            cnx.Open();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = cnx,
                CommandText = $"Insert into User (Login, Password) Values({user.Login}, {user.Password})"
            };
            return cmd.ExecuteNonQuery();
        }

        public User GetUserById(int id)
        {
            var cnx = new SqlConnection(DataBaseConnection);
            cnx.Open();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = cnx,
                CommandText = $"SELECT * FROM User where Id = {id}"
            };


            User user = null;
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    user = new User()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Login = dr["Login"].ToString(),
                        Password = dr["Password"].ToString(),
                    };
            }
        }
            return user;
        }
    }
}
