using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Entity.DTOs;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages");
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
