using AutoFixture;
using Moq;
using NUnit.Framework;
using PanXPan.Api.Mappings;
using PanXPan.Api.Models;
using PanXPan.Api.Representations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PanXPan.Api.Tests.BookControllerTests
{
    [TestFixture]
    public class BookControllerTests : BookControllerTestsBase
    {
        [Test]
        public async Task GetBooks_CallsRepository()
        {
            BookRepositoryMock.Setup(r => r.Get()).ReturnsAsync(new List<Book>());

            await Controller.Get();

            BookRepositoryMock.Verify(r => r.Get(), Times.Once);
        }

        [Test]
        public async Task GetBooks_ReturnsBooks()
        {
            var fakeBooks = FakeBuilder.CreateMany<Book>().ToList();
        
            BookRepositoryMock.Setup(r => r.Get()).ReturnsAsync(fakeBooks);

            var expectedResult = fakeBooks.ToRepresentation();
            var result = await Controller.Get();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkNegotiatedContentResult<ICollection<BookRepresentation>>>(result);
            var resultContent = ((OkNegotiatedContentResult<ICollection<BookRepresentation>>)result).Content;
            Assert.AreEqual(resultContent, expectedResult.ToList());
        }
    }
}
