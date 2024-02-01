using UserModel;

namespace UserServices
{
    public interface IUser
    {
        List<User>GetUser();
        User PostUser(User user);
        bool DeleteUser(int id);
    }
}