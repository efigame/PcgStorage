using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class PartyCharacterTests
    {
        [TestMethod]
        public void GivenPartyCharacterInDbWhenCallingPartyCharacterGetThenTheCorrectPartyCharacterIsReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedPartyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            expectedPartyCharacter.Persist();

            // Act
            var actual = PartyCharacter.Get(expectedPartyCharacter.Id);

            // Assert
            Assert.AreEqual(expectedPartyCharacter.CharacterCardId, actual.CharacterCardId);
            Assert.AreEqual(expectedPartyCharacter.PartyId, actual.PartyId);

            // Cleanup
            expectedPartyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenTwoPartyCharactersInDbWhenCallingPartyCharacterAllThenTheBothPartyCharactersAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard1 = new CharacterCard { Name = "Donald Duck" };
            var characterCard2 = new CharacterCard { Name = "Daisy Duck" };

            characterCard1.Persist();
            characterCard2.Persist();

            var expectedPartyCharacter1 = new PartyCharacter { CharacterCardId = characterCard1.Id, PartyId = party.Id };
            var expectedPartyCharacter2 = new PartyCharacter { CharacterCardId = characterCard2.Id, PartyId = party.Id };

            expectedPartyCharacter1.Persist();
            expectedPartyCharacter2.Persist();

            // Act
            var actual = PartyCharacter.All(party.Id);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsNotNull(actual.Find(a => a.CharacterCardId == expectedPartyCharacter1.CharacterCardId));
            Assert.IsNotNull(actual.Find(a => a.CharacterCardId == expectedPartyCharacter2.CharacterCardId));

            // Cleanup
            expectedPartyCharacter1.Delete();
            expectedPartyCharacter2.Delete();
            characterCard1.Delete();
            characterCard2.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyCharacterInDbWhenCallingPartyCharacterAllByWrongPartyIdThenTheNoPartyCharactersAreReturned()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var wrongParty = new Party { Name = "Daisy Duck party", PcgUserId = user.Id };
            wrongParty.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedPartyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            expectedPartyCharacter.Persist();

            // Act
            var actual = PartyCharacter.All(wrongParty.Id);

            // Assert
            Assert.AreEqual(0, actual.Count);

            // Cleanup
            expectedPartyCharacter.Delete();
            characterCard.Delete();
            wrongParty.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenNewPartyCharacterWhenCallingPersistThenThePartyCharacterIsCreatedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var newPartyCharacter = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };

            // Act
            newPartyCharacter.Persist();

            // Assert
            var actual = PartyCharacter.Get(newPartyCharacter.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newPartyCharacter.CharacterCardId, actual.CharacterCardId);
            Assert.AreEqual(newPartyCharacter.PartyId, actual.PartyId);

            // Cleanup
            newPartyCharacter.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

        [TestMethod]
        public void GivenPartyCharacterInDbWhenCallingUpdateThenThePartyCharacterIsUpdatedInDb()
        {
            // Arrange
            var user = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            user.Persist();

            var party = new Party { Name = "Donald Duck party", PcgUserId = user.Id };
            party.Persist();

            var characterCard = new CharacterCard { Name = "Donald Duck" };
            characterCard.Persist();

            var expectedParty = new Party { Name = "Daisy Duck party", PcgUserId = user.Id };
            expectedParty.Persist();

            var expectedCharacterCard = new CharacterCard { Name = "Daisy Duck" };
            expectedCharacterCard.Persist();

            var partyCharacterInDb = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacterInDb.Persist();

            // Act
            var actualParty = PartyCharacter.Get(partyCharacterInDb.Id);
            actualParty.CharacterCardId = expectedCharacterCard.Id;
            actualParty.PartyId = expectedParty.Id;
            actualParty.Update();

            var actual = PartyCharacter.Get(partyCharacterInDb.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(partyCharacterInDb.Id, actual.Id);
            Assert.AreEqual(expectedCharacterCard.Id, actual.CharacterCardId);
            Assert.AreEqual(expectedParty.Id, actual.PartyId);

            // Cleanup
            partyCharacterInDb.Delete();
            expectedCharacterCard.Delete();
            expectedParty.Delete();
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

            var partyCharacterInDb = new PartyCharacter { CharacterCardId = characterCard.Id, PartyId = party.Id };
            partyCharacterInDb.Persist();

            // Act
            var partyCharacter = PartyCharacter.Get(partyCharacterInDb.Id);
            partyCharacter.Delete();

            var actual = PartyCharacter.Get(partyCharacterInDb.Id);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            partyCharacterInDb.Delete();
            characterCard.Delete();
            party.Delete();
            user.Delete();
        }

    }
}
