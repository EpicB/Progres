using System.Collections.Generic;
using first.models;

namespace first.data
{
    public interface IFirstRepo
    {
        IEnumerable <first> GetAppCommands();
        first GetCommandById(int id);
    }
}