namespace OnyxPigment.Helper
{
    public static class TemplateEngineHelper
    {
        public static string Render(string templatePath, Dictionary<string, string> data)
        {
            string content = File.ReadAllText(templatePath);

            foreach (var item in data)
            {
                string placeholder = $"{{{{{item.Key}}}}}"; // e.g., {{Name}}
                content = content.Replace(placeholder, item.Value);
            }

            return content;
        }

    }
}
