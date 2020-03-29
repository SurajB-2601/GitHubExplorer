using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Interfaces
{
    public interface ILogManager
    {
        ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath]string callerFilePath = "");
    }
}
