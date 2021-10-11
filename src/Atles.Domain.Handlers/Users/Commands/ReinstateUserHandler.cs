﻿using Atles.Data;
using Atles.Domain.Users;
using Atles.Domain.Users.Commands;
using Microsoft.EntityFrameworkCore;
using OpenCqrs.Commands;
using System.Data;
using System.Threading.Tasks;

namespace Atles.Domain.Handlers.Users.Commands
{
    public class ReinstateUserHandler : ICommandHandler<ReinstateUser>
    {
        private readonly AtlesDbContext _dbContext;

        public ReinstateUserHandler(AtlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(ReinstateUser command)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.Id == command.Id &&
                    x.Status != UserStatusType.Deleted);

            if (user == null)
            {
                throw new DataException($"User with Id {command.Id} not found.");
            }

            user.Reinstate();

            _dbContext.Events.Add(new Event(command.SiteId,
                command.UserId,
                EventType.Reinstated,
                typeof(User),
                command.Id));

            await _dbContext.SaveChangesAsync();
        }
    }
}