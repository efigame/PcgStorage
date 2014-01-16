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
        public int BaseHandSize { get; set; }
        public bool BaseLightArmors { get; set; }
        public bool BaseHeavyArmors { get; set; }
        public bool BaseWeapons { get; set; }

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
                    card.BaseHandSize = BaseHandSize;
                    card.BaseLightArmors = BaseLightArmors;
                    card.BaseHeavyArmors = BaseHeavyArmors;
                    card.BaseWeapons = BaseWeapons;
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
            BaseHandSize = card.BaseHandSize;
            BaseLightArmors = card.BaseLightArmors;
            BaseHeavyArmors = card.BaseHeavyArmors;
            BaseWeapons = card.BaseWeapons;
        }
        internal charactercard ToEntity()
        {
            var card = new charactercard
            {
                Name = this.Name,
                BaseHandSize = this.BaseHandSize,
                BaseLightArmors = this.BaseLightArmors,
                BaseHeavyArmors = this.BaseHeavyArmors,
                BaseWeapons = this.BaseWeapons
            };

            return card;
        }
    }
}
