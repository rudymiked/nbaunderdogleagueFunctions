using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace nbaunderdogleagueFunctions
{
    public static class Functions
    {
        [FunctionName("UpdateTeamStatsFromRapidAPI")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string msg;
            try {

                string api = "api/Team/UpdateTeamStatsFromRapidAPI/";

                HttpClient httpClient = new();
                HttpRequestMessage request = new() {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(AppConstants.NBAUnderdogLeagueAPIURL + api),
                };

                HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                log.LogInformation(content);

                return new OkObjectResult(content);
            } catch (Exception ex) {
                log.LogError(ex, ex.Message);
                msg = ex.Message;
            }

            return new OkObjectResult(msg);
        }
    }
}
