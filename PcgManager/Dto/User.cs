using DataAccess.Dto;
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
        public List<Party> Parties { get; set; }

        public static SuccessMessage Create(string email, string password)
        {
            var successMessage = new SuccessMessage
            {
                Success = false
            };

            var pcgUser = new PcgUser
            {
                Email = email,
                Password = password
            };

            if (!PcgUser.CheckUserByEmail(pcgUser.Email))
            {
                pcgUser.Persist();

                if (pcgUser.Id > 0) successMessage.Success = true;
            }
            else
            {
                successMessage.Success = false;
                successMessage.FailedType = FailedType.UserAlreadyExists;
            }

            return successMessage;
        }
        public static User Login(string email, string password)
        {
            User user = null;

            var pcgUser = PcgUser.Get(email, password);
            if (pcgUser != null) user = new User(pcgUser);

            return user;
        }

        internal User(PcgUser pcgUser) : this(pcgUser, true)
        {
        }

        internal User(PcgUser pcgUser, bool deepObjects)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;

            Parties = new List<Party>();

            if (deepObjects)
            {
                var parties = DataAccess.Dto.Party.All(Id).ToList();
                Parties.AddRange(parties.Select(p => new Party(p, true)));
            }
        }
    }
}
