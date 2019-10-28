using Moq;
using Sales.Data.Analysis.IO;
using Xunit;

namespace Sales.Data.Analysis.UnitTest
{
    public class MoveFileTests
    {
        [Fact]
        public void Should_CreateDirectory_When_DirectoryDoesNotExists()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(false);

            MoveFile moveFile = new MoveFile(mockDirectoryFile.Object);
            moveFile.Move(string.Empty, string.Empty);

            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.CreateDirectory(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_MoveFile_When_DirectoryExists()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(true);

            MoveFile moveFile = new MoveFile(mockDirectoryFile.Object);
            moveFile.Move(string.Empty, string.Empty);

            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.CreateDirectory(It.IsAny<string>()), Times.Never);
            mockDirectoryFile.Verify(o => o.FileMove(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
