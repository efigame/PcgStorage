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
            var expectedCharacterCard = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false, 
                BaseWeaponCards = 3, BaseSpellCards = 4, BaseArmorCards = 5, BaseItemCards = 6, BaseAllyCards = 7, BaseBlessingCards = 8 };
            expectedCharacterCard.Persist();

            // Act
            var actual = CharacterCard.Get(expectedCharacterCard.Id);

            // Assert
            Assert.AreEqual(expectedCharacterCard.Name, actual.Name);
            Assert.AreEqual(expectedCharacterCard.BaseHandSize, actual.BaseHandSize);
            Assert.AreEqual(expectedCharacterCard.BaseLightArmors, actual.BaseLightArmors);
            Assert.AreEqual(expectedCharacterCard.BaseHeavyArmors, actual.BaseHeavyArmors);
            Assert.AreEqual(expectedCharacterCard.BaseWeapons, actual.BaseWeapons);
            Assert.AreEqual(expectedCharacterCard.BaseWeaponCards, actual.BaseWeaponCards);
            Assert.AreEqual(expectedCharacterCard.BaseSpellCards, actual.BaseSpellCards);
            Assert.AreEqual(expectedCharacterCard.BaseArmorCards, actual.BaseArmorCards);
            Assert.AreEqual(expectedCharacterCard.BaseItemCards, actual.BaseItemCards);
            Assert.AreEqual(expectedCharacterCard.BaseAllyCards, actual.BaseAllyCards);
            Assert.AreEqual(expectedCharacterCard.BaseBlessingCards, actual.BaseBlessingCards);

            // Cleanup
            expectedCharacterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoCharacterCardsInDbWhenCallingCharacterCardAllThenBothCharacterCardsAreReturned()
        {
            // Arrange
            var expectedCharacterCard1 = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false, 
                BaseWeaponCards = 3, BaseSpellCards = 4, BaseArmorCards = 5, BaseItemCards = 6, BaseAllyCards = 7, BaseBlessingCards = 8 };
            var expectedCharacterCard2 = new CharacterCard { Name = "Daisy Duck", BaseHandSize = 3, BaseLightArmors = false, BaseHeavyArmors = false, BaseWeapons = true, 
                BaseWeaponCards = 1, BaseSpellCards = 2, BaseArmorCards = 3, BaseItemCards = 4, BaseAllyCards = 5, BaseBlessingCards = 6 };

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
            var newCharacterCard = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false, 
                BaseWeaponCards = 3, BaseSpellCards = 4, BaseArmorCards = 5, BaseItemCards = 6, BaseAllyCards = 7, BaseBlessingCards = 8 };

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
            Assert.AreEqual(newCharacterCard.BaseWeaponCards, actual.BaseWeaponCards);
            Assert.AreEqual(newCharacterCard.BaseSpellCards, actual.BaseSpellCards);
            Assert.AreEqual(newCharacterCard.BaseArmorCards, actual.BaseArmorCards);
            Assert.AreEqual(newCharacterCard.BaseItemCards, actual.BaseItemCards);
            Assert.AreEqual(newCharacterCard.BaseAllyCards, actual.BaseAllyCards);
            Assert.AreEqual(newCharacterCard.BaseBlessingCards, actual.BaseBlessingCards);

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
            var expectedBaseWeaponCards = 1;
            var expectedBaseSpellCards = 2;
            var expectedBaseArmorCards = 3;
            var expectedBaseItemCards = 4;
            var expectedBaseAllyCards = 5;
            var expectedBaseBlessingCards = 6;

            var characterCardInDb = new CharacterCard { Name = "Daisy Duck", BaseHandSize = 3, BaseLightArmors = false, BaseHeavyArmors = false, BaseWeapons = true, 
                BaseWeaponCards = 3, BaseSpellCards = 4, BaseArmorCards = 5, BaseItemCards = 6, BaseAllyCards = 7, BaseBlessingCards = 8 };
            characterCardInDb.Persist();

            // Act
            var actualCharacterCard = CharacterCard.Get(characterCardInDb.Id);
            actualCharacterCard.Name = expectedName;
            actualCharacterCard.BaseHandSize = expectedBaseHandSize;
            actualCharacterCard.BaseLightArmors = expectedBaseLightArmors;
            actualCharacterCard.BaseHeavyArmors = expectedBaseHeavyArmors;
            actualCharacterCard.BaseWeapons = expectedBaseWeapons;
            actualCharacterCard.BaseWeaponCards = expectedBaseWeaponCards;
            actualCharacterCard.BaseSpellCards = expectedBaseSpellCards;
            actualCharacterCard.BaseArmorCards = expectedBaseArmorCards;
            actualCharacterCard.BaseItemCards = expectedBaseItemCards;
            actualCharacterCard.BaseAllyCards = expectedBaseAllyCards;
            actualCharacterCard.BaseBlessingCards = expectedBaseBlessingCards;
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
            Assert.AreEqual(expectedBaseWeaponCards, actual.BaseWeaponCards);
            Assert.AreEqual(expectedBaseSpellCards, actual.BaseSpellCards);
            Assert.AreEqual(expectedBaseArmorCards, actual.BaseArmorCards);
            Assert.AreEqual(expectedBaseItemCards, actual.BaseItemCards);
            Assert.AreEqual(expectedBaseAllyCards, actual.BaseAllyCards);
            Assert.AreEqual(expectedBaseBlessingCards, actual.BaseBlessingCards);

            // Cleanup
            characterCardInDb.Delete();
        }

        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingDeleteThenTheCharacterCardIsDeletedInDb()
        {
            // Arrange
            var characterCardInDb = new CharacterCard { Name = "Donald Duck", BaseHandSize = 5, BaseLightArmors = true, BaseHeavyArmors = true, BaseWeapons = false, 
                BaseWeaponCards = 3, BaseSpellCards = 4, BaseArmorCards = 5, BaseItemCards = 6, BaseAllyCards = 7, BaseBlessingCards = 8 };
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
