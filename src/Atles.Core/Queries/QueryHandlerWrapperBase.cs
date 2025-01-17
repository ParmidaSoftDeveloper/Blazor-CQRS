﻿using System.Threading.Tasks;
using Atles.Core.Services;

namespace Atles.Core.Queries
{
    internal abstract class QueryHandlerWrapperBase<TResult>
    {
        protected static THandler GetHandler<THandler>(IServiceProviderWrapper serviceProvider)
        {
            return serviceProvider.GetService<THandler>();
        }

        public abstract Task<TResult> Handle(IQuery<TResult> query, IServiceProviderWrapper serviceProvider);
    }
}
