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
                    $"{nameof(EmptyExampleTemplate)}.cs",
                    EmptyExampleTemplateRenderer.Render());
                ctx.AddSource(
                    $"{nameof(ExampleTemplate)}.cs",
                    ExampleTemplateRenderer.Render(ExampleTemplateValues.Instance));
                ctx.AddSource(
                    $"{nameof(ObjectExampleTemplate)}.cs",
                    ObjectExampleTemplateRenderer.Render(ObjectExampleTemplateValues.Instance));
            });
            #endif
        }
    }
}