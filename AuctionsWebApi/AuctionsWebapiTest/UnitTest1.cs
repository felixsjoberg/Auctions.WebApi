using System.Security.Cryptography.X509Certificates;

namespace AuctionsTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            int num1 = 300;
            int num2 = 500;

            //Act
            VerifyBid newBid = new VerifyBid();
            bool returnVal = newBid.VerifyNewBid(num1, num2);
            
            //Assert
            Assert.True(returnVal);
        }
    }
}