using Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserModel;
using UserServices;

namespace Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbcontext _userdb;
        public UserService(ApplicationDbcontext userdb)
        {
            _userdb=userdb;
        }
        public bool DeleteUser(int id)
        {
            var data=_userdb.myuser.FirstOrDefault(value=>value.id==id);
            if(data==null)
            {
               return false;
            }
            else
            {
                 _userdb.myuser.Remove(data);
                _userdb.SaveChanges();
                return true;
            }
        }

        public List<User> GetUser()
        {
            var data=_userdb.myuser;
            return data.ToList();
        }

        public User PostUser(User user)
        {
            _userdb.myuser.Add(user);
            _userdb.SaveChanges();
            return user;
        }
    }
}