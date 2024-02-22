using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsers
    {
        Task<List<Users>> GetUsers();
        Task<Users> GetUserById(int id);
        Task<Users> AddUser(UsersRequest user);
        Task<bool> UpdateUser(int id, UsersRequest user);
        Task<bool> DeleteUser(int id);
    }
}
