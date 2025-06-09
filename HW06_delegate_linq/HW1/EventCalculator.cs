using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    

namespace DelegatesLinQ.Homework // Đảm bảo namespace này khớp với nơi định nghĩa delegate
{
    public class EventCalculator
    {
        // Khai báo các sự kiện cho các phép toán
        public event CalculationEventHandler OperationPerformed;
        public event ErrorEventHandler ErrorOccurred;

        public double Add(double a, double b)
        {
            double result = a + b;
            OnOperationPerformed("Addition", a, b, result);
            return result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            OnOperationPerformed("Subtraction", a, b, result);
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            OnOperationPerformed("Multiplication", a, b, result);
            return result;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                OnErrorOccurred("Division", "Division by zero is not allowed");
                return double.NaN; // Trả về NaN khi chia cho 0
            }
            double result = a / b;
            OnOperationPerformed("Division", a, b, result);
            return result;
        }

        // Phương thức kích hoạt sự kiện OperationPerformed
        protected virtual void OnOperationPerformed(string operation, double operand1, double operand2, double result)
        {
            OperationPerformed?.Invoke(operation, operand1, operand2, result);
        }

        // Phương thức kích hoạt sự kiện ErrorOccurred
        protected virtual void OnErrorOccurred(string operation, string errorMessage)
        {
            ErrorOccurred?.Invoke(operation, errorMessage);
        }
    }
}