using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TestProjectCompilation
{
    class Program
    {
        private const string ProjectPath =
            @"C:\AUT\SampleCodeBaseForComparingMockingFrameworks\Sample.ClassLib\Sample.ClassLib.csproj";
            // @"C:\AUT\avolin-coretrac\Code\ResourceOne\BusinessEntities\DataObjects.csproj";

            private const string FilePath =
                @"C:\AUT\SampleCodeBaseForComparingMockingFrameworks\Sample.ClassLib\Class1.cs";
            //@"C:\AUT\avolin-coretrac\Code\ResourceOne\BusinessEntities\DAOEvent.cs";


        static void Main(string[] args)
        {
            // in Main2
            var references = GetReferences(ProjectPath);

            var code = File.ReadAllText(FilePath);
            var tree = SyntaxFactory.ParseSyntaxTree(code);

            var compilation = CreateCompilation(tree, references);
            var model = compilation.GetSemanticModel(tree);


            // Test against Class1.cs
            var invocationExpressionSyntaxes = compilation.SyntaxTrees.First().GetRoot().DescendantNodes()
                .OfType<InvocationExpressionSyntax>();

            var invocationExpressionSyntax = invocationExpressionSyntaxes.First();
            var argumentTypes = invocationExpressionSyntax.ArgumentList.Arguments.Select(a => a.ChildNodes().First())
                .Select(node => model.GetTypeInfo(node)).ToList();
            var argumentTypeNames = argumentTypes.Select(c => c.ConvertedType.ToString());
        }

        private static CSharpCompilation CreateCompilation(SyntaxTree tree, IEnumerable<string> references)
        {
            var options = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary);

            var compilation =
                CSharpCompilation.Create("test")
                    .WithOptions(options)
                    .AddSyntaxTrees(tree)
                    .AddReferences(references.Select(path => MetadataReference.CreateFromFile(path)));
            return compilation;
        }

        private static IEnumerable<string> GetReferences(string projectFileName)
        {
            var logger = new BasicLogger();
            var projectCollection = new ProjectCollection();
            var buildParameters = new BuildParameters(projectCollection);
            buildParameters.Loggers = new List<Microsoft.Build.Framework.ILogger>() { logger };
            var globalProperty = new Dictionary<String, String>();
            globalProperty.Add("SolutionDir", @"C:\temp");
            BuildManager.DefaultBuildManager.ResetCaches();
            var buildRequest = new BuildRequestData(projectFileName, globalProperty, null,
                new String[] { "ResolveProjectReferences", "ResolveAssemblyReferences" }, null);
            var result = BuildManager.DefaultBuildManager.Build(buildParameters, buildRequest);
            if (result.OverallResult == BuildResultCode.Failure)
            {
                Console.WriteLine(logger.GetLogString());
                // catch build errors
            }

            IEnumerable<string> GetResultItems(string targetName)
            {
                var buildResult = result.ResultsByTarget[targetName];
                var buildResultItems = buildResult.Items;

                return buildResultItems.Select(item => item.ItemSpec);
            }

            return GetResultItems("ResolveProjectReferences")
                .Concat(GetResultItems("ResolveAssemblyReferences"));
        }
    }
}
