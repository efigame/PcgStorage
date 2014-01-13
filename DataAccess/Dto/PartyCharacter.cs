using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class PartyCharacter
    {
        public int Id { get; set; }
        public int  PartyId { get; set; }
        public int CharacterCardId { get; set; }

        public static PartyCharacter Get(int id)
        {
            PartyCharacter partyCharacter = null;

            using (var data = new PcgStorageEntities())
            {
                var character = data.partycharacters.SingleOrDefault(p => p.Id == id);
                if (character != null) partyCharacter = new PartyCharacter(character);
            }

            return partyCharacter;
        }
        public static List<PartyCharacter> All(int partyId)
        {
            var partyCharacters = new List<PartyCharacter>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.partycharacters.Where(p => p.PartyId == partyId).ToList();
                partyCharacters.AddRange(all.Select(a => new PartyCharacter(a)));
            }

            return partyCharacters;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.partycharacters.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var partyCharacter = data.partycharacters.SingleOrDefault(p => p.Id == Id);
                if (partyCharacter != null)
                {
                    partyCharacter.CharacterCardId = CharacterCardId;
                    partyCharacter.PartyId = PartyId;
                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var party = data.partycharacters.SingleOrDefault(p => p.Id == Id);
                if (party != null)
                {
                    data.partycharacters.Remove(party);
                    data.SaveChanges();
                }
            }
        }

        public PartyCharacter()
        {
        }

        internal PartyCharacter(partycharacter character)
        {
            Id = character.Id;
            PartyId = character.PartyId;
            CharacterCardId = character.CharacterCardId;
        }
        internal partycharacter ToEntity()
        {
            var partyCharacter = new partycharacter
            {
                PartyId = this.PartyId,
                CharacterCardId = this.CharacterCardId
            };

            return partyCharacter;
        }
    }
}
