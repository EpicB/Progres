using System.Collections.Generic;
using CommandAPI.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
        _context = context;
        }
        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
            throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);

        }

        public void DeleteCommand(Command cmd)
        {
        if(cmd == null)
            {
            throw new ArgumentNullException(nameof(cmd));
            }
        _context.CommandItems.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            var x = _context.CommandItems.FirstOrDefault(p => p.Id == id);
            return x;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //
        }
    }
}