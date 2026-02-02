using System;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using ProductivityAgent.Plugins;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("--- Semantic Kernel Productivity Agent ---");

        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string modelId = Environment.GetEnvironmentVariable("OPENAI_MODEL_ID") ?? "gpt-4o";

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Please enter your OpenAI API Key:");
            apiKey = Console.ReadLine();
        }

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("API Key is required to run this application. Exiting.");
            return;
        }

        var builder = Kernel.CreateBuilder();

        // Add OpenAI Chat Completion
        builder.AddOpenAIChatCompletion(modelId, apiKey);

        // Add Plugins
        builder.Plugins.AddFromType<JiraPlugin>("Jira");
        builder.Plugins.AddFromType<BitbucketPlugin>("Bitbucket");

        var kernel = builder.Build();

        // Get Chat Completion Service
        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        // Enable auto function calling
        OpenAIPromptExecutionSettings openAiSettings = new() 
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
        };

        var history = new ChatHistory();
        history.AddSystemMessage("You are a helpful productivity assistant. You have access to Jira and Bitbucket plugins. " +
                                 "Use them to answer questions about tasks, issues, commits, and pull requests. " +
                                 "Always summarize the data you find in a concise implementation-focused manner.");

        Console.WriteLine("\nAgent is ready! Ask questions like 'What are my current tasks?' or 'Show me recent pull requests'.");
        Console.WriteLine("Type 'exit' to quit.\n");

        while (true)
        {
            Console.Write("User > ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput) || userInput.ToLower() == "exit")
            {
                break;
            }

            history.AddUserMessage(userInput);

            try
            {
                var result = await chatCompletionService.GetChatMessageContentAsync(
                    history,
                    executionSettings: openAiSettings,
                    kernel: kernel);

                Console.WriteLine($"\nAgent > {result}");
                history.AddAssistantMessage(result.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
