using Moq;
using PanXPan.Api.Controllers;
using PanXPan.Api.Interfaces;

namespace PanXPan.Api.Tests.BookControllerTests
{
    public class BookControllerTestsBase : TestsBase
    {
        protected BookController Controller { get; private set; }

        protected Mock<IBookRepository> BookRepositoryMock { get; }

        public BookControllerTestsBase()
        {
            BookRepositoryMock = new Mock<IBookRepository>();
            Controller = new BookController(
            BookRepositoryMock.Object);
        }
    }
}
