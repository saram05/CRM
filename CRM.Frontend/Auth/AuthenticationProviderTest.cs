using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CRM.Frontend.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    //ingreso al sistema y muestra que es un usuario anónimo
        //    var anonimous = new ClaimsIdentity();
        //    var UserPrueba = new ClaimsIdentity(authenticationType: "test");
        //    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(UserPrueba)));
        //}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var sara = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "sara"),
                new Claim("LastName", "marroquin"),
                new Claim(ClaimTypes.Name, "marroquin@yopmail.com"),
                new Claim(ClaimTypes.Role, "test")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(sara)));
        }

    }

}
