﻿using System;
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

        // TODO: Add character skills



        public void Persist()
        {
            var partyCharacter = new DataAccess.Dto.PartyCharacter();
            partyCharacter.PartyId = PartyId;
            partyCharacter.CharacterCardId = CharacterCardId;

            partyCharacter.Persist();

            Id = partyCharacter.Id;
        }

        public void Delete()
        {
            var partyCharacter = DataAccess.Dto.PartyCharacter.Get(Id);
            partyCharacter.Delete();
        }

        public Character()
        {
        }

        internal Character(DataAccess.Dto.PartyCharacter partyCharacter) : this(partyCharacter, true)
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter, bool deepObjects)
        {
            Id = partyCharacter.Id;
            PartyId = partyCharacter.PartyId;
            CharacterCardId = partyCharacter.CharacterCardId;
            Skills = new List<Skill>();

            if (deepObjects)
            {
                var characterCard = DataAccess.Dto.CharacterCard.Get(partyCharacter.CharacterCardId);
                Name = characterCard.Name;

                var skills = DataAccess.Dto.Skill.All(CharacterCardId);
                Skills.AddRange(skills.Select(s => new Skill(s)));
            }
        }
    }
}
