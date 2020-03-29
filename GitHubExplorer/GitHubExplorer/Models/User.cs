using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// The DTO for a Git Repo User
    /// </summary>
    public class User
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string repos_url { get; set; }
        public string name { get; set; }
        public object company { get; set; }
        public string blog { get; set; }
        public string location { get; set; }
        public object email { get; set; }
        public object hireable { get; set; }
        public string bio { get; set; }
        public DateTime created_at { get; set; }
    }
}
