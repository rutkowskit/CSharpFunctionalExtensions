using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;



const string CodeDirectory = @"E:\Projects\Contributions\CSharpFunctionalExtensions\CSharpFunctionalExtensions";

var fileEnumerator = Directory.EnumerateFiles(CodeDirectory, "*.cs", SearchOption.AllDirectories);
//var rewriter = new MethodByTypeRemover("UnitResult");
var rewriter = new AddIErrorConstraintRewriter();

foreach (var file in fileEnumerator)
{
    var code = File.ReadAllText(file, Encoding.UTF8);

    var tree = CSharpSyntaxTree.ParseText(code);
    var root = (CompilationUnitSyntax)tree.GetRoot();

    var newRoot = rewriter.Visit(root);
    if (rewriter.ChangesCount > 0)
    {
        Console.WriteLine($"File: {Path.GetFileName(file)}. Removed: {rewriter.ChangesCount}");
        var newCode = newRoot.ToFullString();
        File.WriteAllText(file, newCode, Encoding.UTF8);
    }
}

Console.WriteLine("Done");


class AddIErrorConstraintRewriter : CSharpSyntaxRewriter
{
    private const string ErrorInterfaceName = "IError";
    private static readonly HashSet<string> ErrorTypeParametersSymbols = ["E", "E2"];
    private volatile int _removedCount;

    public int ChangesCount => _removedCount;

    public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        // Skip if the method is not generic
        if (node.TypeParameterList == null)
        {
            return base.VisitMethodDeclaration(node);
        }

        // Check if the method has a type parameter named "E"
        var errorTypeParameters = node.TypeParameterList.Parameters
            .Where(tp => ErrorTypeParametersSymbols.Contains(tp.Identifier.Text))
            .ToArray();

        if (errorTypeParameters.Length == 0)
        {
            return base.VisitMethodDeclaration(node);
        }

        var updatedMethod = node;
        var iErrorType = SyntaxFactory.ParseTypeName(ErrorInterfaceName);
        var constraintClauses = node.ConstraintClauses;

        foreach (var tp in errorTypeParameters)
        {

            var genericTypeName = tp.Identifier.Text;
            var eConstraint = constraintClauses.FirstOrDefault(cc => cc.Name.Identifier.Text == genericTypeName);

            bool hasIErrorConstraint = eConstraint != null && eConstraint.Constraints.Any(c =>
                c is TypeConstraintSyntax tcs && tcs.Type.ToString() == ErrorInterfaceName);

            if (hasIErrorConstraint)
            {
                continue;
            }

            // Create the new "where E. : IError" constraint
            var newConstraint = SyntaxFactory.TypeConstraint(iErrorType);
            var newConstraintClause = SyntaxFactory
                .TypeParameterConstraintClause(SyntaxFactory.IdentifierName(genericTypeName))
                .AddConstraints(newConstraint)
                .NormalizeWhitespace(); // Ensure proper spacing in the constraint clause;

            // Add or update the constraint clauses
            var updatedConstraintClauses = eConstraint == null
                ? constraintClauses.Add(newConstraintClause)
                : constraintClauses.Replace(eConstraint, eConstraint.AddConstraints(newConstraint));

            // Update the method with the new constraint clauses
            updatedMethod = updatedMethod.WithConstraintClauses(updatedConstraintClauses);
            Interlocked.Increment(ref _removedCount);
        }

        return updatedMethod;
    }
}



class MethodByTypeRemover : CSharpSyntaxRewriter
{
    private readonly string _typeNamePattern;
    private volatile int _removedCount;
    public MethodByTypeRemover(string typeNamePattern)
    {
        _typeNamePattern = typeNamePattern;
    }
    public int ChangesCount => _removedCount;
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
            Interlocked.Increment(ref _removedCount);
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
