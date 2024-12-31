using Microsoft.Extensions.DependencyInjection;
using Search.Infrastructure;
using Shared;

namespace Search.Application;

class Program
{
    static void Main(string[] args)
    {
        var pluginPath = @"C:\ElasticsearchPlugin.dll";
        var connectionString = "http://aaa:9200";

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<PluginManager>();
        serviceCollection.AddTransient<ISearchPlugin>(provider =>
        {
            var pluginManager = provider.GetRequiredService<PluginManager>();
            var plugin = pluginManager.LoadPlugin(pluginPath);
            plugin.Initialize(connectionString);
            return plugin;
        });
        serviceCollection.AddTransient<SearchService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var searchService = serviceProvider.GetRequiredService<SearchService>();

        try
        {
            Console.WriteLine("Enter search query:");
            var query = Console.ReadLine();

            var result = searchService.PerformSearch(query);
            Console.WriteLine($"Search result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            var pluginManager = serviceProvider.GetRequiredService<PluginManager>();
            pluginManager.UnloadPlugin();
        }
    }
}