using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRoger.Client.ApiClients
{
    public class UnsuccessfullResponseDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception(responseContent);
            }

            return response;
        }
    }
}
