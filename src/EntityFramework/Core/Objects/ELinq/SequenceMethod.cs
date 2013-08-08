// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.Core.Objects.ELinq
{
    /// <summary>
    /// Enumeration of known extension methods
    /// </summary>
    internal enum SequenceMethod
    {
        Where,
        WhereOrdinal,
        OfType,
        Cast,
        Select,
        SelectOrdinal,
        SelectMany,
        SelectManyOrdinal,
        SelectManyResultSelector,
        SelectManyOrdinalResultSelector,
        Join,
        JoinComparer,
        GroupJoin,
        GroupJoinComparer,
        OrderBy,
        OrderByComparer,
        OrderByDescending,
        OrderByDescendingComparer,
        ThenBy,
        ThenByComparer,
        ThenByDescending,
        ThenByDescendingComparer,
        Take,
        TakeWhile,
        TakeWhileOrdinal,
        Skip,
        SkipWhile,
        SkipWhileOrdinal,
        GroupBy,
        GroupByComparer,
        GroupByElementSelector,
        GroupByElementSelectorComparer,
        GroupByResultSelector,
        GroupByResultSelectorComparer,
        GroupByElementSelectorResultSelector,
        GroupByElementSelectorResultSelectorComparer,
        Distinct,
        DistinctComparer,
        Concat,
        Union,
        UnionComparer,
        Intersect,
        IntersectComparer,
        Except,
        ExceptComparer,
        First,
        FirstPredicate,
        FirstOrDefault,
        FirstOrDefaultPredicate,
        Last,
        LastPredicate,
        LastOrDefault,
        LastOrDefaultPredicate,
        Single,
        SinglePredicate,
        SingleOrDefault,
        SingleOrDefaultPredicate,
        ElementAt,
        ElementAtOrDefault,
        DefaultIfEmpty,
        DefaultIfEmptyValue,
        Contains,
        ContainsComparer,
        Reverse,
        Empty,
        SequenceEqual,
        SequenceEqualComparer,

        Any,
        AnyPredicate,
        All,

        Count,
        CountPredicate,
        LongCount,
        LongCountPredicate,

        Min,
        MinSelector,
        Max,
        MaxSelector,

        MinInt,
        MinNullableInt,
        MinLong,
        MinNullableLong,
        MinDouble,
        MinNullableDouble,
        MinDecimal,
        MinNullableDecimal,
        MinSingle,
        MinNullableSingle,
        MinIntSelector,
        MinNullableIntSelector,
        MinLongSelector,
        MinNullableLongSelector,
        MinDoubleSelector,
        MinNullableDoubleSelector,
        MinDecimalSelector,
        MinNullableDecimalSelector,
        MinSingleSelector,
        MinNullableSingleSelector,

        MaxInt,
        MaxNullableInt,
        MaxLong,
        MaxNullableLong,
        MaxDouble,
        MaxNullableDouble,
        MaxDecimal,
        MaxNullableDecimal,
        MaxSingle,
        MaxNullableSingle,
        MaxIntSelector,
        MaxNullableIntSelector,
        MaxLongSelector,
        MaxNullableLongSelector,
        MaxDoubleSelector,
        MaxNullableDoubleSelector,
        MaxDecimalSelector,
        MaxNullableDecimalSelector,
        MaxSingleSelector,
        MaxNullableSingleSelector,

        SumInt,
        SumNullableInt,
        SumLong,
        SumNullableLong,
        SumDouble,
        SumNullableDouble,
        SumDecimal,
        SumNullableDecimal,
        SumSingle,
        SumNullableSingle,
        SumIntSelector,
        SumNullableIntSelector,
        SumLongSelector,
        SumNullableLongSelector,
        SumDoubleSelector,
        SumNullableDoubleSelector,
        SumDecimalSelector,
        SumNullableDecimalSelector,
        SumSingleSelector,
        SumNullableSingleSelector,

        AverageInt,
        AverageNullableInt,
        AverageLong,
        AverageNullableLong,
        AverageDouble,
        AverageNullableDouble,
        AverageDecimal,
        AverageNullableDecimal,
        AverageSingle,
        AverageNullableSingle,
        AverageIntSelector,
        AverageNullableIntSelector,
        AverageLongSelector,
        AverageNullableLongSelector,
        AverageDoubleSelector,
        AverageNullableDoubleSelector,
        AverageDecimalSelector,
        AverageNullableDecimalSelector,
        AverageSingleSelector,
        AverageNullableSingleSelector,

        Aggregate,
        AggregateSeed,
        AggregateSeedSelector,

        AsQueryable,
        AsQueryableGeneric,
        AsEnumerable,

        ToList,

        Zip,

        NotSupported,
    }
}
