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

        [Theory]
        [InlineData("PASS123!")]
        [InlineData("pass123!")]
        [InlineData("Abc123!")]
        [InlineData("Abcdefghijklmnopqrs!uvwxyz12345")]
        [InlineData("Passwor!")]
        [InlineData("Passwor1")]
        [InlineData("Pass\U0001f9e8123!")]
        public void IsValidPassword_InvalidPassword_ReturnsFalse(string password)
        {
            Assert.False(IsValidPassword(password));
        }
    }
}
