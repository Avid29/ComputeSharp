using System;
using ComputeSharp.D2D1.__Internals;
using ComputeSharp.D2D1.SourceGenerators.Models;
using ComputeSharp.SourceGeneration.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

#pragma warning disable CS0618

namespace ComputeSharp.D2D1.SourceGenerators;

/// <inheritdoc/>
partial class ID2D1ShaderGenerator
{
    /// <inheritoc/>
    private static partial class ResourceTextureDescriptions
    {
        /// <summary>
        /// Creates a <see cref="PropertyDeclarationSyntax"/> instance for the <c>ResourceTextureDescriptions</c> property.
        /// </summary>
        /// <param name="resourceTextureDescriptions">The resource texture descriptions info gathered for the current shader.</param>
        /// <param name="additionalDataMembers">Any additional <see cref="MemberDeclarationSyntax"/> instances needed by the generated code, if needed.</param>
        /// <returns>The resulting <see cref="PropertyDeclarationSyntax"/> instance for the <c>ResourceTextureDescriptions</c> property.</returns>
        public static PropertyDeclarationSyntax GetSyntax(EquatableArray<ResourceTextureDescription> resourceTextureDescriptions, out MemberDeclarationSyntax[] additionalDataMembers)
        {
            ExpressionSyntax memoryExpression;

            // If there are no resource texture descriptions, just return a default expression.
            // Otherwise, declare the shared array and return it from the property.
            if (resourceTextureDescriptions.Length == 0)
            {
                memoryExpression = LiteralExpression(SyntaxKind.DefaultLiteralExpression, Token(SyntaxKind.DefaultKeyword));
                additionalDataMembers = Array.Empty<MemberDeclarationSyntax>();
            }
            else
            {
                memoryExpression = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName("Data"),
                    IdentifierName(nameof(ResourceTextureDescriptions)));

                additionalDataMembers = new[] { GetArrayDeclaration(resourceTextureDescriptions) };
            }

            // This code produces a method declaration as follows:
            //
            // readonly global::System.ReadOnlyMemory<global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription> global::ComputeSharp.D2D1.__Internals.ID2D1Shader.ResourceTextureDescriptions => <EXPRESSION>;
            return
                PropertyDeclaration(
                    GenericName(Identifier("global::System.ReadOnlyMemory"))
                    .AddTypeArgumentListArguments(IdentifierName("global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription")),
                    Identifier(nameof(ResourceTextureDescriptions)))
                .WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier(IdentifierName($"global::ComputeSharp.D2D1.__Internals.{nameof(ID2D1Shader)}")))
                .AddModifiers(Token(SyntaxKind.ReadOnlyKeyword))
                .WithExpressionBody(ArrowExpressionClause(memoryExpression))
                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>
        /// Gets the array declaration for the given resource texture descriptions.
        /// </summary>
        /// <param name="resourceTextureDescriptions">The resource texture descriptions info gathered for the current shader.</param>
        /// <returns>The array declaration for the given resource texture descriptions.</returns>
        private static MemberDeclarationSyntax GetArrayDeclaration(EquatableArray<ResourceTextureDescription> resourceTextureDescriptions)
        {
            using ImmutableArrayBuilder<ExpressionSyntax> resourceTextureDescriptionExpressions = ImmutableArrayBuilder<ExpressionSyntax>.Rent();

            foreach (ResourceTextureDescription resourceTextureDescription in resourceTextureDescriptions)
            {
                // Create the description expression:
                //
                // new(<INDEX>, <RANK>)
                resourceTextureDescriptionExpressions.Add(
                    ImplicitObjectCreationExpression()
                    .AddArgumentListArguments(
                        Argument(LiteralExpression(
                            SyntaxKind.NumericLiteralExpression,
                            Literal(resourceTextureDescription.Index))),
                        Argument(LiteralExpression(
                            SyntaxKind.NumericLiteralExpression,
                            Literal(resourceTextureDescription.Rank)))));
            }

            // Declare the singleton property to get the memory instance:
            //
            // /// <summary>The singleton <see cref="global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription"/> array instance.</summary>
            // public static readonly global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription[] ResourceTextureDescriptions = { <RESOURCE_TEXTURE_DESCRIPTIONS> };
            return
                FieldDeclaration(
                    VariableDeclaration(
                        ArrayType(IdentifierName("global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription"))
                        .AddRankSpecifiers(ArrayRankSpecifier(SingletonSeparatedList<ExpressionSyntax>(OmittedArraySizeExpression()))))
                    .AddVariables(
                        VariableDeclarator(Identifier(nameof(ResourceTextureDescriptions)))
                        .WithInitializer(EqualsValueClause(
                            InitializerExpression(SyntaxKind.ArrayInitializerExpression)
                            .AddExpressions(resourceTextureDescriptionExpressions.ToArray())))))
                .AddModifiers(
                    Token(SyntaxKind.PublicKeyword),
                    Token(SyntaxKind.StaticKeyword),
                    Token(SyntaxKind.ReadOnlyKeyword))
                .WithLeadingTrivia(Comment("""/// <summary>The singleton <see cref="global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription"/> array instance.</summary>"""));
        }
    }
}