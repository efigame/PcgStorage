using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager
{
    public interface IPcgManager
    {
        IEnumerable<Dto.Card> GetCards();

        List<Dto.Party> GetParties(int userId);

        Dto.Party GetParty(int partyId);

        Dto.SuccessMessage CreateUser(string email, string password);

        Dto.User LoginUser(string email, string password);
    }
}
