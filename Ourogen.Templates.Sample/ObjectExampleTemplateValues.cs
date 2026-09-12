namespace Ourogen.Templates.Sample
{
    internal class ObjectExampleTemplateValues : ObjectExampleTemplateRenderer.ITemplateValues
    {
        public static readonly ObjectExampleTemplateRenderer.ITemplateValues Instance =
            new ObjectExampleTemplateValues();
        
        private ObjectExampleTemplateValues()
        {
        }
        
        public ObjectExampleTemplateRenderer.IObject Object => ExampleObject.Instance;
        public ObjectExampleTemplateRenderer.IForEachObjects[] ForEachObjects => ExampleObjects.Instances;

        private class ExampleObject : ObjectExampleTemplateRenderer.IObject
        {
            public static readonly ObjectExampleTemplateRenderer.IObject Instance = new ExampleObject();

            private ExampleObject()
            {
                this.ReplaceText = "Example object text";
                this.True = true;
                this.False = false;
            }

            public string ReplaceText { get; set; }

            public bool True { get; set; }

            public bool False { get; set; }
        }

        private class ExampleObjects : ObjectExampleTemplateRenderer.IForEachObjects
        {
            public static readonly ObjectExampleTemplateRenderer.IForEachObjects[] Instances =
            {
                new ExampleObjects("int", "ExampleInt", "123"),
                new ExampleObjects("string", "ExampleString", "\"Example String\""),
                new ExampleObjects("bool", "ExampleBool", "true")
            };

            private ExampleObjects(string type, string name, string value)
            {
                this.Type = type;
                this.Name = name;
                this.Value = value;
            }

            public string Type { get; set; }

            public string Name { get; set; }
            
            public string Value { get; set; }
        }
    }
}