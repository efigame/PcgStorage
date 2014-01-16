using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class CharacterSkillTests
    {
        [TestMethod]
        public void GivenCharacterSkillInDbWhenCallingCharacterSkillGetThenTheCorrectCharacterSkillIsReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var skill = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            skill.Persist();

            var expectedCharacterSkill = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill.Id, SelectedAdjustment = 1 };
            expectedCharacterSkill.Persist();

            // Act
            var actual = CharacterSkill.Get(expectedCharacterSkill.Id);

            // Assert
            Assert.AreEqual(expectedCharacterSkill.PartyCharacterId, actual.PartyCharacterId);
            Assert.AreEqual(expectedCharacterSkill.SkillId, actual.SkillId);
            Assert.AreEqual(expectedCharacterSkill.SelectedAdjustment, actual.SelectedAdjustment);

            // Cleanup
            expectedCharacterSkill.Delete();
            skill.Delete();
            partyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenTwoCharacterSkillsInDbWhenCallingCharacterSkillAllByPartyCharacterIdThenBothCharacterSkillsAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var skill1 = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            var skill2 = new Skill { CharacterCardId = characterCard.Id, Dice = 6, Name = "Daisy skill", PossibleAddons = 3 };
            
            skill1.Persist();
            skill2.Persist();

            var expectedCharacterSkill1 = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill1.Id, SelectedAdjustment = 1 };
            var expectedCharacterSkill2 = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill2.Id, SelectedAdjustment = 2 };

            expectedCharacterSkill1.Persist();
            expectedCharacterSkill2.Persist();

            // Act
            var actual = CharacterSkill.All(partyCharacter.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.SkillId == skill1.Id));
            Assert.IsNotNull(actual.Find(a => a.SkillId == skill2.Id));

            // Cleanup
            expectedCharacterSkill1.Delete();
            expectedCharacterSkill2.Delete();
            skill1.Delete();
            skill2.Delete();
            partyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenCharacterSkillInDbWhenCallingCharacterSkillAllByWrongPartyCharacterIdThenNoCharacterSkillsAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var wrongCharacterCard = new CharacterCard { Name = "Daisy Duck" };
            wrongCharacterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var wrongPartyCharacter = new PartyCharacter { CharacterCardId = wrongCharacterCard.Id, PartyId = party.Id };
            wrongPartyCharacter.Persist();

            var skill = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            skill.Persist();

            var expectedCharacterSkill = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill.Id, SelectedAdjustment = 1 };
            expectedCharacterSkill.Persist();

            // Act
            var actual = CharacterSkill.All(wrongPartyCharacter.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedCharacterSkill.Delete();
            skill.Delete();
            wrongPartyCharacter.Delete();
            partyCharacter.Delete();
            wrongCharacterCard.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenNewCharacterSkillWhenCallingPersistThenTheCharacterSkillIsCreatedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var skill = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            skill.Persist();

            var newCharacterSkill = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill.Id, SelectedAdjustment = 1 };

            // Act
            newCharacterSkill.Persist();

            // Assert
            var actual = CharacterSkill.Get(newCharacterSkill.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newCharacterSkill.PartyCharacterId, actual.PartyCharacterId);
            Assert.AreEqual(newCharacterSkill.SkillId, actual.SkillId);
            Assert.AreEqual(newCharacterSkill.SelectedAdjustment, actual.SelectedAdjustment);

            // Cleanup
            newCharacterSkill.Delete();
            skill.Delete();
            partyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenCharacterSkillInDbWhenCallingUpdateThenTheCharacterSkillIsUpdatedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var skill = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            skill.Persist();

            var characterskillInDb = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill.Id, SelectedAdjustment = 1 };
            characterskillInDb.Persist();

            var expectedSelectedAdjustment = 2;

            var expectedCharacterCard = new CharacterCard { Name = "Daisy Duck" };
            expectedCharacterCard.Persist();

            var expectedSkill = new Skill { CharacterCardId = characterCard.Id, Dice = 3, Name = "Daisy skill", PossibleAddons = 3 };
            expectedSkill.Persist();

            var expectedPartyCharacter = new PartyCharacter { CharacterCardId = expectedCharacterCard.Id, PartyId = party.Id };
            expectedPartyCharacter.Persist();

            // Act
            var actualCharacterSkill = CharacterSkill.Get(characterskillInDb.Id);
            actualCharacterSkill.PartyCharacterId = expectedPartyCharacter.Id;
            actualCharacterSkill.SkillId = expectedSkill.Id;
            actualCharacterSkill.SelectedAdjustment = expectedSelectedAdjustment;
            actualCharacterSkill.Update();

            var actual = CharacterSkill.Get(characterskillInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(characterskillInDb.Id, actual.Id);
            Assert.AreEqual(expectedPartyCharacter.Id, actual.PartyCharacterId);
            Assert.AreEqual(expectedSkill.Id, actual.SkillId);
            Assert.AreEqual(expectedSelectedAdjustment, actual.SelectedAdjustment);

            // Cleanup
            skill.Delete();
            partyCharacter.Delete();
            characterskillInDb.Delete();
            expectedPartyCharacter.Delete();
            expectedSkill.Delete();
            expectedCharacterCard.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyCharacterInDbWhenCallingDeleteThenThePartyCharacterIsDeletedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var partyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacter.Persist();

            var skill = new Skill { CharacterCardId = characterCard.Id, Dice = 4, Name = "Duck skill", PossibleAddons = 2 };
            skill.Persist();

            var characterSkillInDb = new CharacterSkill { PartyCharacterId = partyCharacter.Id, SkillId = skill.Id, SelectedAdjustment = 1 };
            characterSkillInDb.Persist();

            // Act
            var characterSkill = CharacterSkill.Get(characterSkillInDb.Id);
            characterSkill.Delete();

            var actual = CharacterSkill.Get(characterSkillInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            characterSkillInDb.Delete();
            skill.Delete();
            partyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

    }
}
