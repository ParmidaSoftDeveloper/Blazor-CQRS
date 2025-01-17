﻿using Atles.Core.Queries;
using Atles.Data;
using Atles.Domain.Models;
using Atles.Domain.Rules.Users;
using Microsoft.EntityFrameworkCore;

namespace Atles.Domain.Rules.Handlers.Users
{
    public class IsUserDisplayNameUniqueHandler : IQueryHandler<IsUserDisplayNameUnique, bool>
    {
        private readonly AtlesDbContext _dbContext;

        public IsUserDisplayNameUniqueHandler(AtlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsUserDisplayNameUnique query)
        {
            bool any;

            if (query.Id != null)
            {
                any = await _dbContext.Users
                .AnyAsync(x => x.DisplayName == query.DisplayName &&
                               x.Status != UserStatusType.Deleted &&
                               x.Id != query.Id);
            }
            else
            {
                any = await _dbContext.Users
                .AnyAsync(x => x.DisplayName == query.DisplayName &&
                               x.Status != UserStatusType.Deleted);
            }

            return !any;
        }
    }
}
