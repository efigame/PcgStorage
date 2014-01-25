using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class CharacterPower
    {
        public int Id { get; set; }
        public int PartyCharacterId { get; set; }
        public int PowerId { get; set; }
        public int SelectedPowers { get; set; }

        public static CharacterPower Get(int id)
        {
            CharacterPower characterPower = null;

            using (var data = new PcgStorageEntities())
            {
                var character = data.characterpowers.SingleOrDefault(p => p.Id == id);
                if (character != null) characterPower = new CharacterPower(character);
            }

            return characterPower;
        }
        public static CharacterPower Get(int partyCharacterId, int powerId)
        {
            CharacterPower characterPower = null;

            using (var data = new PcgStorageEntities())
            {
                var character = data.characterpowers.FirstOrDefault(p => p.PartyCharacterId == partyCharacterId && p.PowerId == powerId);
                if (character != null) characterPower = new CharacterPower(character);
            }

            return characterPower;
        }
        public static List<CharacterPower> All(int partyCharacterId)
        {
            var characterPowers = new List<CharacterPower>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterpowers.Where(p => p.PartyCharacterId == partyCharacterId).ToList();
                characterPowers.AddRange(all.Select(a => new CharacterPower(a)));
            }

            return characterPowers;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.characterpowers.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterPowers = data.characterpowers.SingleOrDefault(p => p.Id == Id);
                if (characterPowers != null)
                {
                    characterPowers.PartyCharacterId = PartyCharacterId;
                    characterPowers.SelectedPowers = SelectedPowers;
                    characterPowers.PowerId = PowerId;
                    
                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var power = data.characterpowers.SingleOrDefault(p => p.Id == Id);
                if (power != null)
                {
                    data.characterpowers.Remove(power);
                    data.SaveChanges();
                }
            }
        }

        public CharacterPower()
        {
        }

        internal CharacterPower(characterpower characterPower)
        {
            Id = characterPower.Id;
            PartyCharacterId = characterPower.PartyCharacterId;
            SelectedPowers = characterPower.SelectedPowers;
            PowerId = characterPower.PowerId;
        }
        internal characterpower ToEntity()
        {
            var characterPower = new characterpower
            {
                PartyCharacterId = this.PartyCharacterId,
                SelectedPowers = this.SelectedPowers,
                PowerId = this.PowerId
            };

            return characterPower;
        }
    }
}
