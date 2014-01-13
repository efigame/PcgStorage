using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data : IData, IDisposable
    {
 
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
