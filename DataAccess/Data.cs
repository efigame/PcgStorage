using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data : IData, IDisposable
    {
        public IEnumerable<Dto.Trait> GetTraits()
        {
            var traitsDto = new List<Dto.Trait>();

            using (var data = new PcgStorageEntities())
            {
                var traits = data.traits.ToList();
                traitsDto.AddRange(traits.Select(t => new Dto.Trait(t)));
            }

            return traitsDto;
        }

        public IEnumerable<Dto.Party> GetParties(int userId)
        {
            var parties = new List<Dto.Party>();

            using (var data = new PcgStorageEntities())
            {
                var partyList = data.parties.Where(p => p.PcgUserId == userId).ToList();
                parties.AddRange(partyList.Select(p => new Dto.Party(p)));
            }

            return parties;
        }

        public Dto.Party GetParty(int partyId)
        {
            var partyDto = new Dto.Party();

            using (var data = new PcgStorageEntities())
            {
                var party = data.parties.SingleOrDefault(p => p.Id == partyId);
                partyDto = new Dto.Party(party);
            }

            return partyDto;
        }

        public IEnumerable<Dto.CharacterCard> GetCharacterCards()
        {
            var characterCards = new List<Dto.CharacterCard>();

            using (var data = new PcgStorageEntities())
            {
                var characters = data.charactercards.ToList();
                characterCards.AddRange(characters.Select(c => new Dto.CharacterCard(c)));
            }

            return characterCards;
        }

        public IEnumerable<Dto.PartyCharacter> GetPartyCharacters(int partyId)
        {
            var partyCharacterDtos = new List<Dto.PartyCharacter>();

            using (var data = new PcgStorageEntities())
            {
                var partyCharacters = data.partycharacters.Where(p => p.PartyId == partyId).ToList();
                partyCharacterDtos.AddRange(partyCharacters.Select(p => new Dto.PartyCharacter(p, p.charactercard)));
            }

            return partyCharacterDtos;
        }

        public Dto.PartyCharacter GetPartyCharacter(int id)
        {
            var partyCharacterDto = new Dto.PartyCharacter();

            using (var data = new PcgStorageEntities())
            {
                var partyCharacter = data.partycharacters.SingleOrDefault(p => p.Id == id);
                partyCharacterDto = new Dto.PartyCharacter(partyCharacter, partyCharacter.charactercard);
            }

            return partyCharacterDto;
        }

        public bool CheckUserByEmail(string email)
        {
            var found = false;

            using (var data = new PcgStorageEntities())
            {
                var pcgUser = data.pcgusers.FirstOrDefault(u => u.Email == email);
                if (pcgUser != null)
                    found = true;
            }

            return found;
        }

        //public Dto.PcgUser GetUser(string email, string password)
        //{
        //    Dto.PcgUser pcgUser = null;

        //    using (var data = new PcgStorageEntities())
        //    {
        //        var user = data.pcgusers.FirstOrDefault(u => u.Email == email && u.Password == password);
        //        if (user != null)
        //            pcgUser = new Dto.PcgUser(user);
        //    }

        //    return pcgUser;
        //}

        //public Dto.PcgUser Create(Dto.PcgUser pcgUser)
        //{
        //    Dto.PcgUser createdPcgUser;

        //    using (var data = new PcgStorageEntities())
        //    {
        //        var pcgUserEntity = pcgUser.ToEntity();
        //        data.pcgusers.Add(pcgUserEntity);
        //        data.SaveChanges();

        //        createdPcgUser = new Dto.PcgUser(pcgUserEntity);
        //    }

        //    return createdPcgUser;
        //}

        public Dto.Trait Create(Dto.Trait pcgUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dto.Skill> GetCharacterSkills(int characterCardId)
        {
            var characterSkillDtos = new List<Dto.Skill>();

            using (var data = new PcgStorageEntities())
            {
                var skills = data.skills.Where(s => s.CharacterCardId == characterCardId).ToList();
                characterSkillDtos.AddRange(skills.Select(s => new Dto.Skill(s)));
            }

            return characterSkillDtos;
        }

        public void Dispose()
        {
        }



        
    }
}
