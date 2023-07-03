using System.Collections.Generic;

namespace TestNinja.Mocking.Interfaces
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnProcessedVideos();
    }
}