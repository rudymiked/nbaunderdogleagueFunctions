using Microsoft.Azure.WebJobs;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace nbaunderdogleagueFunctions
{
    public class Functions
    {
        public Functions() { }

        [FunctionName("UpdateTeamStatsFromRapidAPI")]
        public static async Task UpdateTeamStatsFromRapidAPI([TimerTrigger("0 0 * * * *", RunOnStartup = false)] TimerInfo timer)
        {
            string msg;
            try {

                string api = "api/NBA/UpdateTeamStatsFromRapidAPI/";

                HttpClient httpClient = new();
                HttpRequestMessage request = new() {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(AppConstants.NBAUnderdogLeagueAPIURL + api),
                };

                HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
            } catch (Exception ex) {
                msg = ex.Message;
            }
        }

        [FunctionName("UpdateGamesFromRapidAPI")]
        public static async Task UpdateGamesFromRapidAPI([TimerTrigger("0 0 0 * * *", RunOnStartup = false)] TimerInfo timer)
        {
            string msg;
            try {

                string api = "api/NBA/UpdateGamesFromRapidAPI/";

                HttpClient httpClient = new();
                HttpRequestMessage request = new() {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(AppConstants.NBAUnderdogLeagueAPIURL + api),
                };

                HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
            } catch (Exception ex) {
                msg = ex.Message;
            }
        }
    }
}
