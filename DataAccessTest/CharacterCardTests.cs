using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;
using System.Collections.Generic;

namespace DataAccessTest
{
    [TestClass]
    public class CharacterCardTests
    {
        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingCharacterCardGetThenTheCorrectCharacterCardIsReturned()
        {
            // Arrange
            var expectedCharacterCard = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false };
            expectedCharacterCard.Persist();

            // Act
            var actual = CharacterCard.Get(expectedCharacterCard.Id);

            // Assert
            Assert.AreEqual(expectedCharacterCard.Name, actual.Name);
            Assert.AreEqual(expectedCharacterCard.BaseHandSize, actual.BaseHandSize);
            Assert.AreEqual(expectedCharacterCard.BaseLightArmors, actual.BaseLightArmors);
            Assert.AreEqual(expectedCharacterCard.BaseHeavyArmors, actual.BaseHeavyArmors);
            Assert.AreEqual(expectedCharacterCard.BaseWeapons, actual.BaseWeapons);

            // Cleanup
            expectedCharacterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoCharacterCardsInDbWhenCallingCharacterCardAllThenBothCharacterCardsAreReturned()
        {
            // Arrange
            var expectedCharacterCard1 = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false };
            var expectedCharacterCard2 = new CharacterCard { Name = "Daisy Duck", BaseHandSize = 3, BaseLightArmors = false, BaseHeavyArmors = false, BaseWeapons = true };

            expectedCharacterCard1.Persist();
            expectedCharacterCard2.Persist();

            // Act
            var actual = CharacterCard.All();

            // Assert
            Assert.IsTrue(actual.Count >= 2);
            Assert.IsNotNull(actual.Find(a => a.Name == expectedCharacterCard1.Name));
            Assert.IsNotNull(actual.Find(a => a.Name == expectedCharacterCard2.Name));

            // Cleanup
            expectedCharacterCard1.Delete();
            expectedCharacterCard2.Delete();
        }

        [TestMethod]
        public void GivenNewCharacterCardWhenCallingPersistThenTheCharacterCardIsCreatedInDb()
        {
            // Arrange
            var newCharacterCard = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false };

            // Act
            newCharacterCard.Persist();

            // Assert
            var actual = CharacterCard.Get(newCharacterCard.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newCharacterCard.Name, actual.Name);
            Assert.AreEqual(newCharacterCard.BaseHandSize, actual.BaseHandSize);
            Assert.AreEqual(newCharacterCard.BaseLightArmors, actual.BaseLightArmors);
            Assert.AreEqual(newCharacterCard.BaseHeavyArmors, actual.BaseHeavyArmors);
            Assert.AreEqual(newCharacterCard.BaseWeapons, actual.BaseWeapons);

            // Cleanup
            newCharacterCard.Delete();
        }

        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingUpdateThenTheCharacterCardIsUpdatedInDb()
        {
            // Arrange
            var expectedName = "Donald Duck";
            var expectedBaseHandSize = 5;
            var expectedBaseLightArmors = true;
            var expectedBaseHeavyArmors = true;
            var expectedBaseWeapons = false;

            var characterCardInDb = new CharacterCard { Name = "Daisy Duck", BaseHandSize = 3, BaseLightArmors = false, BaseHeavyArmors = false, BaseWeapons = true };
            characterCardInDb.Persist();

            // Act
            var actualCharacterCard = CharacterCard.Get(characterCardInDb.Id);
            actualCharacterCard.Name = expectedName;
            actualCharacterCard.BaseHandSize = expectedBaseHandSize;
            actualCharacterCard.BaseLightArmors = expectedBaseLightArmors;
            actualCharacterCard.BaseHeavyArmors = expectedBaseHeavyArmors;
            actualCharacterCard.BaseWeapons = expectedBaseWeapons;
            actualCharacterCard.Update();

            var actual = CharacterCard.Get(characterCardInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(characterCardInDb.Id, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedBaseHandSize, actual.BaseHandSize);
            Assert.AreEqual(expectedBaseLightArmors, actual.BaseLightArmors);
            Assert.AreEqual(expectedBaseHeavyArmors, actual.BaseHeavyArmors);
            Assert.AreEqual(expectedBaseWeapons, actual.BaseWeapons);
            
            // Cleanup
            characterCardInDb.Delete();
        }

        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingDeleteThenTheCharacterCardIsDeletedInDb()
        {
            // Arrange
            var characterCardInDb = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false };
            characterCardInDb.Persist();

            // Act
            var characterCard = CharacterCard.Get(characterCardInDb.Id);
            characterCard.Delete();

            var actual = CharacterCard.Get(characterCardInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            characterCardInDb.Delete();
        }

    }
}
