using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Character
    {
        public int Id { get; set; }

        public int PartyId { get; set; }

        public int CharacterCardId { get; set; }

        public string Name { get; set; }

        public List<Skill> Skills { get; set; }

        // TODO: Populate this list


        public void Persist()
        {
            using (var data = new DataAccess.Data())
            {
                var partyCharacter = new DataAccess.Dto.PartyCharacter();
                partyCharacter.PartyId = PartyId;
                partyCharacter.CharacterCardId = CharacterCardId;

                partyCharacter.Persist();

                Id = partyCharacter.Id;
            }
        }

        public void Delete()
        {
            using (var data = new DataAccess.Data())
            {
                var partyCharacter = data.GetPartyCharacter(Id);
                partyCharacter.Delete();
            }
        }

        public Character()
        {
        }

        internal Character(DataAccess.Dto.PartyCharacter partyCharacter) : this(partyCharacter, true)
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter, bool DeepObjects)
        {
            Id = partyCharacter.Id;
            PartyId = partyCharacter.PartyId;
            CharacterCardId = partyCharacter.CharacterCardId;
            Name = partyCharacter.CharacterCard.Name;
            Skills = new List<Skill>();

            if (DeepObjects)
            {
                using (var data = new DataAccess.Data())
                {
                    var skills = data.GetCharacterSkills(CharacterCardId);
                    Skills.AddRange(skills.Select(s => new Skill(s)));
                }
            }
        }
    }
}
