// <copyright file="IEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EasyDDD.SharedKernel.Interfaces
{
    /// <summary>
    /// Represent a Entity of TId.
    /// </summary>
    /// <typeparam name="TId">The Id type.</typeparam>
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
