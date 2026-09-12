using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Ourogen.Templates.Exceptions;
using Ourogen.Templates.Syntax;

namespace Ourogen.Templates
{
    [Generator]
    public class Generator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var syntaxTreeTemplates = context.SyntaxProvider
                .CreateSyntaxProvider(TemplateChecker.IsTemplate, (x, _) => x.Node);
            var additionalTextTemplates = context.AdditionalTextsProvider.Where(TemplateChecker.IsTemplate);

            context.RegisterSourceOutput(additionalTextTemplates, WriteTemplate);
            context.RegisterSourceOutput(syntaxTreeTemplates, WriteTemplate);
        }

        private static void WriteTemplate(SourceProductionContext context, SyntaxNode root)
        {
            if (!RootValidator.RegionsAreValid(root))
            {
                return;
            }
            
            var visitor = new GeneratorTemplateWalker();

            try
            {
                visitor.Visit(root);
                var createdTemplate = visitor.CreateTemplate(
                    @namespace: "Ourogen.Templates",
                    className: TemplateChecker.GetFileNameWithoutExtension(root.SyntaxTree.FilePath));
                var templateRender = createdTemplate.Render();
                context.AddSource(Path.GetFileName(root.SyntaxTree.FilePath), templateRender);
            }
            catch (InvalidTemplateException)
            {
            }
        }

        private static void WriteTemplate(SourceProductionContext context, AdditionalText template)
        {
            var sourceText = template.GetText(context.CancellationToken);

            if (sourceText is null)
            {
                return;
            }

            if (!CSharpSyntaxTree
                .ParseText(sourceText, cancellationToken: context.CancellationToken)
                .TryGetRoot(out var root))
            {
                return;
            }

            if (!RootValidator.RegionsAreValid(root))
            {
                return;
            }
            
            var visitor = new GeneratorTemplateWalker();

            try
            {
                visitor.Visit(root);
                var createdTemplate = visitor.CreateTemplate(
                    @namespace: "Ourogen.Templates",
                    className: TemplateChecker.GetFileNameWithoutExtension(template.Path));
                var templateRender = createdTemplate.Render();
                context.AddSource(Path.GetFileName(template.Path), templateRender);
            }
            catch (InvalidTemplateException)
            {
            }
        }
    }
}