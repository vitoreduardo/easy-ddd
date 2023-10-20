using System.Linq.Expressions;

namespace EasyDDD.SharedKernel.Interfaces
{
    /// <summary>
    /// Encapsulates query logic for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type being queried against.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the collection of criteria operations.
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the collection of include operations.
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Gets the collection of include string operations.
        /// </summary>
        List<string> IncludeStrings { get; }

        /// <summary>
        /// Gets the collection of OrderBy operations.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// Gets the collection of OrderBy Descending operations.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// Gets the collection of GroupBy operations.
        /// </summary>
        Expression<Func<T, object>> GroupBy { get; }

        /// <summary>
        /// Gets the Take operations.
        /// </summary>
        int Take { get; }

        /// <summary>
        /// Gets the Skip operations.
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Gets a value indicating whether paging is enabled.
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
