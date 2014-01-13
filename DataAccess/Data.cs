using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data : IData, IDisposable
    {

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
