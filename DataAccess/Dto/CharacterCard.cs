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
                var card = data.charactercards.SingleOrDefault(c => c.Id == id);
                if (card != null) characterCard = new CharacterCard(card);
            }

            return characterCard;
        }
        public static List<CharacterCard> All()
        {
            var allCards = new List<CharacterCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.charactercards.ToList();
                allCards.AddRange(all.Select(a => new CharacterCard(a)));
            }

            return allCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = this.ToEntity();

                data.charactercards.Add(card);
                data.SaveChanges();

                Id = card.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.charactercards.SingleOrDefault(c => c.Id == Id);
                if (card != null)
                {
                    card.Name = Name;
                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.charactercards.SingleOrDefault(u => u.Id == Id);
                if (card != null)
                {
                    data.charactercards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public CharacterCard()
        {
        }

        internal CharacterCard(charactercard card)
        {
            Id = card.Id;
            Name = card.Name;
        }
        internal charactercard ToEntity()
        {
            var card = new charactercard
            {
                Name = this.Name
            };

            return card;
        }
    }
}
