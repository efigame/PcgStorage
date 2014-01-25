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
        public int BaseLightArmors { get; set; }
        public int BaseHeavyArmors { get; set; }
        public int BaseWeapons { get; set; }
        public int BaseWeaponCards { get; set; }
        public int BaseSpellCards { get; set; }
        public int BaseArmorCards { get; set; }
        public int BaseItemCards { get; set; }
        public int BaseAllyCards { get; set; }
        public int BaseBlessingCards { get; set; }
        public int PossibleHandSize { get; set; }

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
                    card.BaseWeaponCards = BaseWeaponCards;
                    card.BaseSpellCards = BaseSpellCards;
                    card.BaseArmorCards = BaseArmorCards;
                    card.BaseItemCards = BaseItemCards;
                    card.BaseAllyCards = BaseAllyCards;
                    card.BaseBlessingCards = BaseBlessingCards;
                    card.PossibleHandSize = PossibleHandSize;
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
            BaseWeaponCards = card.BaseWeaponCards;
            BaseSpellCards = card.BaseSpellCards;
            BaseArmorCards = card.BaseArmorCards;
            BaseItemCards = card.BaseItemCards;
            BaseAllyCards = card.BaseAllyCards;
            BaseBlessingCards = card.BaseBlessingCards;
            PossibleHandSize = card.PossibleHandSize;
        }
        internal charactercard ToEntity()
        {
            var card = new charactercard
            {
                Name = this.Name,
                BaseHandSize = this.BaseHandSize,
                BaseLightArmors = this.BaseLightArmors,
                BaseHeavyArmors = this.BaseHeavyArmors,
                BaseWeapons = this.BaseWeapons,
                BaseWeaponCards = this.BaseWeaponCards,
                BaseSpellCards = this.BaseSpellCards,
                BaseArmorCards = this.BaseArmorCards,
                BaseItemCards = this.BaseItemCards,
                BaseAllyCards = this.BaseAllyCards,
                BaseBlessingCards = this.BaseBlessingCards,
                PossibleHandSize = this.PossibleHandSize
            };

            return card;
        }
    }
}
