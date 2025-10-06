// using System.Net;
// using System.Text;
// using System.Text.Json;
// using Core.Contracts.AuthContract;
// using Core.Entity;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Microsoft.VisualStudio.TestPlatform.TestHost;
//
// namespace Test.UnitTest.TestEndPoints;
//
// public class TestUserUpdate
// {
//     [Fact]
//     public async Task EndPointUpdate()
//     {
//         await using var app = new  WebApplicationFactory<Program>();
//         var http = app.CreateClient();
//         var registerRequest = new RegisterContract
//         {
//             Id = 1,
//             Email = "joao@gmail.com",
//             Password = "galo1234$$Ga",
//             Name = "joao",
//             Roles = new[] { "adm" }
//         };
//         var updateRequest = new RegisterContract
//         {
//             Email = "joao@gmail.com",
//             Password = "galinha1234$$Ga",
//             Name = "marcelo",
//             Roles = new[] { "adm" }
//         };
//         var registerContent = new StringContent
//         (JsonSerializer.Serialize(registerRequest)
//             , Encoding.UTF8, "application/json");
//
//         var updateContent = new StringContent
//         (JsonSerializer.Serialize(updateRequest)
//             , Encoding.UTF8, "application/json");
//
//         var registerResponse = await http.PostAsync
//             ("/auth/register", registerContent);
//
//         var updateResponse = await http.PutAsync
//             ($"/auth/update/{registerRequest.Id}", updateContent);
//
//         var registerResult = await registerResponse.Content.ReadAsStringAsync();
//         var updateResult = await updateResponse.Content.ReadAsStringAsync();
//
//         Assert.NotNull(registerResult);
//         Assert.NotNull(updateResult);
//         Assert.Equal(HttpStatusCode.Created, registerResponse.StatusCode);
//         Assert.False(string.IsNullOrEmpty(registerResult));
//         Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
//         Assert.False(string.IsNullOrEmpty(updateResult));
//     }
// }