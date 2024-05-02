using CRUD_Operations;
using DBFinalProject.BL;
using DBFinalProject.Forms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace DBFinalProject.DataAccess
{
    {

        public static SqlConnection con = Configuration.getInstance().getConnection();

        public static int LastInsertedUserId { get; private set; }

        static public void InsertUser(User user)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] ( UserName, Password, Role) OUTPUT Inserted.ID VALUES ( @Username, @Password, @role);", con);

            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            LastInsertedUserId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();




        {
        }


        }

    }

}


   
