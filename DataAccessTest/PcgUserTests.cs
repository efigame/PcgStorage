using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Dto;

namespace DataAccessTest
{
    [TestClass]
    public class PcgUserTests
    {
        [TestMethod]
        public void GivenUserInDbWhenCallingUserGetByEmailAndPasswordThenTheCorrectUserIsReturned()
        {
            // Arrange
            var expectedUser = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            expectedUser.Persist();

            // Act
            var actual = PcgUser.Get(expectedUser.Email, expectedUser.Password);

            // Assert
            Assert.AreEqual(expectedUser.Email, actual.Email);
            Assert.AreEqual(expectedUser.Password, actual.Password);

            // Cleanup
            expectedUser.Delete();
        }

        [TestMethod]
        public void GivenTwoUsersInDbWhenCallingUserAllThenTheBothUsersAreReturned()
        {
            // Arrange
            var expectedUser1 = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            var expectedUser2 = new PcgUser { Email = "bbb@efigame.com", Password = "bbb" };

            expectedUser1.Persist();
            expectedUser2.Persist();

            // Act
            var actual = PcgUser.All();

            // Assert
            Assert.IsTrue(actual.Count >= 2);
            Assert.IsNotNull(actual.Find(a => a.Email == expectedUser1.Email));
            Assert.IsNotNull(actual.Find(a => a.Email == expectedUser2.Email));

            // Cleanup
            expectedUser1.Delete();
            expectedUser2.Delete();
        }

        [TestMethod]
        public void GivenUserInDbWhenCallingCheckUserByEmailThenTrueIsReturned()
        {
            // Arrange
            var databaseUser = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            databaseUser.Persist();

            // Act
            var actual = PcgUser.CheckUserByEmail(databaseUser.Email);

            // Assert
            Assert.IsTrue(actual);

            // Cleanup
            databaseUser.Delete();
        }

        [TestMethod]
        public void GivenNoUserInDbWhenCallingCheckUserByEmailThenFalseIsReturned()
        {
            // Arrange
            var databaseUser = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };

            // Act
            var actual = PcgUser.CheckUserByEmail(databaseUser.Email);

            // Assert
            Assert.IsFalse(actual);

            // Cleanup
        }

        [TestMethod]
        public void GivenNewUserWhenCallingPersistThenTheUserIsCreatedInDb()
        {
            // Arrange
            var newUser = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };

            // Act
            newUser.Persist();

            // Assert
            var actual = PcgUser.Get(newUser.Email, newUser.Password);

            Assert.IsNotNull(actual);
            Assert.AreEqual(newUser.Email, actual.Email);
            Assert.AreEqual(newUser.Password, actual.Password);

            // Cleanup
            newUser.Delete();
        }

        [TestMethod]
        public void GivenUserInDbWhenCallingUpdateThenTheUserIsUpdatedInDb()
        {
            // Arrange
            var expectedEmail = "bbb@efigame.com";
            var expectedPassword = "bbb";

            var userIdDb = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            userIdDb.Persist();

            // Act
            var actualUser = PcgUser.Get(userIdDb.Email, userIdDb.Password);
            actualUser.Email = expectedEmail;
            actualUser.Password = expectedPassword;
            actualUser.Update();

            var actual = PcgUser.Get(expectedEmail, expectedPassword);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(userIdDb.Id, actual.Id);
            Assert.AreEqual(expectedEmail, actual.Email);
            Assert.AreEqual(expectedPassword, actual.Password);

            // Cleanup
            userIdDb.Delete();
        }

        [TestMethod]
        public void GivenUserInDbWhenCallingDeleteThenTheUserIsDeletedInDb()
        {
            // Arrange
            var userIdDb = new PcgUser { Email = "aaa@efigame.com", Password = "aaa" };
            userIdDb.Persist();

            // Act
            var user = PcgUser.Get(userIdDb.Email, userIdDb.Password);
            user.Delete();

            var actual = PcgUser.Get(userIdDb.Email, userIdDb.Password);

            // Assert
            Assert.IsNull(actual);

            // Cleanup
            userIdDb.Delete();
        }

    }
}
