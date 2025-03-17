# AI-ChatBot
A chatbot application built with ASP.NET Core MVC that integrates OpenAI GPT models (GPT-4, GPT-3.5, GPT-3 - Davinci, Curie, Babbage, Ada) to generate AI responses. This project supports user input handling, API rate limit management, error handling, and retry logic.
<br>
Supports multiple OpenAI models (GPT-4, GPT-3.5, GPT-3) <br>
Handles API rate limits and errors gracefully <br>
Implements HTTP request/response handling with HttpClient <br>
Displays AI-generated responses dynamically <br>
Exponential backoff for retrying failed requests <br>
Simple UI with user input field and AI-generated responses <br>

Tech Stack
Backend: ASP.NET Core MVC, C#
Frontend: HTML, CSS, JavaScript
API: OpenAI API
Data Format: JSON
<br>
Ensure you have .NET SDK (Core or later) installed. You can check by running: <br>
dotnet --version
<br>
Configure OpenAI API Key
Get an OpenAI API key from OpenAI's website.
Add your API key in appsettings.json: 
<br>
{
  "OpenAISettings": {
    "ApiKey": "your-openai-api-key"
  }
}
