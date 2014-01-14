using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccess;
using Moq;
using System.Data.Entity;
using System.Linq;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class CharacterCardTests
    {
        [TestMethod]
        public void GivenListOfCharacterCardsWhenGettingAllThenTheListIsReturned()
        {
            // Arrange
            var expected1 = "AAA";
            var expected2 = "BBB";
            var expected3 = "CCC";

            var data = new List<charactercard>
            {
                new charactercard { Id = 1, Name = expected1 },
                new charactercard { Id = 2, Name = expected2 },
                new charactercard { Id = 3, Name = expected3 }
            };

            var mock = new CharacterCardMock(data);
            var context = new DataContext(mock.MockContext.Object);

            // Act
            var actual = CharacterCard.All(context);

            // Assert
            Assert.AreEqual(data.Count(), actual.Count());
            Assert.AreEqual(expected1, actual[0].Name);
            Assert.AreEqual(expected2, actual[1].Name);
            Assert.AreEqual(expected3, actual[2].Name);
        }

        [TestMethod]
        public void GivenListOfCharacterCardsWhenGettingByIdThenTheSpecificCharacterCardIsReturned()
        {
            // Arrange
            var expectedName = "ABC";
            var expectedId = 123;

            var data = new List<charactercard>
            {
                new charactercard { Id = 1, Name = "AAA" },
                new charactercard { Id = 2, Name = "BBB" },
                new charactercard { Id = 3, Name = "CCC" },
                new charactercard { Id = expectedId, Name = expectedName }
            };

            var mock = new CharacterCardMock(data);
            var context = new DataContext(mock.MockContext.Object);

            // Act
            var actual = CharacterCard.Get(expectedId, context);

            // Assert
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);
        }

        [TestMethod]
        public void GivenNewCharacterCardWhenPersistingThenTheCharacterCardIsStoredInTheContext()
        {
            // Arrange
            var expectedName = "ABC";
            var expectedId = 123;

            var data = new List<charactercard>
            {
                new charactercard { Id = 1, Name = "AAA" },
                new charactercard { Id = 2, Name = "BBB" },
                new charactercard { Id = 3, Name = "CCC" },
            };

            var mock = new CharacterCardMock(data);
            var context = new DataContext(mock.MockContext.Object);

            var characterCard = new CharacterCard(context);
            characterCard.Id = expectedId;
            characterCard.Name = expectedName;

            // Act
            characterCard.Persist();
            var actual = CharacterCard.Get(characterCard.Id, context);

            // Assert
            mock.MockSet.Verify(m => m.Add(It.IsAny<charactercard>()), Times.Once());
            mock.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
