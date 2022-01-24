using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Core.Utilities.Extensions;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Core.Utilities.Results.Concrete;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Web.Helpers.Abstract;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;              // to get wwwroot path
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath; // get wwwroot path
        }

        

        public async Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages")
        {
            // ~/img/user.Picture    save image name only other parameters dynamic

            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))      // check folder exists
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");     // create directory
            }     

            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);          
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            // SerkanUludag_587_5_38_12_3_10_2022.png
            string newFileName = $"{userName}_{dateTime.FullDateTimeStringWithUnderScore()}{fileExtension}";           // datetime extension
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            return new DataResult<ImageUploadedDto>(ResultStatus.Success, $"{userName} image has been uploaded.", new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length           // image size

            });
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);               // pictureName => folder/name
            if (System.IO.File.Exists(fileToDelete))                            // check image exists on that file path
            {
                var fileInfo = new FileInfo(fileToDelete);              // get file info
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"No image found.", null);
            }
        }
    }
}
