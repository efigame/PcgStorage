using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Character
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterCardId { get; set; }
        public string Name { get; set; }
        public int LightArmors { get; set; }
        public int HeavyArmors { get; set; }
        public int Weapons { get; set; }
        public int WeaponCards { get; set; }
        public int PossibleWeaponCards { get; set; }
        public int? SelectedWeaponCards { get; set; }
        public int SpellCards { get; set; }
        public int PossibleSpellCards { get; set; }
        public int? SelectedSpellCards { get; set; }
        public int ArmorCards { get; set; }
        public int PossibleArmorCards { get; set; }
        public int? SelectedArmorCards { get; set; }
        public int ItemCards { get; set; }
        public int PossibleItemCards { get; set; }
        public int? SelectedItemCards { get; set; }
        public int AllyCards { get; set; }
        public int PossibleAllyCards { get; set; }
        public int? SelectedAllyCards { get; set; }
        public int BlessingCards { get; set; }
        public int PossibleBlessingCards { get; set; }
        public int? SelectedBlessingCards { get; set; }
        public int HandSize { get; set; }
        public int PossibleHandSize { get; set; }
        public int? SelectedHandSize { get; set; }
        public string FavoredCardType { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Power> Powers { get; set; }

        public static Character Get(int partyCharacterId)
        {
            var character = new Character();

            var partyCharacterData = DataAccess.Dto.PartyCharacter.Get(partyCharacterId);
            character = new Character(partyCharacterData);

            return character;
        }
        public void Update()
        {
            var partyCharacterData = DataAccess.Dto.PartyCharacter.Get(Id);
            partyCharacterData.AllyCards = SelectedAllyCards;
            partyCharacterData.ArmorCards = SelectedArmorCards;
            partyCharacterData.BlessingCards = SelectedBlessingCards;
            partyCharacterData.ItemCards = SelectedItemCards;
            partyCharacterData.SpellCards = SelectedSpellCards;
            partyCharacterData.WeaponCards = SelectedWeaponCards;
            partyCharacterData.CharacterCardId = CharacterCardId;
            partyCharacterData.HandSize = SelectedHandSize;
            partyCharacterData.HeavyArmors = HeavyArmors;
            partyCharacterData.LightArmors = LightArmors;
            partyCharacterData.Weapons = Weapons;
            partyCharacterData.Update();
        }
        public void Persist()
        {
            var partyCharacter = new DataAccess.Dto.PartyCharacter();
            partyCharacter.PartyId = PartyId;
            partyCharacter.CharacterCardId = CharacterCardId;

            partyCharacter.Persist();

            Id = partyCharacter.Id;
        }
        public void Delete()
        {
            var partyCharacter = DataAccess.Dto.PartyCharacter.Get(Id);
            partyCharacter.Delete();
        }

        public Character()
        {
        }

        internal Character(DataAccess.Dto.PartyCharacter partyCharacter) : this(partyCharacter, true)
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter, bool deepObjects)
        {
            Id = partyCharacter.Id;
            PartyId = partyCharacter.PartyId;
            CharacterCardId = partyCharacter.CharacterCardId;
            SelectedHandSize = partyCharacter.HandSize;
            SelectedWeaponCards = partyCharacter.WeaponCards;
            SelectedSpellCards = partyCharacter.SpellCards;
            SelectedArmorCards = partyCharacter.ArmorCards;
            SelectedItemCards = partyCharacter.ItemCards;
            SelectedAllyCards = partyCharacter.AllyCards;
            SelectedBlessingCards = partyCharacter.BlessingCards;

            var lightArmor = partyCharacter.LightArmors;
            var heavyArmor = partyCharacter.HeavyArmors;
            var weapons = partyCharacter.Weapons;

            Skills = new List<Skill>();
            Powers = new List<Power>();

            if (deepObjects)
            {
                var characterCard = DataAccess.Dto.CharacterCard.Get(partyCharacter.CharacterCardId);
                Name = characterCard.Name;
                HandSize = characterCard.BaseHandSize;
                LightArmors = (!lightArmor.HasValue || !(lightArmor.Value == 2)) ? characterCard.BaseLightArmors : lightArmor.Value;
                HeavyArmors = (!heavyArmor.HasValue || !(heavyArmor.Value == 2)) ? characterCard.BaseHeavyArmors : heavyArmor.Value;
                Weapons = (!weapons.HasValue || !(weapons.Value == 2)) ? characterCard.BaseWeapons : weapons.Value;
                WeaponCards = characterCard.BaseWeaponCards;
                SpellCards = characterCard.BaseSpellCards;
                ArmorCards = characterCard.BaseArmorCards;
                ItemCards = characterCard.BaseItemCards;
                AllyCards = characterCard.BaseAllyCards;
                BlessingCards = characterCard.BaseBlessingCards;
                PossibleHandSize = characterCard.PossibleHandSize;
                PossibleWeaponCards = characterCard.PossibleWeaponCards;
                PossibleSpellCards = characterCard.PossibleSpellCards;
                PossibleArmorCards = characterCard.PossibleArmorCards;
                PossibleItemCards = characterCard.PossibleItemCards;
                PossibleAllyCards = characterCard.PossibleAllyCards;
                PossibleBlessingCards = characterCard.PossibleBlessingCards;
                FavoredCardType = characterCard.FavoredCardType;

                var powers = DataAccess.Dto.Power.All(CharacterCardId);
                Powers.AddRange(powers.Select(p => new Power(p, partyCharacter.Id)));

                var skills = DataAccess.Dto.Skill.All(CharacterCardId);
                Skills.AddRange(skills.Select(s => new Skill(s, Id)));
            }
        }
    }
}
