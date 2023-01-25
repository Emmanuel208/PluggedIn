using PluggedIn_V1._6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PluggedIn_V1._6.Services
{
    public class SecurityService
    {
        
        usersDAO usersDAO = new usersDAO();
        public SecurityService()
        {
          
        }
        public bool IsValid(userModel user)
        {
            return usersDAO.FindUserByNameAndPaswword(user);
            // rteurn true if found in list
          
        }

        public bool AddUser(userModel user)
        {
            return usersDAO.AddUserNameAndPassword(user);
        }
    }
}
