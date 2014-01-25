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
        public int? SelectedPowers { get; set; }

        public static void Set(int partyCharacterId, int powerId, int selectedValue)
        {
            var selectedPower = DataAccess.Dto.CharacterPower.All(partyCharacterId).SingleOrDefault(c => c.PowerId == powerId);
            if (selectedPower != null)
            {
                selectedPower.SelectedPowers = selectedValue;
                selectedPower.Update();
            }
            else
            {
                selectedPower = new DataAccess.Dto.CharacterPower
                {
                    PartyCharacterId = partyCharacterId,
                    SelectedPowers = selectedValue,
                    PowerId = powerId
                };
                selectedPower.Persist();
            }
        }

        public Power()
        {
        }
        internal Power(DataAccess.Dto.Power power, int partyCharacterId) : this(power, partyCharacterId, true)
        {
        }
        internal Power(DataAccess.Dto.Power power, int partyCharacterId, bool deepObjects)
        {
            Id = power.Id;
            Text = power.Text;
            Number = power.Number;
            Adjustment = power.Adjustment;
            CharacterCardId = power.CharacterCardId;
            Dice = power.Dice;

            if (deepObjects)
            {
                var selectedPower = DataAccess.Dto.CharacterPower.All(partyCharacterId).SingleOrDefault(c => c.PowerId == Id);
                if (selectedPower != null)
                    SelectedPowers = selectedPower.SelectedPowers;
                else
                    SelectedPowers = 0;
            }
        }
    }
}
