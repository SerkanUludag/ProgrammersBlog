using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Entity.ComplexTypes;
using ProgrammersBlog.Entity.DTOs;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
