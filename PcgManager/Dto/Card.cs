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
        
        internal Card()
        {
        }

        internal Card(DataAccess.Dto.CharacterCard card)
        {
            Id = card.Id;
            Name = card.Name;
            CardType = Dto.CardType.Character;
        }
    }
}
