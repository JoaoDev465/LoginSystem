using System.Net;
using System.Text;
using System.Text.Json;
using Core.Contracts.AuthContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test.UnitTest.TestEndPoints;

public class TestLoginEndPoint
{
    [Fact]
    public async Task LoginEndPoint()
    {
       
        var http = new HttpClient();
        var registerRequest = new RegisterContract
        {
            Id = 1,
            Email = "joao@gmail.com",
            Password = "galo1234$$Ga",
            Name = "joao",
            Roles = new[] { "adm" }
        };
        var loginRequest = new LoginContract
        {
            Email = "joao@gmail.com",
            Password = "galo1234$$Ga"
        };

        var registerContent = new StringContent
            (JsonSerializer.Serialize(registerRequest)
                ,Encoding.UTF8,"application/json");
        
        var loginContent = new StringContent
        (JsonSerializer.Serialize(loginRequest)
            ,Encoding.UTF8,"application/json");
        
        var registerResponse = await  http.PostAsync
            ("http://localhost:5287/auth/register",registerContent);

        var loginResponse = await http.PutAsync
            ("http://localhost:5287/auth/login", loginContent);

        var registerResult = await registerResponse.Content.ReadAsStringAsync();
        var loginResult = await loginResponse.Content.ReadAsStringAsync();

        Assert.NotNull(registerResult);
        Assert.NotNull(loginResult);
        Assert.Equal(HttpStatusCode.Created,registerResponse.StatusCode);
        Assert.False(string.IsNullOrEmpty(registerResult));
        Assert.Equal(HttpStatusCode.MethodNotAllowed,loginResponse.StatusCode);
        
    }
}