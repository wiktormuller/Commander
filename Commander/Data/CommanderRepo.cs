using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public CommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = _context.Commands.ToList();

            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault(c => c.Id == id);

            return command;
        }
    }
}
