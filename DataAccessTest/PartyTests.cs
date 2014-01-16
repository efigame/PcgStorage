using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class PartyTests
    {
        [TestMethod]
        public void GivenPartyInDbWhenCallingPartyGetThenTheCorrectPartyIsReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var expectedParty = new Party { Name = "donald duck party", PcgUserId = user.Id };
            expectedParty.Persist();

            // Act
            var actual = Party.Get(expectedParty.Id);

            // Assert
            Assert.AreEqual(expectedParty.Name, actual.Name);
            Assert.AreEqual(expectedParty.PcgUserId, actual.PcgUserId);

            // Cleanup
            expectedParty.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenTwoPartiesInDbWithUserIdWhenCallingPartyAllByUserIdThenTheBothPartiesAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var expectedParty1 = new Party { Name = "donald duck party 1", PcgUserId = user.Id };
            var expectedParty2 = new Party { Name = "donald duck party 2", PcgUserId = user.Id };

            expectedParty1.Persist();
            expectedParty2.Persist();

            // Act
            var actual = Party.All(user.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.Name == expectedParty1.Name));
            Assert.IsNotNull(actual.Find(a => a.Name == expectedParty2.Name));

            // Cleanup
            expectedParty1.Delete();
            expectedParty2.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyInDbWhenCallingPartyAllByWrongUserIdThenTheNoPartiesAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var wrongUser = new PcgUser { Email = "bbb@efigame.com", Password = "bbb" };
            wrongUser.Persist();

            var expectedParty = new Party { Name = "donald duck party", PcgUserId = user.Id };
            expectedParty.Persist();

            // Act
            var actual = Party.All(wrongUser.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedParty.Delete();
            wrongUser.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenNewPartyWhenCallingPersistThenThePartyIsCreatedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var newParty = new Party { Name = "donald duck party", PcgUserId = user.Id };

            // Act
            newParty.Persist();

            // Assert
            var actual = Party.Get(newParty.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newParty.Name, actual.Name);
            Assert.AreEqual(newParty.PcgUserId, actual.PcgUserId);

            // Cleanup
            newParty.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyInDbWhenCallingUpdateThenThePartyIsUpdatedInDb()
        {
            // Arrange
            var expectedName = "donald duck party 2";

            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var partyIdDb = new Party { Name = "donald duck party", PcgUserId = user.Id };
            partyIdDb.Persist();

            // Act
            var actualParty = Party.Get(partyIdDb.Id);
            actualParty.Name = expectedName;
            actualParty.Update();

            var actual = Party.Get(partyIdDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(partyIdDb.Id, actual.Id);
            Assert.AreEqual(expectedName, actual.Name);

            // Cleanup
            partyIdDb.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyInDbWhenCallingDeleteThenThePartyIsDeletedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var partyIdDb = new Party { Name = "donald duck party", PcgUserId = user.Id };
            partyIdDb.Persist();

            // Act
            var party = Party.Get(partyIdDb.Id);
            party.Delete();

            var actual = Party.Get(partyIdDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            partyIdDb.Delete();
            user.Delete();
        }

    }
}
