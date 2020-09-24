using HrMangementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrMangementApi.Services
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();

        Task<Comment> GetById(int id);

        Task<bool> CreateAsync(Comment comment);

        Task<bool> UpdateAsync(Comment comment);

        Task<bool> DeleteAsync(Comment comment);

        Task<bool> CommentExists(int id);

        Task<bool> save();
    }
}
