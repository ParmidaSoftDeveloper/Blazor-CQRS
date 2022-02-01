﻿using Atles.Domain.Models;
using Atles.Infrastructure.Commands;
using Docs.Attributes;

namespace Atles.Domain.Commands
{
    /// <summary>
    /// Request that deletes a Forum Category.
    /// </summary>
    [DocRequest(typeof(Category))]
    public class DeleteCategory : CommandBase
    {
    }
}
