using Google.Apis.Auth;
using Newtonsoft.Json;
using OrderMyFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Repository
{
    public class OAuthService
    {
        // You might want to have a configuration for your OAuth providers
        private readonly Dictionary<string, string> _providerConfigurations;

        public OAuthService()
        {
            _providerConfigurations = new Dictionary<string, string>
        {
            { "Google", "YourGoogleClientId" },  // Replace with your actual client ID
            { "Facebook", "YourFacebookAppId" }  // Replace with your actual app ID
        };
        }

        public async Task<CustomerMasterModel> VerifyTokenAsync(string provider, string token)
        {
            switch (provider)
            {
                case "Google":
                    return await VerifyGoogleTokenAsync(token);
                case "Facebook":
                    return await VerifyFacebookTokenAsync(token);
                default:
                    throw new NotSupportedException($"Provider {provider} is not supported.");
            }
        }

        private async Task<CustomerMasterModel> VerifyGoogleTokenAsync(string token)
        {
            // Call Google API to verify the token
            var payload = await GoogleJsonWebSignature.ValidateAsync(token);

            return new CustomerMasterModel
            {
                
                Name = payload.Name,
                Email = payload.Email
            };
        }

        private async Task<CustomerMasterModel> VerifyFacebookTokenAsync(string token)
        {
            // Call Facebook API to verify the token
            var url = $"https://graph.facebook.com/me?access_token={token}&fields=id,name,email";
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            dynamic userData = JsonConvert.DeserializeObject(response);

            return new CustomerMasterModel
            {
                Id = userData.id,
                Name = userData.name,
                Email = userData.email
            };
        }
    }

}
