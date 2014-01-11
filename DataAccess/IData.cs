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
        IEnumerable<Dto.Trait> GetTraits();

        IEnumerable<Dto.Party> GetParties(int userId);

        Dto.Party GetParty(int partyId);

        IEnumerable<Dto.CharacterCard> GetCharacterCards();

        IEnumerable<Dto.PartyCharacter> GetPartyCharacters(int partyId);

        Dto.PartyCharacter GetPartyCharacter(int id);

        bool CheckUserByEmail(string email);

        Dto.PcgUser GetUser(string email, string password);

        Dto.PcgUser Create(Dto.PcgUser pcgUser);

        Dto.Trait Create(Dto.Trait pcgUser);

        IEnumerable<Dto.Skill> GetCharacterSkills(int characterCardId);

    }
}
