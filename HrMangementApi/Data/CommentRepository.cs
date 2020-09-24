using HrMangementApi.Models;
using HrMangementApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrMangementApi.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository( DataContext context)
        {
            this._context = context;
        }

        public async Task<bool> CommentExists(int id)
        {
            return await _context.Comments.AnyAsync(x => x.CommentId == id);
        }

        public async Task<bool> CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            return await save();
        }

        public async Task<bool> DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            return await save();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _context.Comments.Where(x => x.CommentId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() >=0 ? true : false; 
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            return await save();
        }
    }
}
