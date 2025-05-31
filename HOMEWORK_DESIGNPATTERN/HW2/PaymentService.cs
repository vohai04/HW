using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class PaymentService
    {
        private Logger _logger;

        public PaymentService()
        {
            // Get logger instance
            _logger = Logger.GetInstance;
        }

        public void ProcessPayment(string userId, decimal amount)
        {
            try
            {
                // Simulate payment processing
                if (amount <= 0)
                {
                    throw new ArgumentException("Payment amount must be positive");
                }

                _logger.LogInfo($"Payment of ${amount} processed for user '{userId}'");

                // Simulate a business rule check
                if (amount > 1000)
                {
                    _logger.LogWarning($"Large payment of ${amount} detected for user '{userId}'. Verification required.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Payment processing failed: {ex.Message}");
            }
        }
    }

}
