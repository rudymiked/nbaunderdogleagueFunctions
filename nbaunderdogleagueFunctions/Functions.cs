using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;

namespace nbaunderdogleagueFunctions
{
    public class Functions
    {
        public Functions() { }

        [Function("UpdateTeamStatsFromRapidAPI")]
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

        [Function("UpdateGamesFromRapidAPI")]
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

        [Function("UpdatePlayerStatsFromRapidAPI")]
        public static async Task UpdatePlayerStatsFromRapidAPI([TimerTrigger("0 0 0 * * 1,3,5,7", RunOnStartup = false)] TimerInfo timer)
        {
            string msg;
            try {

                string api = "api/NBA/UpdatePlayerStatsFromRapidAPI/";

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

        [Function("Warmer")]
        public static void WarmUp([TimerTrigger("0 6-23/1 * * *")] TimerInfo timer)
        {
            // Do nothing
        }

        [Function("WarmerForApp")]
        public static async Task WarmerForApp([TimerTrigger("0 6-23/1 * * *")] TimerInfo timer)
        {
            string msg;
            try {

                string api = "api/App/Start/";

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
        
        [Function("WarmerForUI")]
        public static async Task WarmerForUI([TimerTrigger("0 6-23/1 * * *")] TimerInfo timer)
        {
            string msg;
            try {

                HttpClient httpClient = new();
                HttpRequestMessage request = new() {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(AppConstants.NBAUnderdogLeagueUIURL),
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
