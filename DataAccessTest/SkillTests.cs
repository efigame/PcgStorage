using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class SkillTests
    {
        [TestMethod]
        public void GivenSkillInDbWhenCallingSkillGetThenTheCorrectSkillIsReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedSkill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            expectedSkill.Persist();

            // Act
            var actual = Skill.Get(expectedSkill.Id);

            // Assert
            Assert.AreEqual(expectedSkill.Name, actual.Name);
            Assert.AreEqual(expectedSkill.Dice, actual.Dice);
            Assert.AreEqual(expectedSkill.PossibleAddons, actual.PossibleAddons);
            Assert.AreEqual(expectedSkill.CharacterCardId, actual.CharacterCardId);

            // Cleanup
            expectedSkill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoSkillsInDbWhenCallingSkillAllByCharacterCardIdThenBothSkillsAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedSkill1 = new Skill { Name = "Awesome Skill 1", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            var expectedSkill2 = new Skill { Name = "Awesome Skill 2", Dice = 8, PossibleAddons = 4, CharacterCardId = characterCard.Id };

            expectedSkill1.Persist();
            expectedSkill2.Persist();

            // Act
            var actual = Skill.All(characterCard.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.Name == expectedSkill1.Name));
            Assert.IsNotNull(actual.Find(a => a.Name == expectedSkill2.Name));

            // Cleanup
            expectedSkill1.Delete();
            expectedSkill2.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSkillInDbWhenCallingSkillAllByWrongCharacterCardIdThenNoSkillsAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var wrongCharacterCard = new CharacterCard { Name = "Daisy Duck" };
            wrongCharacterCard.Persist();

            var expectedSkill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            expectedSkill.Persist();

            // Act
            var actual = Skill.All(wrongCharacterCard.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedSkill.Delete();
            wrongCharacterCard.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenNewSkillWhenCallingPersistThenTheSkillIsCreatedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var newSkill = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };

            // Act
            newSkill.Persist();

            // Assert
            var actual = Skill.Get(newSkill.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newSkill.Name, actual.Name);
            Assert.AreEqual(newSkill.Dice, actual.Dice);
            Assert.AreEqual(newSkill.PossibleAddons, actual.PossibleAddons);
            Assert.AreEqual(newSkill.CharacterCardId, actual.CharacterCardId);

            // Cleanup
            newSkill.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSkillInDbWhenCallingUpdateThenTheSkillIsUpdatedInDb()
        {
            // Arrange
            var expectedName = "Awesome Skill 2";
            var expectedDice = 8;
            var expectedPossibleAddons = 4;

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skillInDb = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skillInDb.Persist();

            // Act
            var actualSkill = Skill.Get(skillInDb.Id);
            actualSkill.Name = expectedName;
            actualSkill.Dice = expectedDice;
            actualSkill.PossibleAddons = expectedPossibleAddons;
            actualSkill.Update();

            var actual = Skill.Get(skillInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(skillInDb.Id, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);

            // Cleanup
            skillInDb.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenSkillInDbWhenCallingDeleteThenTheSkillIsDeletedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var skillInDb = new Skill { Name = "Awesome Skill", Dice = 6, PossibleAddons = 2, CharacterCardId = characterCard.Id };
            skillInDb.Persist();

            // Act
            var skill = Skill.Get(skillInDb.Id);
            skill.Delete();

            var actual = Skill.Get(skillInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            skillInDb.Delete();
            characterCard.Delete();
        }

    }
}
