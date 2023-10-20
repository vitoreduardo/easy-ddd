// <copyright file="IAggregateRoot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EasyDDD.SharedKernel.Interfaces
{
    /// <summary>
    /// Apply this marker interface only to aggregate root entities.
    /// Repositories will only work with aggregate roots, not their children.
    /// </summary>
    public interface IAggregateRoot
    {
    }
}
