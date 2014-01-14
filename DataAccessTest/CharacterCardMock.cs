using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    public class CharacterCardMock
    {
        public Mock<DbSet<charactercard>> MockSet { get; set; }
        public Mock<PcgStorageEntities> MockContext { get; set; }

        public CharacterCardMock(List<charactercard> dataList)
        {
            var data = dataList.AsQueryable();

            var mockSet = new Mock<DbSet<charactercard>>();
            mockSet.As<IQueryable<charactercard>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<charactercard>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<charactercard>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<charactercard>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            MockSet = mockSet;

            var mockContext = new Mock<PcgStorageEntities>();
            mockContext.Setup(c => c.charactercards).Returns(mockSet.Object);
            

            MockContext = mockContext;
        }
    }
}
