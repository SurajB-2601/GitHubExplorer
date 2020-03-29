using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.ViewModels
{
    /// <summary>
    /// The viewmodel which binds to a User view on the UI
    /// </summary>
    public class UserViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
    }
}
