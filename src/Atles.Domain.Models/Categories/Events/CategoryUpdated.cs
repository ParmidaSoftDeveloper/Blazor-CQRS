﻿using System;
using Atles.Infrastructure.Events;

namespace Atles.Domain.Models.Categories.Events
{
    /// <summary>
    /// Event published when a category is updated
    /// </summary>
    public class CategoryUpdated : EventBase
    {
        /// <summary>
        /// The new name of the category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The new identifier of the permission set of the category
        /// </summary>
        public Guid PermissionSetId { get; set; }
    }
}