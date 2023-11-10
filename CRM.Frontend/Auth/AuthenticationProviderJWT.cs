using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using CRM.Frontend.Helpers;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CRM.Frontend.Auth
{
    public class AuthenticationProviderJWT : AuthenticationStateProvider, ILoginService
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly HttpClient _httpClient;
        private readonly String _tokenKey;
        private readonly AuthenticationState _anonimous;

        public AuthenticationProviderJWT(IJSRuntime jSRuntime, HttpClient httpClient)
        {
            _jSRuntime = jSRuntime;
            _httpClient = httpClient;
            _tokenKey = "TOKEN_KEY";
            _anonimous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            /*Validamos si el usuario ya se autenticó*/
            var token = await _jSRuntime.GetLocalStorage(_tokenKey);
            if (token is null)
            {
                return _anonimous;
            }
            /*Como el usuario si se logeó, tenemos el token para generar la autenticacion*/
            return BuildAuthenticationState(token.ToString()!);
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            /*Enviamos la solicitud con el bearer token*/
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            
            /*Se genera una lista de claims que contiene la información para el login*/
            var claims = ParseClaimsFromJWT(token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJWT(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var unserializedToken = jwtSecurityTokenHandler.ReadJwtToken(token);
            return unserializedToken.Claims;

        }
        public async Task LoginAsync(string token)
        {
            await _jSRuntime.SetLocalStorage(_tokenKey, token);
            var authState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task LogoutAsync()
        {
            await _jSRuntime.RemoveLocalStorage(_tokenKey);
            _httpClient.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(Task.FromResult(_anonimous));
        }
    }

}
