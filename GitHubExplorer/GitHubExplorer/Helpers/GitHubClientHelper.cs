using GitHubExplorer.Interfaces;
using GitHubExplorer.Models;
using GitHubExplorer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Helpers
{
    /// <summary>
    /// A client API Helper for the Github Repository Hosting client
    /// </summary>
    public class GitHubClientHelper : IRepoHostingClient
    {
        // Using a seperate httpclient per repository client
        private readonly HttpClient _httpClient = new HttpClient();

        private const string GitHub_USER_URL = "https://api.github.com/users/{0}";
        private const string GitHub_REPOS_URL = "https://api.github.com/users/{0}/repos";

        private ILogger _logger;

        public GitHubClientHelper(ILogger logger)
        {
            _httpClient.DefaultRequestHeaders.Add(Constants.HTTP_USERAGENT_HEADER_KEY, Constants.HTTP_USERAGENT_HEADER_VALUE);
            // using gzip for performance
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(Constants.HTTP_ACCEPTENCODING_GZIP));
            _logger = logger;
        }

        public async Task<User> GetUserInfoByUserName(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync(string.Format(GitHub_USER_URL, username));
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // Using stream to deserialize instead of converting whole string for performance 
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var json = new JsonTextReader(reader))
                    {
                        return serializer.Deserialize<User>(json);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                _logger.Error("Error while fetching data ", ex.ToString());
                return null;
            }
        }

        public async Task<Repository[]> GetRepositoriesByUserNameAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync(string.Format(GitHub_REPOS_URL, username));
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // Using stream to deserialize instead of converting whole string for performance 
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var json = new JsonTextReader(reader))
                    {
                        return serializer.Deserialize<Repository[]>(json);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error while fetching data ", ex.ToString());
                return null;
            }
        }
    }
}
