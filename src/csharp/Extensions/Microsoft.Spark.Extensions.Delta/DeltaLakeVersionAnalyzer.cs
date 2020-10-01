using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Microsoft.Spark.Extensions.Delta
{
#pragma warning disable RS1004 // Recommend adding language support to diagnostic analyzer.
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
#pragma warning restore RS1004 // Recommend adding language support to diagnostic analyzer.
    class DeltaLakeVersionAnalyzer : DiagnosticAnalyzer
    {
        private string _deltaLakeVersion;

        private readonly DiagnosticDescriptor _descriptor = new DiagnosticDescriptor("DL404", "Mismatched Delta Lake version", "messageFormat", "Versioning", DiagnosticSeverity.Warning, true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => new ImmutableArray<DiagnosticDescriptor> { _descriptor };

        public override void Initialize(AnalysisContext context)
        {
            _deltaLakeVersion = Environment.GetEnvironmentVariable("DELTA_LAKE_VERSION");
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
        }

        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            context.ReportDiagnostic(Diagnostic.Create(_descriptor, context.Node.GetLocation()));
            if (!string.IsNullOrEmpty(_deltaLakeVersion))
            {
                foreach (AttributeData attribute in context.ContainingSymbol.GetAttributes())
                {
                    if (attribute.AttributeClass.Name == "Since")
                    {
                        string sinceVersion = (string)attribute.ConstructorArguments.First().Value;

                        context.ReportDiagnostic(Diagnostic.Create(_descriptor, context.Node.GetLocation()));
                    }
                }
            }
        }
    }
}
