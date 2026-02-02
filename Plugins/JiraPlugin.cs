using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace ProductivityAgent.Plugins
{
    public class JiraPlugin
    {
        [KernelFunction, Description("Gets the list of Jira issues assigned to the current user.")]
        public string GetMyTasks()
        {
            // Mock data
            return "[{\"id\":\"PROJ-101\", \"summary\":\"Implement Login\", \"status\":\"In Progress\", \"assignee\":\"User\"}, " +
                   "{\"id\":\"PROJ-102\", \"summary\":\"Fix CSS Bug\", \"status\":\"To Do\", \"assignee\":\"User\"}]";
        }

        [KernelFunction, Description("Gets the list of issues for a specific project.")]
        public string GetProjectIssues([Description("The project key, e.g., PROJ")] string projectKey)
        {
            // Mock data
            return $"[{{\"id\":\"{projectKey}-101\", \"summary\":\"Implement Login\", \"status\":\"In Progress\"}}, " +
                   $"{{\"id\":\"{projectKey}-103\", \"summary\":\"Database Schema\", \"status\":\"Done\"}}]";
        }

        [KernelFunction, Description("Gets the details of a specific Jira issue.")]
        public string GetIssueDetails([Description("The issue key, e.g., PROJ-101")] string issueKey)
        {
            // Mock data
            return $"{{\"id\":\"{issueKey}\", \"summary\":\"Implement Login\", \"description\":\"Create login page using OAuth.\", \"status\":\"In Progress\", \"comments\":[\"Started working on it.\", \"Need DB access.\"]}}";
        }
    }
}
