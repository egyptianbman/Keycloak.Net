using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

[assembly: InternalsVisibleTo("Keycloak.Net")]
namespace Keycloak.Net.Shared.Json
{
    /// <summary>
    /// Extension methods for <see cref="IFlurlRequest"/>.
    /// </summary>
    public static class FlurlRequestExtensions
    {
        public static IFlurlRequest WithForwardedHttpHeaders(this IFlurlRequest request, ForwardedHttpHeaders? forwardedHeaders)
        {
            forwardedHeaders ??= new ForwardedHttpHeaders();
            request.WithHeader("X-Forwarded-For", forwardedHeaders.ForwardedFor)
                .WithHeader("X-Forwarded-Proto", forwardedHeaders.ForwardedProto)
                .WithHeader("X-Forwarded-Host", forwardedHeaders.ForwardedHost);
            
            return request;
        }
        
        /// <summary>
        /// Configures request to obtain an authentication bearer token via the delegate method specified.
        /// </summary>
        public static async Task<IFlurlRequest> WithAuthenticationAsync(this IFlurlRequest request, Func<Task<string?>> getTokenAsync)
        {
            var rawToken = await getTokenAsync() ?? string.Empty;

            // Token must not be prefixed
            if (!string.IsNullOrEmpty(rawToken) && rawToken.StartsWith("Bearer"))
            {
                rawToken = rawToken.Replace("Bearer", string.Empty).Trim();
            }

            return request.WithOAuthBearerToken(rawToken);
        }

        /// <summary>
        /// Get access token via password flow.
        /// </summary>
        public static async Task<IFlurlRequest> WithAuthenticationAsync(this IFlurlRequest request, string realm, string clientId, string userName, string password)
        {
            var result = await new Url(request.Url)
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Accept", "application/json")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "password"),
                    new("client_id", clientId),
                    new("username", userName),
                    new("password", password)
                })
                .ReceiveJson().ConfigureAwait(false);

            string rawToken = result
                .access_token.ToString();

            return request.WithOAuthBearerToken(rawToken);
        }

        /// <summary>
        /// Get access token via client credentials flow
        /// </summary>
        public static async Task<IFlurlRequest> WithAuthenticationAsync(this IFlurlRequest request, string realm, string clientId, string clientSecret)
        {
            var result = await new Url(request.Url)
                .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "client_credentials"),
                    new("client_secret", clientSecret),
                    new("client_id", clientId)
                })
                .ReceiveJson().ConfigureAwait(false);

            string rawToken = result
                .access_token.ToString();

            return request.WithOAuthBearerToken(rawToken);
        }
        
        /// <inheritdoc cref="WithAuthenticationAsync(IFlurlRequest,Func{Task{string}})"/>
        public static IFlurlRequest WithAuthentication(this IFlurlRequest request, Func<string?> getToken)
        {
            return WithAuthenticationAsync(request, async () => await Task.FromResult(getToken() ?? string.Empty)).GetAwaiter().GetResult();
        }
    }
}
