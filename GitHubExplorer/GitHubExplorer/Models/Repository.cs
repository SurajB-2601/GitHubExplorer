using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// The DTO for Repository
    /// </summary>
    public class Repository
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool _private { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string git_tags_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string git_url { get; set; }
        public string ssh_url { get; set; }
        public string clone_url { get; set; }
        public string homepage { get; set; }
        public int stargazers_count { get; set; }
        public string language { get; set; }
        public bool has_issues { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public int forks_count { get; set; }
        public object mirror_url { get; set; }
        public bool archived { get; set; }
        public bool disabled { get; set; }
        public License license { get; set; }
        public int forks { get; set; }
        public int open_issues { get; set; }
        public string default_branch { get; set; }
    }

    public class License
    {
        public string key { get; set; }
        public string name { get; set; }
        public string spdx_id { get; set; }
        public string url { get; set; }
        public string node_id { get; set; }
    }

}
