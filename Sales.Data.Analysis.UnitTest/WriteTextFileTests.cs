using Moq;
using Sales.Data.Analysis.IO;
using Xunit;

namespace Sales.Data.Analysis.UnitTest
{
    public class WriteTextFileTests
    {
        [Fact]
        public void Should_Return_When_InvalidFileName()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            _ = mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(false);

            WriteTextFile writeTextFile = new WriteTextFile(mockDirectoryFile.Object);
            writeTextFile.WriteText(string.Empty, string.Empty, string.Empty);

            mockDirectoryFile.Verify(o => o.IsValidFileName(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_CreateDirectory_When_DirectoryDoesNotExists()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(false);

            WriteTextFile writeTextFile = new WriteTextFile(mockDirectoryFile.Object);
            writeTextFile.WriteText("path", "file", "contents");

            mockDirectoryFile.Verify(o => o.IsValidFileName(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.CreateDirectory(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_WriteTextFile_When_DirectoryExists()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(true);

            WriteTextFile writeTextFile = new WriteTextFile(mockDirectoryFile.Object);
            writeTextFile.WriteText("path", "file", "contents", true);

            mockDirectoryFile.Verify(o => o.IsValidFileName(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
        }
    }
}
