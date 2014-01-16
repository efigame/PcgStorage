using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class CharacterCardTests
    {
        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingCharacterCardGetThenTheCorrectCharacterCardIsReturned()
        {
            // Arrange
            var expectedCharacterCard = new CharacterCard { Name = "Donald Duck" };
            expectedCharacterCard.Persist();

            // Act
            var actual = CharacterCard.Get(expectedCharacterCard.Id);

            // Assert
            Assert.AreEqual(expectedCharacterCard.Name, actual.Name);

            // Cleanup
            expectedCharacterCard.Delete();
        }

        [TestMethod]
        public void GivenTwoCharacterCardsInDbWhenCallingCharacterCardAllThenTheBothCharacterCardsAreReturned()
        {
            // Arrange
            var expectedCharacterCard1 = new CharacterCard { Name = "Donald Duck" };
            var expectedCharacterCard2 = new CharacterCard { Name = "Daisy Duck" };

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
            var newCharacterCard = new CharacterCard { Name = "Donald Duck" };

            // Act
            newCharacterCard.Persist();

            // Assert
            var actual = CharacterCard.Get(newCharacterCard.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newCharacterCard.Name, actual.Name);

            // Cleanup
            newCharacterCard.Delete();
        }

        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingUpdateThenTheCharacterCardIsUpdatedInDb()
        {
            // Arrange
            var expectedName = "Donald Duck";

            var characterCardIdDb = new CharacterCard { Name = "Daisy Duck" };
            characterCardIdDb.Persist();

            // Act
            var actualCharacterCard = CharacterCard.Get(characterCardIdDb.Id);
            actualCharacterCard.Name = expectedName;
            actualCharacterCard.Update();

            var actual = CharacterCard.Get(characterCardIdDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(characterCardIdDb.Id, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);
            
            // Cleanup
            characterCardIdDb.Delete();
        }

        [TestMethod]
        public void GivenCharacterCardInDbWhenCallingDeleteThenTheCharacterCardIsDeletedInDb()
        {
            // Arrange
            var characterCardIdDb = new CharacterCard { Name = "Donald Duck" };
            characterCardIdDb.Persist();

            // Act
            var characterCard = CharacterCard.Get(characterCardIdDb.Id);
            characterCard.Delete();

            var actual = CharacterCard.Get(characterCardIdDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            characterCardIdDb.Delete();
        }

    }
}
