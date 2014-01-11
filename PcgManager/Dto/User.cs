using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        internal User(DataAccess.Dto.PcgUser pcgUser)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;
        }
    }
}
