using Microsoft.Data.SqlClient;
using PluggedIn_V1._6.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PluggedIn_V1._6.Services
{
    public class usersDAO
    {
        //connection to the database--- data-link
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog = PluggedInlogin; Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

        //Add user to the database
        public bool AddUserNameAndPassword(userModel user)
        {
            string sqlStatement = "Insert into dbo.users values(@username, @password)";
            bool success = false;

            // Insert into Employee(FName, MName, LName, EmailId) values(@FName, @MName, @LName, @EmailId) End

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var command = new System.Data.SqlClient.SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.userName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.password;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                return success;
            }
        }

           /* using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.userName;

                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.password;

                try
                {
                    connection.Open();
                    System.Data.SqlClient.SqlDataAdapter adapter = comman();

                    if (adapter.HasRows)
                    {
                        success = true;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

                return success;
            }


        }*/



        //Lookup username and password in database
        public bool FindUserByNameAndPaswword(userModel user) {

            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.users Where userName =@username AND password =@password";

            //Finding data from database 
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.userName;

                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.password;

                try
                {
                    connection.Open();
                    System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;

                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
             
                }

                return success;
            }
        }
    }

}
