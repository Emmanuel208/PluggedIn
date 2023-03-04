using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PluggedIn_V1._6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Web.Mvc;
using static PluggedIn_V1._6.Models.Model;
//using System.Data.Spatial;
using System.Linq;

namespace PluggedIn_V1._6.Services
{
   
    public class usersDAO
    {
        //connection to the database--- data-link
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog = PluggedInlogin; Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        //public bool GetNearByLocations(string Currentlat, string Currentlng )
        //{


        //    using (var context = new PluggedInlogin())
        //    {


        //        //var currentLocation = DbGeography.FromText("POINT( " + Currentlng + " " + Currentlat + " )");

        //        var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");



        //        var places = (from u in context.storeInfos
        //                      orderby u.GeoLocation.Distance(currentLocation)
        //                      select u).Take(4).Select(x => new PluggedIn_V1._6.Models.storeInfo() { storeName = x.storeName, lat = x.GeoLocation.Latitude, lng = x.GeoLocation.Longitude, Distance = x.GeoLocation.Distance(currentLocation) });
        //        var nearStore = places.ToList();


        //        return Json(nearStore, JsonRequestBehavior.AllowGet);


        //    }

        //}

        //private bool Json(List<storeInfo> nearStore, JsonRequestBehavior allowGet)
        //{
        //    throw new NotImplementedException();
        //}



        // connection made for geo loaction
        //public IActionResult GetNearByLocations(string Currentlat, string Currentlng)
        //{


        //    using (var context = new PluggedInlogin())
        //    {


        //        var currentLocation = DbGeography.FromText("POINT( " + Currentlng + " " + Currentlat + " )");

        //        //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");



        //        var places = (from u in context.storeInfos
        //                      orderby u.GeoLocation.Distance(currentLocation)
        //                      select u).Take(4).Select(x => new PluggedIn_V1._6.Models.storeInfo() { storeName = x.storeName, lat = x.GeoLocation.Latitude, lng = x.GeoLocation.Longitude, Distance = x.GeoLocation.Distance(currentLocation) });
        //        var nearStore = places.ToList();

        //        return (IActionResult)Json(nearStore, JsonRequestBehavior.AllowGet);


        //    }

        //}





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

        //// REMOVES USER FROM DATABASE(WITH RESPECT TO THE SQL IDNTITY FIELD
        //public bool RemoveUserNameAndPassword(userModel user)
        //{
            
        //    string sqlStatement = "delete from dbo.users where id = (@Id)";
        //    bool success = false;

        //    // Insert into Employee(FName, MName, LName, EmailId) values(@FName, @MName, @LName, @EmailId) End

        //    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
        //    {
        //        var command = new System.Data.SqlClient.SqlCommand(sqlStatement, connection);
        //        command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 40).Value = user.Id;
        //        command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.userName;
        //        command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.password;


        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();

        //            success = true;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);

        //        }
        //        return success;
        //    }
        //}


        // ADD USER CONTACT INFROMATION

        public bool AddUserContactInfo(userContact userContact)
        {
            string sqlStatement = "Insert into dbo.Contact values(@Name, @Address, @Contact, @Email)";
            bool success = false;

            // Insert into Employee(FName, MName, LName, EmailId) values(@FName, @MName, @LName, @EmailId) End

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var command = new System.Data.SqlClient.SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 40).Value = userContact.Name;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 100).Value = userContact.Address;
                command.Parameters.Add("@Contact", System.Data.SqlDbType.VarChar, 40).Value = userContact.Contact;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 40).Value = userContact.Email
                    ;


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
