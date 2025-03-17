namespace ChatBot.Controllers
{
    internal class OpenAIAPI
    {
        private string? apiKey;

        public OpenAIAPI(string? apiKey)
        {
            this.apiKey = apiKey;
        }

        public object Completions { get; internal set; }
    }
}