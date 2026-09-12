namespace Ourogen.Templates.Sample
{
    internal class ExampleTemplateValues : ExampleTemplateRenderer.ITemplateValues
    {
        public static ExampleTemplateValues Instance = new ExampleTemplateValues();
        
        private ExampleTemplateValues()
        {
            this.ReplaceText = "This text was replaced";
            this.True = true;
            this.False = false;
            this.ForEachTexts = new[] { "First replacement", "Second replacement", "Third replacement" };
        }
        
        public string ReplaceText { get; }
        public bool True { get; }
        public bool False { get; }
        public string[] ForEachTexts { get; }
    }
}