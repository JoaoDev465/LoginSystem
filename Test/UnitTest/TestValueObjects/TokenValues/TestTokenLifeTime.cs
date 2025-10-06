// using Core.Exceptions.TokenExceptions;
// using Core.ValueObject.TokenEntityObject;
//
// namespace Test.UnitTest.TestValueObjects.TokenValues;
//
// public class TestTokenLifeTime
// {
//     [Fact]
//     public void TestTokenLifeTimeWhenDateIsNull()
//     {
//         DateTime? expiredat= null;
//         DateTime? createdat = null;
//         
//         var result = Assert.Throws<TokenLifeTimeException>(
//             ()=> new TokenDateLifeTime(createdat,expiredat));
//
//         Assert.Contains("createdat and expiredat can't be null", result.Message);
//     }
// }