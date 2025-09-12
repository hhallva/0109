using System.Text.RegularExpressions;

namespace Tests
{
    public class MyMethods
    {
        public static double Power(double a, int n)
        {
            if (n == 0)
            {
                if (a == 0)
                    throw new ArgumentException("Неопределённое выражение: 0^0");
                return 1.0;
            }

            if (a == 0)
            {
                if (n < 0)
                    throw new ArgumentException("Неопределённое выражение: 0^(-n)");
                return 0.0;
            }

            double result = 1;
            int absN = Math.Abs(n);

            for (int i = 0; i < absN; i++)
                result *= a;

            if (n < 0)
                result = 1 / result;

            return Math.Round(result, 3);
        }


        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < 8 || password.Length > 30)
                return false;

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{}|;:,.<>?/~`]+$"))
                return false;
            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;
            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{}|;:,.<>?/~`]"))
                return false;

            return true;
        }
    }
}
