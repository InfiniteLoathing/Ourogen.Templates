using Microsoft.CodeAnalysis;

namespace Ourogen.Templates.Sample
{
    [Generator]
    internal class Generator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            #if RENDER_TEMPLATES
            context.RegisterPostInitializationOutput(ctx =>
            {
                ctx.AddSource(
                    "EmptyExampleTemplate.cs",
                    EmptyExampleTemplateRenderer.Render());
                ctx.AddSource(
                    "ExampleTemplate.cs",
                    ExampleTemplateRenderer.Render(ExampleTemplateValues.Instance));
                ctx.AddSource(
                    "ObjectExampleTemplate.cs",
                    ObjectExampleTemplateRenderer.Render(ObjectExampleTemplateValues.Instance));
            });
            #endif
        }
    }
}