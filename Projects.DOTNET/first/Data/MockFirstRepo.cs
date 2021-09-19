using System.Collections.Generic;
using first.models;

namespace Commander.Data
{
    public class MockFirstRepo : IFirstRepo 
    {
        public IEnumarable<command> GetAppCommands(){
        var commands = new List<command>
        {
            new command(id =0, HowTo="sakdasdksad",Line ="Line",Platform = "Kettle & Pan");
            new command(id =1, HowTo="sakdasdksad",Line ="Line",Platform = "Kettle & Pan");
            new command(id =2, HowTo="sakdasdksad",Line ="Line",Platform = "Kettle & Pan");
        };
        return commands;
        }
    public command GetCommandById(int id){

        return new command(id =0, HowTo="sakdasdksad",Line ="Line",Platform = "Kettle & Pan");


    }
}
