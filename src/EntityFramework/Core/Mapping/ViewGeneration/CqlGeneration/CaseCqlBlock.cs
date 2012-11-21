// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.Core.Mapping.ViewGeneration.CqlGeneration
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Common.CommandTrees;
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.Data.Entity.Core.Common.Utils;
    using System.Data.Entity.Core.Mapping.ViewGeneration.Structures;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    ///     A class to capture cql blocks responsible for case statements generating multiconstants, i.e., complex types, entities, discriminators, etc.
    /// </summary>
    internal sealed class CaseCqlBlock : CqlBlock
    {
        /// <summary>
        ///     Creates a <see cref="CqlBlock" /> containing the case statememt for the <paramref name="caseSlot" /> and projecting other slots as is from its child (input). CqlBlock with SELECT (slots),
        /// </summary>
        /// <param name="caseSlot"> indicates which slot in <paramref name="slots" /> corresponds to the case statement being generated by this block </param>
        internal CaseCqlBlock(
            SlotInfo[] slots, int caseSlot, CqlBlock child, BoolExpression whereClause, CqlIdentifiers identifiers, int blockAliasNum)
            : base(slots, new List<CqlBlock>(new[] { child }), whereClause, identifiers, blockAliasNum)
        {
            m_caseSlotInfo = slots[caseSlot];
        }

        private readonly SlotInfo m_caseSlotInfo;

        internal override StringBuilder AsEsql(StringBuilder builder, bool isTopLevel, int indentLevel)
        {
            // The SELECT part
            StringUtil.IndentNewLine(builder, indentLevel);
            builder.Append("SELECT ");
            if (isTopLevel)
            {
                builder.Append("VALUE ");
            }
            Debug.Assert(m_caseSlotInfo.OutputMember != null, "We only construct member slots, not boolean slots.");
            builder.Append("-- Constructing ").Append(m_caseSlotInfo.OutputMember.LeafName);

            Debug.Assert(Children.Count == 1, "CaseCqlBlock can have exactly one child.");
            var childBlock = Children[0];

            base.GenerateProjectionEsql(builder, childBlock.CqlAlias, true, indentLevel, isTopLevel);

            // The FROM part: FROM (ChildView) AS AliasName
            builder.Append("FROM (");
            childBlock.AsEsql(builder, false, indentLevel + 1);
            StringUtil.IndentNewLine(builder, indentLevel);
            builder.Append(") AS ").Append(childBlock.CqlAlias);

            // Get the WHERE part only when the expression is not simply TRUE.
            if (false == BoolExpression.EqualityComparer.Equals(WhereClause, BoolExpression.True))
            {
                StringUtil.IndentNewLine(builder, indentLevel);
                builder.Append("WHERE ");
                WhereClause.AsEsql(builder, childBlock.CqlAlias);
            }

            return builder;
        }

        internal override DbExpression AsCqt(bool isTopLevel)
        {
            Debug.Assert(m_caseSlotInfo.OutputMember != null, "We only construct real slots not boolean slots");

            // The FROM part: FROM (childBlock)
            Debug.Assert(Children.Count == 1, "CaseCqlBlock can have exactly one child.");
            var childBlock = Children[0];
            var cqt = childBlock.AsCqt(false);

            // Get the WHERE part only when the expression is not simply TRUE.
            if (!BoolExpression.EqualityComparer.Equals(WhereClause, BoolExpression.True))
            {
                cqt = cqt.Where(row => WhereClause.AsCqt(row));
            }

            // The SELECT part.
            return cqt.Select(row => GenerateProjectionCqt(row, isTopLevel));
        }
    }
}
