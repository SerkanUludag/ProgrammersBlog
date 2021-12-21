using AutoMapper;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Core.Utilities.Results.Concrete;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId, x => x.User, x => x.Category);
            if(article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "No article found.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, x => x.Category, x => x.User);
            if(articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "No article found.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(x => x.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(x => x.CategoryId == categoryId && !x.IsDeleted && x.IsActive, x => x.Category, x => x.User);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        Status = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "No non-deleted and active article found.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "No category found.", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, x => x.Category, x => x.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "No non-deleted article found.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.Category, x => x.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "No non-deleted and active article found.", null);
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} has been added.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} has been updated.");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} has been deleted.");
            }
            return new Result(ResultStatus.Error, "Article not found.");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} has been deleted from database.");
            }
            return new Result(ResultStatus.Error, "Article not found.");
        }
    }
}
