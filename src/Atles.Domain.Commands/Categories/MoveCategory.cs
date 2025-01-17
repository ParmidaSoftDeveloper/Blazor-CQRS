﻿using Atles.Core.Commands;
using Atles.Domain.Models;
using Docs.Attributes;

namespace Atles.Domain.Commands.Categories
{
    /// <summary>
    /// Request that changes the sort order of a forum category.
    /// </summary>
    [DocRequest(typeof(Category))]
    public class MoveCategory : CommandBase
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The direction.
        /// Can be either up or down.
        /// </summary>
        public DirectionType Direction { get; set; }
    }
}
