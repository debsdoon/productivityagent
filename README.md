# Productivity Agent

A Semantic Kernel-powered console application that helps track development team productivity by integrating with Jira and Bitbucket.

## Features

- **Jira Integration**: Retrieves task assignments, status, and project issues (Simulated).
- **Bitbucket Integration**: Retrieves pull requests, commit history, and code stats (Simulated).
- **AI-Powered Insights**: Uses OpenAI (GPT-4o) to analyze data and answer natural language queries about team performance.

## Prerequisites

- .NET 8.0 SDK or later
- OpenAI API Key

## Getting Started

1.  **Clone the repository** included in `c:/devendra/learning/agenticmicrisoft/antigravity`
2.  **Navigate to the project folder:**
    ```bash
    cd ProductivityAgent
    ```
3.  **Set your OpenAI API Key:**
    ```powershell
    $env:OPENAI_API_KEY="your-api-key-here"
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```

## Usage

Once running, you can ask questions like:
- "What are my high priority tasks?"
- "Summarize the pull requests for the backend repo."
- "Am I blocked on anything?"

## Plugins

- **JiraPlugin**: Located in `Plugins/JiraPlugin.cs`
- **BitbucketPlugin**: Located in `Plugins/BitbucketPlugin.cs`

## License

MIT
