﻿using System;
using System.Collections.Generic;

namespace Atlas.Models
{
    public class Forum
    {
        public Guid Id { get; private set; }
        public Guid ForumGroupId { get; private set; }
        public string Name { get; private set; }
        public int SortOrder { get; private set; }
        public int TopicsCount { get; private set; }
        public int RepliesCount { get; private set; }
        public Guid? PermissionSetId { get; private set; }

        public virtual ForumGroup ForumGroup { get; set; }
        public virtual PermissionSet PermissionSet { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public Forum()
        {
            
        }

        public Forum(Guid forumGroupId, string name, int sortOrder, Guid? permissionSetId = null)
        {
            Id = Guid.NewGuid();
            ForumGroupId = forumGroupId;
            Name = name;
            SortOrder = sortOrder;
            PermissionSetId = permissionSetId;
        }

        public void UpdateDetails(Guid forumGroupId, string name, Guid? permissionSetId = null)
        {
            ForumGroupId = forumGroupId;
            Name = name;
            PermissionSetId = permissionSetId;
        }

        public void UpdateOrder(int sortOrder)
        {
            SortOrder = sortOrder;
        }

        public string PermissionSetName() => PermissionSet?.Name;
    }
}
