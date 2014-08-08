using System;
using System.Linq;
using System.Xml.Linq;
using WrgPrototype.Contracts;

namespace WrgPrototype.Implementations
{
    public class UserService : IUserService
    {
        private static readonly Users Users = new Users();

        static UserService()
        {
            XElement mq = XElement.Parse("<MQ><Gender>Male</Gender><Hobbies><Soccer/><MartialArts/><PingPong/></Hobbies></MQ>");

            Users.Add(new User{Email = "abc@abc.com", FirstName = "ABC", LastName = "123", UserId="888", Notes = mq});
        }

        public Users GetAllUsers()
        {
            return Users;
        }

        public User AddUser(User user)
        {
            user.UserId = Guid.NewGuid().ToString();
            Users.Add(user);

            return user;
        }

        public User GetUser(string userId)
        {
            var foundUser = FindUser(userId);
            return foundUser;
        }

        public void DeleteUser(string userId)
        {
            var foundUser = FindUser(userId);
            Users.Remove(foundUser);
        }

        public User UpdateUser(string userId, User user)
        {
            var foundUser = FindUser(userId);
            if (foundUser != null)
            {
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        private User FindUser(string userId)
        {
            var foundUser = (from u in Users where u.UserId == userId select u).Single();
            User ret = foundUser ?? new User();

            return ret;
        }


    }
}