// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.Core.Common.CommandTrees
{
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Utilities;
    using System.Diagnostics;

    /// <summary>Represents an expression that extracts a reference from the underlying entity instance. This class cannot be inherited.  </summary>
    public sealed class DbEntityRefExpression : DbUnaryExpression
    {
        internal DbEntityRefExpression(TypeUsage refResultType, DbExpression entity)
            : base(DbExpressionKind.EntityRef, refResultType, entity)
        {
            Debug.Assert(TypeSemantics.IsReferenceType(refResultType), "DbEntityRefExpression requires a reference result type");
        }

        /// <summary>Implements the visitor pattern for expressions that do not produce a result value.</summary>
        /// <param name="visitor">
        /// An instance of <see cref="T:System.Data.Entity.Core.Common.CommandTrees.DbExpressionVisitor" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException"> visitor  is null.</exception>
        public override void Accept(DbExpressionVisitor visitor)
        {
            Check.NotNull(visitor, "visitor");

            visitor.Visit(this);
        }

        /// <summary>Implements the visitor pattern for expressions that produce a result value of a specific type.</summary>
        /// <returns>
        /// A result value of a specific type produced by
        /// <see
        ///     cref="T:System.Data.Entity.Core.Common.CommandTrees.DbExpressionVisitor" />
        /// .
        /// </returns>
        /// <param name="visitor">
        /// An instance of a typed <see cref="T:System.Data.Entity.Core.Common.CommandTrees.DbExpressionVisitor" /> that produces a result value of a specific type.
        /// </param>
        /// <typeparam name="TResultType">The type of the result produced by  visitor. </typeparam>
        /// <exception cref="T:System.ArgumentNullException"> visitor  is null.</exception>
        public override TResultType Accept<TResultType>(DbExpressionVisitor<TResultType> visitor)
        {
            Check.NotNull(visitor, "visitor");

            return visitor.Visit(this);
        }
    }
}
