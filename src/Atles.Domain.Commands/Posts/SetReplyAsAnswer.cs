﻿using Atles.Core.Commands;
using Atles.Domain.Models;
using Docs.Attributes;

namespace Atles.Domain.Commands.Posts
{
    /// <summary>
    /// Request to set a reply as answer.
    /// </summary>
    [DocRequest(typeof(Post))]
    public class SetReplyAsAnswer : CommandBase
    {
        public Guid ReplyId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The unique identifier of the forum.
        /// </summary>
        public Guid ForumId { get; set; }

        /// <summary>
        /// The unique identifier of the topic.
        /// </summary>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Value indicating whether the reply needs to be set as answer (true) or not (false).
        /// </summary>
        public bool IsAnswer { get; set; }
    }
}