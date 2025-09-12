using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PasswordTests
    {
        [Fact]
        public void IsStrongPassword_ValidPassword_ReturnsTrue()
        {
            string password = "Passwo1!";

            bool result = MyMethods.IsValidPassword(password);

            Assert.True(result);
        }

        [Fact]
        public void IsStrongPassword_NoLowercaseLetter_ReturnsFalse()
        {
            string password = "PASS123!";

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsStrongPassword_NoUppercaseLetter_ReturnsFalse()
        {
            string password = "pass123!";

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsStrongPassword_TooShort_ReturnsFalse()
        {
            string password = "Abc123!"; // 7 символов

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsStrongPassword_TooLong_ReturnsFalse()
        {
            string password = "Abcdefghijklmnopqrs!uvwxyz12345"; // 31 символ

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsStrongPassword_NoDigit_ReturnsFalse()
        {
            string password = "Passwor!";

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsStrongPassword_NoSpecialChar_ReturnsFalse()
        {
            string password = "Passwor1";

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        // 🔍 Дополнительный тест: пароль с недопустимым символом (например, кириллица или пробел)
        [Fact]
        public void IsStrongPassword_ContainsInvalidChar_ReturnsFalse()
        {
            string password = "Pass🧨123!";

            bool result = MyMethods.IsValidPassword(password);

            Assert.False(result);
        }

        // 🔍 Дополнительный тест: пустая строка
        [Fact]
        public void IsStrongPassword_NullOrEmpty_ReturnsFalse()
        {
            Assert.False(MyMethods.IsValidPassword(null));
            Assert.False(MyMethods.IsValidPassword(""));
        }
    }
}
