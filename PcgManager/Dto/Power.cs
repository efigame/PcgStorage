using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Power
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int? Adjustment { get; set; }
        public int CharacterCardId { get; set; }
        public int? Dice { get; set; }

        public Power()
        {
        }

        internal Power(DataAccess.Dto.Power power) : this(power, true)
        {
        }

        internal Power(DataAccess.Dto.Power power, bool deepObjects)
        {
            Id = power.Id;
            Text = power.Text;
            Number = power.Number;
            Adjustment = power.Adjustment;
            CharacterCardId = power.CharacterCardId;
            Dice = power.Dice;
        }
    }
}
