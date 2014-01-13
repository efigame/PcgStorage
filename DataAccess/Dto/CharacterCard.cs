using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class CharacterCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static CharacterCard Get(int id)
        {
            CharacterCard characterCard = null;

            using (var data = new PcgStorageEntities())
            {
                var card = data.charactercards.FirstOrDefault(c => c.Id == id);
                if (card != null) characterCard = new CharacterCard(card);
            }

            return characterCard;
        }

        public static List<CharacterCard> All()
        {
            var allCards = new List<CharacterCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.charactercards;
                allCards.AddRange(all.Select(a => new CharacterCard(a)));
            }

            return allCards;
        }

        internal CharacterCard(DataAccess.charactercard card)
        {
            Id = card.Id;
            Name = card.Name;
        }
    }
}
