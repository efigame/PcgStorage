using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CardType CardType { get; set; }

        public static IEnumerable<Card> All(CardType cardType)
        {
            var cards = new List<Card>();

            switch (cardType)
            {
                case CardType.Character:
                    var characterCards = DataAccess.Dto.CharacterCard.All();
                    cards.AddRange(characterCards.Select(c => new Card(c)));
                    break;
                case CardType.Monster:
                    break;
            }

            return cards;
        }

        internal Card()
        {
        }

        internal Card(DataAccess.Dto.CharacterCard card)
        {
            Id = card.Id;
            Name = card.Name;
            CardType = CardType.Character;
        }
    }
}
