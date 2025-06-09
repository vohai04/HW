using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class UserService
    {
        private Logger _logger;

        public UserService()
        {
            // Get logger instance
            _logger = Logger.GetInstance;
        }

        public void RegisterUser(string username)
        {
            try
            {
                // Simulate user registration
                if (string.IsNullOrEmpty(username))
                {
                    throw new ArgumentException("Username cannot be empty");
                }

                _logger.LogInfo($"User '{username}' registered successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to register user: {ex.Message}");
            }
        }
    }
}
