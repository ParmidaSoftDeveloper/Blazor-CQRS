﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Atles.Data;
using Atles.Domain.Commands;
using Atles.Domain.Events;
using Atles.Domain.Models;
using Atles.Infrastructure.Commands;
using Atles.Infrastructure.Events;
using FluentValidation;

namespace Atles.Domain.Handlers.PermissionSets.Commands
{
    public class CreatePermissionSetHandler : ICommandHandler<CreatePermissionSet>
    {
        private readonly AtlesDbContext _dbContext;
        private readonly IValidator<CreatePermissionSet> _validator;

        public CreatePermissionSetHandler(AtlesDbContext dbContext,
            IValidator<CreatePermissionSet> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<IEnumerable<IEvent>> Handle(CreatePermissionSet command)
        {
            await _validator.ValidateCommand(command);

            var permissionSet = new PermissionSet(command.Id,
                command.SiteId,
                command.Name,
                command.Permissions.ToDomainPermissions());

            _dbContext.PermissionSets.Add(permissionSet);

            var @event = new PermissionSetCreated
            {
                Name = permissionSet.Name,
                Permissions = command.Permissions.ToDomainPermissions(),
                TargetId = permissionSet.Id,
                TargetType = nameof(PermissionSet),
                SiteId = command.SiteId,
                UserId = command.UserId
            };

            _dbContext.Events.Add(@event.ToDbEntity());

            await _dbContext.SaveChangesAsync();

            return new IEvent[] { @event };
        }
    }
}
