using Microsoft.Extensions.Logging;
using OllamaSharp;

namespace AITerminal.HybridUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		// Register OllamaApiClient in DI
		// builder.Services.AddSingleton(sp =>
		// {
		//     var uri = new Uri("http://localhost:11434"); // or 11411, whichever port your Ollama is on
		//     var ollamaClient = new OllamaApiClient(uri);
		//     // Optionally select a default model to use:
		//     ollamaClient.SelectedModel = "deepseek-coder-v2:latest";
		//     return ollamaClient;
		// });

		return builder.Build();
	}
}
