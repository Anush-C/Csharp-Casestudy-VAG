using CaseStudy.Models;
using CaseStudy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) {

        }

        public static void UserNotFound(int userid)
        {
            UserFavouriteRepository repository = new UserFavouriteRepository();
            if(!repository.UserExists(userid))
            {
                throw new UserNotFoundException("UserID does not found. Please try again!!!");
            }
        }
    }
}
