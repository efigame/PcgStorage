using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public List<Character> Characters { get; set; }

        public Party()
        {
            Characters = new List<Character>();
        }

        internal Party(DataAccess.Dto.Party party) : this(party, true)
        {
        }

        internal Party(DataAccess.Dto.Party party, bool deepObjects)
        {
            Id = party.Id;
            Name = party.Name;
            UserId = party.PcgUserId;
            Characters = new List<Character>();

            if (deepObjects)
            {
                var characters = DataAccess.Dto.PartyCharacter.All(Id);
                Characters.AddRange(characters.Select(c => new Character(c)));
            }
        }

        public void Persist()
        {
            var party = new DataAccess.Dto.Party();
            party.Name = Name;
            party.PcgUserId = UserId;

            party.Persist();

            Id = party.Id;

            foreach (var partyCard in Characters)
            {
                partyCard.PartyId = Id;
                partyCard.Persist();
            }
        }

        public void Update()
        {
            var partyInDb = DataAccess.Dto.Party.Get(this.Id);
            if (partyInDb.Name != this.Name)
            {
                partyInDb.Name = this.Name;
            }

            partyInDb.Update();

            var partyCardsInDb = DataAccess.Dto.PartyCharacter.All(partyInDb.Id);

            var intersetingIds = Characters.Select(c => c.CharacterCardId).Intersect(partyCardsInDb.Select(p => p.CharacterCardId));

            var charactersToCreate = Characters.Where(c => !intersetingIds.Any(i => i == c.CharacterCardId));
            var charactersToDelete = partyCardsInDb.Where(p => !intersetingIds.Any(i => i == p.CharacterCardId));

            foreach (var partyCard in charactersToCreate)
            {
                partyCard.PartyId = Id;
                partyCard.Persist();
            }

            foreach (var partyCard in charactersToDelete)
            {
                partyCard.Delete();
            }
        }

    }
}
