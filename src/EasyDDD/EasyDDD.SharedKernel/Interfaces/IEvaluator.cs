// <copyright file="IEvaluator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IEvaluator
    {
        bool IsCriteriaEvaluator { get; }

        IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class;
    }
}
