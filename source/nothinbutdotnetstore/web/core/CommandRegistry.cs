﻿using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        IEnumerable<IProcessOneSpecificRequest> commands;
        MissingCommandFactory missing_command_factory;

        public CommandRegistry():this(Stub.of<StubSetOfCommands>(),Stub.of<StubMissingCommand>().create)
        {
        }

        public CommandRegistry(IEnumerable<IProcessOneSpecificRequest> commands, MissingCommandFactory missing_command_factory)
        {
            this.commands = commands;
            this.missing_command_factory = missing_command_factory;
        }

        public IProcessOneSpecificRequest get_command_for(IContainRequestInformation the_request)
        {
            return commands.FirstOrDefault(x => x.can_process(the_request)) ??
                missing_command_factory();
        }
    }
}