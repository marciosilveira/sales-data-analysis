using Moq;
using Sales.Data.Analysis.IO;
using System;
using System.IO;
using Xunit;

namespace Sales.Data.Analysis.UnitTest
{
    public class ReadFromFileTests
    {
        [Fact]
        public void Should_ReturnFiles_When_ValidPath()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.GetCurrentDirectory())
                .Returns("Directory");
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.GetFiles(It.IsAny<string>()))
                .Returns(new string[2] { "File1", "File2" });

            ReadFromFile readFromFile = new ReadFromFile(mockDirectoryFile.Object);

            var fileNames = readFromFile.GetFiles("Teste");
            Assert.True(fileNames.Length == 2);

            mockDirectoryFile.Verify(o => o.GetCurrentDirectory(), Times.Once);
            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.GetFiles(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_ReturnAllLines_When_ValidFileName()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.FileExists(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.ReadAllLines(It.IsAny<string>()))
                .Returns(new string[2] { "Line1", "Line2" });

            ReadFromFile readFromFile = new ReadFromFile(mockDirectoryFile.Object);
            var lines = readFromFile.ReadAllLines("Teste");

            Assert.True(lines.Count == 2);

            mockDirectoryFile.Verify(o => o.IsValidFileName(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.FileExists(It.IsAny<string>()), Times.Once);
            mockDirectoryFile.Verify(o => o.ReadAllLines(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_ReturnNull_When_DirectoryDoesNotExist()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.GetCurrentDirectory())
                .Returns("DirectoryTeste");
            mockDirectoryFile
                .Setup(o => o.DirectoryExists(It.IsAny<string>()))
                .Returns(false);

            ReadFromFile readFromFile = new ReadFromFile(mockDirectoryFile.Object);
            var files = readFromFile.GetFiles("folder");

            Assert.Null(files);
            mockDirectoryFile.Verify(o => o.GetCurrentDirectory(), Times.Once);
            mockDirectoryFile.Verify(o => o.DirectoryExists(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_ArgumentException_When_InvalidFileName()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(false);

            ReadFromFile readFromFile = new ReadFromFile(mockDirectoryFile.Object);
            Assert.Throws<ArgumentException>(() => readFromFile.ReadAllLines(string.Empty));
        }

        [Fact]
        public void Should_FileNotFoundException_When_FileDoesNotExist()
        {
            Mock<IDirectoryFile> mockDirectoryFile = new Mock<IDirectoryFile>();
            mockDirectoryFile
                .Setup(o => o.IsValidFileName(It.IsAny<string>()))
                .Returns(true);
            mockDirectoryFile
                .Setup(o => o.FileExists(It.IsAny<string>()))
                .Returns(false);

            ReadFromFile readFromFile = new ReadFromFile(mockDirectoryFile.Object);
            Assert.Throws<FileNotFoundException>(() => readFromFile.ReadAllLines(string.Empty));
        }
    }
}
