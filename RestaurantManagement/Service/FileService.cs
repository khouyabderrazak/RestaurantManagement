using RestaurantManagement.Interfaces;
using Microsoft.AspNetCore.Hosting;
namespace RestaurantManagement.Service
{
    public class FileService(Microsoft.AspNetCore.Hosting.IHostingEnvironment _host) : IFileService
    {
        public string loadImage(IFormFile path)
        {
            string fileName = string.Empty;
            if (path is null)
                return fileName;
            string upLoadPath = Path.Combine(_host.WebRootPath,"images");
            fileName = path.FileName;
           
            string fullPath = Path.Combine(upLoadPath, fileName);

            path.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}
