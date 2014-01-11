using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class PcgUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PcgUser()
        {
        }

        internal PcgUser(DataAccess.pcguser pcgUser)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;
            Password = pcgUser.Password;
        }

        internal DataAccess.pcguser ToEntity()
        {
            var pcgUser = new DataAccess.pcguser
            {
                Email = this.Email,
                Password = this.Password
            };

            return pcgUser;
        }
    }
}
