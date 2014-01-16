using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class SubSkillTests
    {
        [TestMethod]
        public void GivenSubSkillInDbWhenCallingSubSkillGetThenTheCorrectSubSkillIsReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var expectedSubSkill = new SubSkill { Name = "Hilarious SubSkill", Adjustment = 2, BaseSkillId = skill.Id };
            expectedSubSkill.Persist();

            // Act
            var actual = SubSkill.Get(expectedSubSkill.Id);

            // Assert
            Assert.AreEqual(expectedSubSkill.Name, actual.Name);
            Assert.AreEqual(expectedSubSkill.Adjustment, actual.Adjustment);
            Assert.AreEqual(expectedSubSkill.BaseSkillId, actual.BaseSkillId);

            // Cleanup
            expectedSubSkill.Delete();
            skill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoSubSkillsInDbWithSkillIdWhenCallingSubSkillAllBySkillIdThenBothSubSkillsAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var expectedSubSkill1 = new SubSkill { Name = "Hilarious SubSkill 1", Adjustment = 2, BaseSkillId = skill.Id };
            var expectedSubSkill2 = new SubSkill { Name = "Hilarious SubSkill 2", Adjustment = 4, BaseSkillId = skill.Id };

            expectedSubSkill1.Persist();
            expectedSubSkill2.Persist();

            // Act
            var actual = SubSkill.All(skill.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.Name == expectedSubSkill1.Name));
            Assert.IsNotNull(actual.Find(a => a.Name == expectedSubSkill2.Name));

            // Cleanup
            expectedSubSkill1.Delete();
            expectedSubSkill2.Delete();
            skill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSubSkillInDbWhenCallingSubSkillAllByWrongSkillIdThenNoSubSkillsAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var wrongSkill = new Skill { Name = "Bad Skill", Dice = 8, PossibleAddons = 4, CharacterCardId = characterCard.Id };
            wrongSkill.Persist();

            var expectedSubSkill = new SubSkill { Name = "Hilarious SubSkill", Adjustment = 2, BaseSkillId = skill.Id };
            expectedSubSkill.Persist();

            // Act
            var actual = SubSkill.All(wrongSkill.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedSubSkill.Delete();
            wrongSkill.Delete();
            skill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenNewSubSkillWhenCallingPersistThenTheSubSkillIsCreatedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var newSubSkill = new SubSkill { Name = "Hilarious SubSkill", Adjustment = 2, BaseSkillId = skill.Id };

            // Act
            newSubSkill.Persist();

            // Assert
            var actual = SubSkill.Get(newSubSkill.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newSubSkill.Name, actual.Name);
            Assert.AreEqual(newSubSkill.Adjustment, actual.Adjustment);
            Assert.AreEqual(newSubSkill.BaseSkillId, actual.BaseSkillId);

            // Cleanup
            newSubSkill.Delete();
            skill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSubSkillInDbWhenCallingUpdateThenTheSubSkillIsUpdatedInDb()
        {
            // Arrange
            var expectedName = "Hilarious SubSkill 2";
            var expectedAdjustment = 8;

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var subSkillInDb = new SubSkill { Name = "Hilarious SubSkill", Adjustment = 2, BaseSkillId = skill.Id };
            subSkillInDb.Persist();

            // Act
            var actualSkill = SubSkill.Get(subSkillInDb.Id);
            actualSkill.Name = expectedName;
            actualSkill.Adjustment = expectedAdjustment;
            actualSkill.Update();

            var actual = SubSkill.Get(subSkillInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(subSkillInDb.Id, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);

            // Cleanup
            subSkillInDb.Delete();
            skill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSubSkillInDbWhenCallingDeleteThenTheSubSkillIsDeletedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skill.Persist();

            var subSkillInDb = new SubSkill { Name = "Hilarious SubSkill", Adjustment = 2, BaseSkillId = skill.Id };
            subSkillInDb.Persist();

            // Act
            var subSkill = SubSkill.Get(subSkillInDb.Id);
            subSkill.Delete();

            var actual = SubSkill.Get(subSkillInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            subSkillInDb.Delete();
            skill.Delete();
            characterCard.Delete();
        }

    }
}
