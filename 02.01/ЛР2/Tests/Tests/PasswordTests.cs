using static MyLibrary.MyMethods;

namespace Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("Passwo1!")]
        public void IsValidPassword_ValidPassword_ReturnsTrue(string password)
        {
            bool result = IsValidPassword(password);

            Assert.True(result);
        }

        [Fact]
        public void IsValidPassword_InvalidPassword_ReturnsFalse()
        {
            string password = "PASS123!";

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPassword_NoUppercaseLetter_ReturnsFalse()
        {
            string password = "pass123!";

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPassword_TooShort_ReturnsFalse()
        {
            string password = "Abc123!"; // 7 символов

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPassword_TooLong_ReturnsFalse()
        {
            string password = "Abcdefghijklmnopqrs!uvwxyz12345"; // 31 символ

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPassword_NoDigit_ReturnsFalse()
        {
            string password = "Passwor!";

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPassword_NoSpecialChar_ReturnsFalse()
        {
            string password = "Passwor1";

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        // 🔍 Дополнительный тест: пароль с недопустимым символом (например, кириллица или пробел)
        [Fact]
        public void IsValidPassword_ContainsInvalidChar_ReturnsFalse()
        {
            string password = "Pass🧨123!";

            bool result = IsValidPassword(password);

            Assert.False(result);
        }

        // 🔍 Дополнительный тест: пустая строка
        [Fact]
        public void IsValidPassword_NullOrEmpty_ReturnsFalse()
        {
            Assert.False(IsValidPassword(null));
            Assert.False(IsValidPassword(""));
        }
    }
}
