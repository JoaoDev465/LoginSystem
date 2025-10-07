// using System.Net;
// using System.Text;
// using System.Text.Json;
// using Core.Contracts.AuthContract;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Core.Entity;
// using Core.ValueObject.UserEntityObject;
// using Microsoft.VisualStudio.TestPlatform.TestHost;
// using IdValue = Core.ValueObject.TokenEntityObject.IdValue;
//
// namespace Test.UnitTest.TestEndPoints;
//
// public class TestRegister
// {
//     [Fact]
//     public async Task TestRegisterEndPoint()
//     {
//         var httpClient = new HttpClient();
//         var user = new RegisterContract
//         {
//             Id = 1,
//             Email = "joao@gmail.com",
//             Password = "galo1234$$Ga",
//             Name = "joao",
//             Roles = new[] { "adm" }
//         };
//
//         var content = new StringContent(
//             JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
//
//         var response =   await  httpClient.PostAsync("http://localhost:5287/auth/register", content);
//
//         var result = await  response.Content.ReadAsStringAsync();
//         
//        Assert.Equal(HttpStatusCode.Created,response.StatusCode);
//        Assert.False(string.IsNullOrEmpty(result));
//       
//     }
// }