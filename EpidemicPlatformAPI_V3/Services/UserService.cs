using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Contexts;

namespace EpidemicPlatformAPI_V3.Services
{
    public class UserService
    {
        private readonly PlatformContext platformContext;

        public UserService(PlatformContext context)
        {
            this.platformContext = context;
        }

        public void Register(User user)
        {
            platformContext.Users.Add(user);
            platformContext.SaveChanges();
        }

        public ReturnMessage LogIn(LogIn logIn)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            returnMessage.Ret = "no this user name";
            var user = platformContext.Users.FirstOrDefault(p => p.Name == logIn.Name);
            if (user != null)
            {
                if (user.PassWord == logIn.PassWord)
                    returnMessage.Ret = "login successfully";
                else
                    returnMessage.Ret = "password is wrong";
            }
            return returnMessage;
        }

        public User GetUserByName(string name)
        {
            var query = platformContext.Users.FirstOrDefault(p => p.Name == name);

            return query;
        }

        public void UserChange(User user)
        {
            var query = platformContext.Users.FirstOrDefault(p => p.Name == user.Name);
            query.PassWord = user.PassWord;
            query.PhoneNumber = user.PhoneNumber;
            query.Email = user.Email;
            query.Sex = user.Sex;
            query.Institution = user.Institution;
            platformContext.SaveChanges();
        }

        public void ChangePassword(string name, string pwd)
        {
            var query = platformContext.Users.FirstOrDefault(p => p.Name == name);
            query.PassWord = pwd;
            platformContext.SaveChanges();
        }
    }
}
