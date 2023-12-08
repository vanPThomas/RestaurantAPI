using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            User user = _userRepository.GetById(userId);
            return (user);
        }

        public void AddUser(User user)
        {
            try
            {
                if (
                    !string.IsNullOrWhiteSpace(user.Name)
                    && !string.IsNullOrWhiteSpace(user.Email)
                    && user.Email.Contains("@")
                    && !string.IsNullOrWhiteSpace(user.Phone)
                    && user.Phone.All(char.IsDigit)
                )
                {
                    _userRepository.Add(user);
                }
                else
                {
                    throw new UserException(
                        "Invalid user data. Name, Email, and a valid Email format are required."
                    );
                }
            }
            catch (Exception ex)
            {
                throw new UserException(
                    "Invalid user data. Name, Email, and a valid Email format are required."
                );
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                if (
                    !string.IsNullOrWhiteSpace(user.Name)
                    && !string.IsNullOrWhiteSpace(user.Email)
                    && user.Email.Contains("@")
                    && !string.IsNullOrWhiteSpace(user.Phone)
                    && user.Phone.All(char.IsDigit)
                )
                {
                    _userRepository.Update(user);
                }
                else
                {
                    throw new UserException(
                        "Invalid user data. Name, Email, and a valid Email format are required."
                    );
                }
            }
            catch (Exception ex)
            {
                throw new UserException(
                    "Invalid user data. Name, Email, and a valid Email format are required."
                );
            }
        }

        public void RemoveUser(User user)
        {
            _userRepository.Remove(user);
        }
    }
}
