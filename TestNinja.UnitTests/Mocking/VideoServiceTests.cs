using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.UnitTests.Mocking
{

    /*
    * There are two types of Test Fake Objects: stubs and mocks. Generally, the difference between on and another
    * vary very little.
    */

    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError() {

            /*
                TIP.: Use moq ONLY for external dependencies.
            */
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreUnProcessed_ReturnAllVideoIdsIntoAString()
        {
            _videoRepository.Setup(mv => mv.GetUnProcessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 2, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 3, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 4, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 5, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 6, Title = "Test Sample 1", IsProcessed = false },
                new Video { Id = 14, Title = "Test Sample 1", IsProcessed = false }
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3,4,5,6,14"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _videoRepository.Setup(vr => vr.GetUnProcessedVideos()).Returns(new List<Video>());

            string result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.Empty);
        }
    }
}
