using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class Power
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int? Dice { get; set; }
        public int? Adjustment { get; set; }
        public int CharacterCardId { get; set; }

        public static Power Get(int id)
        {
            Power power = null;

            using (var data = new PcgStorageEntities())
            {
                var characterPower = data.powers.SingleOrDefault(p => p.Id == id);
                if (characterPower != null) power = new Power(characterPower);
            }

            return power;
        }
        public static List<Power> All(int characterCardId)
        {
            var powers = new List<Power>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.powers.Where(s => s.CharacterCardId == characterCardId).ToList();
                powers.AddRange(all.Select(a => new Power(a)));
            }

            return powers;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.powers.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var power = data.powers.SingleOrDefault(s => s.Id == Id);
                if (power != null)
                {
                    power.CharacterCardId = CharacterCardId;
                    power.Text = Text;
                    power.Number = Number;
                    power.Dice = Dice;
                    power.Adjustment = Adjustment;

                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var power = data.powers.SingleOrDefault(s => s.Id == Id);
                if (power != null)
                {
                    data.powers.Remove(power);
                    data.SaveChanges();
                }
            }
        }

        public Power()
        {
        }

        internal Power(power power)
        {
            Id = power.Id;
            Text = power.Text;
            Number = power.Number;
            Dice = power.Dice;
            Adjustment = power.Adjustment;
            CharacterCardId = power.CharacterCardId;
        }
        internal power ToEntity()
        {
            var power = new power
            {
                Text = this.Text,
                Number = this.Number,
                Dice = this.Dice,
                Adjustment = this.Adjustment,
                CharacterCardId = this.CharacterCardId
            };

            return power;
        }
    }
}
