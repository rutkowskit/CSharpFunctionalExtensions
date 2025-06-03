using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var code = File.ReadAllText(@"E:\Projects\Contributions\CSharpFunctionalExtensions\CSharpFunctionalExtensions\Result\Methods\Extensions\Compensate.Task.cs", Encoding.UTF8);

var tree = CSharpSyntaxTree.ParseText(code);
var root = (CompilationUnitSyntax)tree.GetRoot();
var newRoot = new MethodByTypeRemover("UnitResult").Visit(root);


var methods = root.DescendantNodes()
    .OfType<MethodDeclarationSyntax>();

// List to store matching method names
var matchingMethods = new List<string>();

foreach (var method in methods)
{
    // Check if return type is string
    bool returnsString = method.ReturnType.ToString().Contains("UnitResult");

    // Check if any parameter is string
    bool hasStringParameter = method.ParameterList.Parameters
        .Any(param => param.Type?.ToString()?.Contains("UnitResult") ?? false);

    // Add method name if it matches criteria
    if (returnsString || hasStringParameter)
    {
        matchingMethods.Add(method.Identifier.Text);
    }
}
foreach (var methodName in matchingMethods)
{
    Console.WriteLine(methodName);
}

Console.WriteLine("Done");


class MethodByTypeRemover : CSharpSyntaxRewriter
{
    private readonly string _typeNamePattern;
    public MethodByTypeRemover(string typeNamePattern)
    {
        _typeNamePattern = typeNamePattern;
    }
    public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        // Check if return type is string
        bool returnsString = MatchesTypeName(node.ReturnType);

        // Check if any parameter is string
        bool hasStringParameter = node.ParameterList.Parameters
            .Any(param => MatchesTypeName(param.Type));

        // If the method returns string or has a string parameter, remove it (return null)
        if (returnsString || hasStringParameter)
        {
            return null; // Returning null removes the node
        }

        // Otherwise, keep the method unchanged
        return base.VisitMethodDeclaration(node);
    }
    private bool MatchesTypeName(TypeSyntax? type)
    {
        return type is not null && Regex.IsMatch(type.ToString(), _typeNamePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
    }
}
