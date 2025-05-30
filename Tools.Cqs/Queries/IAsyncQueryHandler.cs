﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Queries
{
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
