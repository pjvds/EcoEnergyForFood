using System;
using Ncqrs.Commanding;

namespace Commands
{
    public class CreateCustomer : CommandBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
