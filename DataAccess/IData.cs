using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IData
    {
 
        IEnumerable<Dto.PartyCharacter> GetPartyCharacters(int partyId);

        Dto.PartyCharacter GetPartyCharacter(int id);

        bool CheckUserByEmail(string email);


        IEnumerable<Dto.Skill> GetCharacterSkills(int characterCardId);

    }
}
