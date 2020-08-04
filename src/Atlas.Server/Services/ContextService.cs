﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Atlas.Data;
using Atlas.Data.Builders;
using Atlas.Data.Caching;
using Atlas.Models.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Server.Services
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICacheManager _cacheManager;
        private readonly AtlasDbContext _dbContext;
        private readonly IGravatarService _gravatarService;

        public ContextService(IHttpContextAccessor httpContextAccessor, 
            ICacheManager cacheManager,
            AtlasDbContext dbContext,
            IGravatarService gravatarService)
        {
            _httpContextAccessor = httpContextAccessor;
            _cacheManager = cacheManager;
            _dbContext = dbContext;
            _gravatarService = gravatarService;
        }

        public async Task<CurrentSiteModel> CurrentSiteAsync()
        {
            var currentSite = await _cacheManager.GetOrSetAsync(CacheKeys.Site("Default"), () => 
                _dbContext.Sites.FirstOrDefaultAsync(x => x.Name == "Default"));

            return new CurrentSiteModel
            {
                Id = currentSite.Id,
                Name = currentSite.Name,
                Title = currentSite.Title
            };
        }

        public async Task<CurrentMemberModel> CurrentMemberAsync()
        {
            var result = new CurrentMemberModel();

            var user = _httpContextAccessor.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                var userId = _httpContextAccessor.HttpContext.User.Identities.First().Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    var member = await _dbContext.Members.FirstOrDefaultAsync(x => x.UserId == userId);

                    if (member != null)
                    {
                        result = new CurrentMemberModel
                        {
                            Id = member.Id,
                            UserId = member.UserId,
                            Email = member.Email,
                            DisplayName = member.DisplayName,
                            GravatarHash = _gravatarService.HashEmailForGravatar(member.Email)
                        };
                    }
                }
            }

            return result;
        }
    }
}