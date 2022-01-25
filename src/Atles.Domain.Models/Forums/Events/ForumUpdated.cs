﻿using System;
using Atles.Infrastructure.Events;

namespace Atles.Domain.Models.Forums.Events
{
    /// <summary>
    /// Event published when a forum is updated
    /// </summary>
    public class ForumUpdated : EventBase
    {
        /// <summary>
        /// The new forum category for the forum.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// The new name of the forum.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The new slug of the forum.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The new description of the forum.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The unique identifier of the new permission set for the forum.
        /// </summary>
        public Guid? PermissionSetId { get; set; }

        /// <summary>
        /// New sort order
        /// </summary>
        public int SortOrder { get; set; }
    }
}
