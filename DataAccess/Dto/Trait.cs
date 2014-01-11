using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class Trait
    {
        public int Id { get; set; }

        public string Name { get; set; }

        internal Trait(DataAccess.trait trait)
        {
            Id = trait.Id;
            Name = trait.Name;
        }
    }
}
