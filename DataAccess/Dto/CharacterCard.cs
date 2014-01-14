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
        private static IDataContext _context;

        public int Id { get; set; }
        public string Name { get; set; }

        public static CharacterCard Get(int id, IDataContext context = null)
        {
            _context = context;

            CharacterCard characterCard = null;

            using (var data = _context.GetDataContext())
            {
                var card = data.charactercards.SingleOrDefault(c => c.Id == id);
                if (card != null) characterCard = new CharacterCard(card);
            }

            return characterCard;
        }
        public static List<CharacterCard> All(IDataContext context = null)
        {
            _context = context;

            var allCards = new List<CharacterCard>();

            using (var data = _context.GetDataContext())
            {
                var all = data.charactercards;
                allCards.AddRange(all.Select(a => new CharacterCard(a)));
            }

            return allCards;
        }

        public void Persist()
        {
            using (var data = _context.GetDataContext())
            {
                var card = this.ToEntity();

                data.charactercards.Add(card);
                data.SaveChanges();

                Id = card.Id;
            }
        }
        public void Update()
        {
            using (var data = _context.GetDataContext())
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
            using (var data = _context.GetDataContext())
            {
                var card = data.charactercards.SingleOrDefault(u => u.Id == Id);
                if (card != null)
                {
                    data.charactercards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public CharacterCard(IDataContext context)
        {
            _context = context;
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
