using CaseStudy.Models;
using System;
using System.Collections.Generic;

namespace CaseStudy.Service
{
    internal class UsersService
    {
        private List<Users> usersList = new List<Users>();

        public void Register(Users user)
        {
            if (!UserExists(user.UserName))
            {
                usersList.Add(user);
                Console.WriteLine("Registration successful. Please continue to Login");
            }
            else
            {
                Console.WriteLine("Username already exists. Try again!");
            }
        }

        public bool Login(string username, string password)
        {
            foreach (Users user in usersList)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return true; // User authenticated successfully
                }
            }
            return false; // User not found or invalid credentials
        }

        public bool UserExists(string username)
        {
            foreach (Users user in usersList)
            {
                if (user.UserName == username)
                {
                    return true; // User already exists
                }
            }
            return false; // User does not exist
        }
    }
}
