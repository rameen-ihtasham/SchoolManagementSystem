﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BBL
{
    public class User
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public int Role { get; set; }

        public User()
        {

        }
        public User(int id, string username, string Password, int role)
        {
            ID = id;
            UserName= username;
            password = Password;
            Role = role;

        }
        public int GetMyRole()
        {
            return Role;
        }
        public void SetMyRole(int value)
        {
            Role = value;
        }
    }
}
