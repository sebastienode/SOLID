using System.Data.SqlClient;

namespace SOLID.SingleResponsability.BadImplementation
{
    public class User
    {
        public const string DataBaseConnection = "MyDatabaseConnection";

        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool CanReadUsersList { get; private set; }
        public bool CanWriteUsersList { get; private set; }
        public bool CanReadProjectsList { get; private set; }
        public bool CanWriteProjectsList { get; private set; }
        public bool IsAdmin { get; private set; }

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
                CommandText = $"SELECT * FROM User where Id = {id}"
            };


            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    Id = int.Parse(dr["Id"].ToString());
                    Login = dr["Login"].ToString();
                    Password = dr["Password"].ToString();
                    CanReadUsersList = bool.Parse(dr["CanReadProjectsList"].ToString());
                    CanWriteUsersList = bool.Parse(dr["Password"].ToString());
                    CanReadProjectsList = bool.Parse(dr["Password"].ToString());
                    CanWriteProjectsList = bool.Parse(dr["Password"].ToString());
                    IsAdmin = bool.Parse(dr["Password"].ToString());
                }
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
