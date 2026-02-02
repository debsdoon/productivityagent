using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace ProductivityAgent.Plugins
{
    public class BitbucketPlugin
    {
        [KernelFunction, Description("Gets the open pull requests for a repository.")]
        public string GetPullRequests([Description("The repository name")] string repoName)
        {
            // Mock data
            return $"[{{\"id\":10, \"title\":\"Feature: Login\", \"author\":\"User\", \"repo\":\"{repoName}\", \"status\":\"OPEN\"}}, " +
                   $"{{\"id\":11, \"title\":\"Fix: Typo\", \"author\":\"Teammate\", \"repo\":\"{repoName}\", \"status\":\"OPEN\"}}]";
        }

        [KernelFunction, Description("Gets the recent commit activity for the current user.")]
        public string GetUserActivity()
        {
            // Mock data
            return "[{\"hash\":\"a1b2c3\", \"message\":\"Added login logic\", \"timestamp\":\"2023-10-27T10:00:00Z\"}, " +
                   "{\"hash\":\"d4e5f6\", \"message\":\"Updated README\", \"timestamp\":\"2023-10-27T14:30:00Z\"}]";
        }
        
        [KernelFunction, Description("Gets the number of lines of code committed by the user today.")]
        public string GetDailyLinesOfCode()
        {
             return "{\"linesAdded\": 150, \"linesDeleted\": 30}";
        }
    }
}
