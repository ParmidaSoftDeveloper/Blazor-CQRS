﻿using System.Linq;
using System.Threading.Tasks;
using Atles.Data;
using Atles.Data.Caching;
using Atles.Domain.Models;
using Atles.Domain.Models.Forums;
using Atles.Domain.Models.Forums.Commands;
using Atles.Domain.Models.Forums.Events;
using Atles.Infrastructure.Commands;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Atles.Domain.Handlers.Forums.Commands
{
    public class CreateForumHandler : ICommandHandler<CreateForum>
    {
        private readonly AtlesDbContext _dbContext;
        private readonly ICacheManager _cacheManager;
        private readonly IValidator<CreateForum> _validator;

        public CreateForumHandler(AtlesDbContext dbContext,
            ICacheManager cacheManager,
            IValidator<CreateForum> validator)
        {
            _dbContext = dbContext;
            _cacheManager = cacheManager;
            _validator = validator;
        }

        public async Task Handle(CreateForum command)
        {
            await _validator.ValidateCommand(command);

            var forumsCount = await _dbContext.Forums
                .Where(x => x.CategoryId == command.CategoryId && x.Status != ForumStatusType.Deleted)
                .CountAsync();

            var sortOrder = forumsCount + 1;

            var forum = new Forum(command.Id,
                command.CategoryId,
                command.Name,
                command.Slug,
                command.Description,
                sortOrder,
                command.PermissionSetId);

            _dbContext.Forums.Add(forum);

            var @event = new ForumCreated
            {
                Name = forum.Name,
                Slug = forum.Slug,
                Description = forum.Description,
                CategoryId = forum.CategoryId,
                PermissionSetId = forum.PermissionSetId,
                SortOrder = forum.SortOrder,
                TargetId = forum.Id,
                TargetType = nameof(Forum),
                SiteId = command.SiteId,
                UserId = command.UserId
            };

            _dbContext.Events.Add(@event.ToDbEntity());

            await _dbContext.SaveChangesAsync();

            _cacheManager.Remove(CacheKeys.Categories(command.SiteId)); 
            _cacheManager.Remove(CacheKeys.CurrentForums(command.SiteId));
        }
    }
}
