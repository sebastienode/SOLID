using System.Data.SqlClient;

namespace SOLID.SingleResponsability.BadImplementation
{
    public class User
    {
        public const string DataBaseConnection = "MyDatabaseConnection";

        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User(int id)
        {
            GetUserById(this.Id);
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool Save()
        {
            if (Login.Length < 4 || Password.Length < 8)
                return false;
            else
                return SaveInDatabase() == 1;
        }

        private void GetUserById(int id)
        {
            var cnx = new SqlConnection(DataBaseConnection);
            cnx.Open();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = cnx,
                CommandText = $"SELECT * FROM User where Id = {Id}"
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Id = int.Parse(dr["Id"].ToString());
                Login = dr["Login"].ToString();
                Password = dr["Password"].ToString();
            }
        }

        private int SaveInDatabase()
        {
            var cnx = new SqlConnection(DataBaseConnection);
            cnx.Open();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = cnx,
                CommandText = $"Insert into User (Login, Password) Values({Login}, {Password})"
            };
            return cmd.ExecuteNonQuery();
        }
    }
}
