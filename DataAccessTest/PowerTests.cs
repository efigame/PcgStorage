using DataAccess.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void GivenPowerInDbWhenCallingPowerGetThenTheCorrectPowerIsReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedPower = new Power { Text = "Awesome Power", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };
            expectedPower.Persist();

            // Act
            var actual = Power.Get(expectedPower.Id);

            // Assert
            Assert.AreEqual(expectedPower.Text, actual.Text);
            Assert.AreEqual(expectedPower.Number, actual.Number);
            Assert.AreEqual(expectedPower.Adjustment, actual.Adjustment);
            Assert.AreEqual(expectedPower.Dice, actual.Dice);
            Assert.AreEqual(expectedPower.CharacterCardId, actual.CharacterCardId);

            // Cleanup
            expectedPower.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoPowersInDbWhenCallingPowerAllByCharacterCardIdThenBothPowersAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedPower1 = new Power { Text = "Awesome Power 1", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };
            var expectedPower2 = new Power { Text = "Awesome Power 2", Number = 2, Adjustment = 1, Dice = 4, CharacterCardId = characterCard.Id };

            expectedPower1.Persist();
            expectedPower2.Persist();

            // Act
            var actual = Power.All(characterCard.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.Text == expectedPower1.Text));
            Assert.IsNotNull(actual.Find(a => a.Text == expectedPower2.Text));

            // Cleanup
            expectedPower1.Delete();
            expectedPower2.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenPowerInDbWhenCallingPowerAllByWrongCharacterCardIdThenNoPowersAreReturned()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var wrongCharacterCard = new CharacterCard { Name = "Daisy Duck" };
            wrongCharacterCard.Persist();

            var expectedPower = new Power { Text = "Awesome Power", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };
            expectedPower.Persist();

            // Act
            var actual = Power.All(wrongCharacterCard.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedPower.Delete();
            wrongCharacterCard.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenNewPowerWhenCallingPersistThenThePowerIsCreatedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var newPower = new Power { Text = "Awesome Power", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };

            // Act
            newPower.Persist();

            // Assert
            var actual = Power.Get(newPower.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newPower.Text, actual.Text);
            Assert.AreEqual(newPower.Number, actual.Number);
            Assert.AreEqual(newPower.Dice, actual.Dice);
            Assert.AreEqual(newPower.Adjustment, actual.Adjustment);
            Assert.AreEqual(newPower.CharacterCardId, actual.CharacterCardId);

            // Cleanup
            newPower.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenPowerInDbWhenCallingUpdateThenThePowerIsUpdatedInDb()
        {
            // Arrange
            var expectedText = "Awesome Power 2";
            var expectedNumber = 2;
            var expectedDice = 8;
            var expectedAdjustment = 4;

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var powerInDb = new Power { Text = "Awesome Power", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };
            powerInDb.Persist();

            // Act
            var actualPower = Power.Get(powerInDb.Id);
            actualPower.Text = expectedText;
            actualPower.Number = expectedNumber;
            actualPower.Dice = expectedDice;
            actualPower.Adjustment = expectedAdjustment;
            actualPower.Update();

            var actual = Power.Get(powerInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(powerInDb.Id, actual.Id);
            Assert.AreEqual(expectedText, actual.Text);
            Assert.AreEqual(expectedNumber, actual.Number);
            Assert.AreEqual(expectedDice, actual.Dice);
            Assert.AreEqual(expectedAdjustment, actual.Adjustment);

            // Cleanup
            powerInDb.Delete();
            characterCard.Delete();
        }

        [TestMethod]
        public void GivenPowerInDbWhenCallingDeleteThenThePowerIsDeletedInDb()
        {
            // Arrange
            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var powerInDb = new Power { Text = "Awesome Power", Number = 1, Adjustment = 2, Dice = 6, CharacterCardId = characterCard.Id };
            powerInDb.Persist();

            // Act
            var power = Power.Get(powerInDb.Id);
            power.Delete();

            var actual = Power.Get(powerInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            powerInDb.Delete();
            characterCard.Delete();
        }

    }
}
