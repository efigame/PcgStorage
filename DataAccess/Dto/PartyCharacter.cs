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

        public CharacterCard CharacterCard { get; set; }

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

        public void Delete()
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

        internal DataAccess.partycharacter ToEntity()
        {
            var partyCharacter = new DataAccess.partycharacter
            {
                PartyId = this.PartyId,
                CharacterCardId = this.CharacterCardId
            };

            return partyCharacter;
        }
        internal PartyCharacter(DataAccess.partycharacter character, DataAccess.charactercard characterCard)
        {
            Id = character.Id;
            PartyId = character.PartyId;
            CharacterCardId = character.CharacterCardId;
            CharacterCard = new Dto.CharacterCard(characterCard);
        }
    }
}
