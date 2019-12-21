using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Xunit;
using LastProject;
using LastProject.Models;
using LastProject.Services;
using LastProject.Services.AcctS;

namespace Testing
{
    public class AcctTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IAcctRepository>();
            var AcctService = new AcctService(fakeRepository);
            var Acct = new Acct() { AcctId = 1, CustId = 1, CustCat = 'u', AcctCat = 'b', OpenDate = DateTime.Now };
            await AcctService.AddAndSafe(Acct);
        }

        [Fact]
        public async Task GetAcctTest()
        {
            var Accts = new List<Acct>
            {
                new Acct() { AcctId = 1, CustId = 1, CustCat = 'u', AcctCat = 'b', OpenDate = DateTime.Now },
                new Acct() { AcctId = 2, CustId = 2, CustCat = 'f', AcctCat = 'b', OpenDate = DateTime.Now },
            };

            var fakeRepositoryMock = new Mock<IAcctRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Accts);


            var AcctService = new AcctService(fakeRepositoryMock.Object);

            var resultAccts = await AcctService.GetAccts();

            Assert.Collection(resultAccts, Acct => { Assert.Equal('b', Acct.AcctCat); },
                Acct => { Assert.Equal(2, Acct.CustId); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IAcctRepository>();
            var AcctService = new AcctService(fakeRepository);
            int AcctId = 1;
            await AcctService.Delete(AcctId);
        }

        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IAcctRepository>();
            var AcctService = new AcctService(fakeRepository);
            var Acct = new Acct() { AcctId = 1, CustId = 1, CustCat = 'u', AcctCat = 'b', OpenDate = DateTime.Now };
            await AcctService.Edit(Acct);
        }

        [Fact]
        public async Task GetAcctByIdTest()
        {
            int id = 1;
            var Acct2 = new Acct() { AcctId = id, CustId = 1, CustCat = 'u', AcctCat = 'b', OpenDate = DateTime.Now };

            var fakeRepositoryMock = new Mock<IAcctRepository>();
            fakeRepositoryMock.Setup(x => x.GetAcctById(id)).ReturnsAsync(Acct2);

            var AcctService = new AcctService(fakeRepositoryMock.Object);
            var resultAcct = await AcctService.GetAcctById(id);
            Assert.Equal('b', resultAcct.AcctCat);
        }

        [Fact]
        public void AcctExistsTest()
        {
            int AcctId = 1;

            var fakeRepositoryMock = new Mock<IAcctRepository>();
            fakeRepositoryMock.Setup(x => x.AcctExistAndId(AcctId)).Returns(true);

            var AcctService = new AcctService(fakeRepositoryMock.Object);

            var isExist = AcctService.IsAcctExist(AcctId);

            Assert.True(isExist);
        }
    }
}