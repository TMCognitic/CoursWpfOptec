using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        bool Execute(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommandDefinition<TResult>
    {
        TResult Execute(TCommand command);
    }
}
