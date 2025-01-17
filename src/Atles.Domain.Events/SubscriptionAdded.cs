﻿using Atles.Core.Events;
using Atles.Domain.Models;

namespace Atles.Domain.Events
{
    /// <summary>
    /// Event published when a new subscription is added.
    /// </summary>
    public class SubscriptionAdded : EventBase
    {
        /// <summary>
        /// The id of the item (category, forum or topic).
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// The type of subscription  (category, forum or topic).
        /// </summary>
        public SubscriptionType Type { get; set; }
    }
}
