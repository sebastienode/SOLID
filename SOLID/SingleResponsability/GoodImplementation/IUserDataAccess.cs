namespace SOLID.SingleResponsability.GoodImplementation
{
    public interface IUserDataAccess
    {
        int Save(User user);
        User GetUserById(int id);
    }
}