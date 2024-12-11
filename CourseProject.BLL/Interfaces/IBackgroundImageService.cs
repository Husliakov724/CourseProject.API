using CourseProject.BLL.Models;

namespace CourseProject.BLL.Interfaces;

public interface IBackgroundImageService
{
    Task<ImageModel> GetBackgroundImageAsync(int id);
    Task UploadImageAsync(MemoryStream stream);
}