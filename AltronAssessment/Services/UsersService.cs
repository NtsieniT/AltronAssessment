using Core.Interfaces;
using Core.Models;
using Core.Requests;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AltronAssessment.Services
{
    public class UsersService: IUsers
    {
        private readonly AltronContext _usersContext;

        public UsersService(AltronContext usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<List<Users>> GetUsers()
        {
            try
            {
                return await _usersContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }            
        }

        public async Task<Users> GetUserById(int id)
        {            
            try
            {
                var user = await _usersContext.Users.FindAsync(id);
                if (user != null)
                {
                    return user;
                }
                return null;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Users> AddUser(UsersRequest userRequest)
        {
            var user = new Users()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                IdNumber = userRequest.IdNumber,
                City = userRequest.City,
                Country = userRequest.Country,
                DateOfBirth = userRequest.DateOfBirth.Date,
                Gender = userRequest.Gender,
                PhoneNumber = userRequest.PhoneNumber,
                CreateDate = DateTime.Now
            };

            _usersContext.Users.Add(user);
            await _usersContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUser(int id, UsersRequest userRequest)
        {
            try
            {
                var existingUser = await _usersContext.Users.FindAsync(id);
                if (existingUser != null)
                {
                    //build model to update
                    existingUser.FirstName = userRequest.FirstName;
                    existingUser.LastName = userRequest.LastName;
                    existingUser.Email = userRequest.Email;
                    existingUser.IdNumber = userRequest.IdNumber;
                    existingUser.City = userRequest.City;
                    existingUser.Country = userRequest.Country;
                    existingUser.DateOfBirth = userRequest.DateOfBirth.Date;
                    existingUser.Gender = userRequest.Gender;
                    existingUser.PhoneNumber = userRequest.PhoneNumber;

                    _usersContext.Entry(existingUser).State = EntityState.Modified;
                    await _usersContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("User not found!");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> DeleteUser(int id)
        {            
            try
            {
                var user = await _usersContext.Users.FindAsync(id);

                if(user != null)
                {
                    _usersContext.Users.Remove(user);
                    await _usersContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
