using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task TAddAsync(Comment entity)
        {
            await _commentDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _commentDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> TGetAllAsync()
        {
            return await _commentDal.GetAllAsync();
        }

        public async Task<Comment> TGetByIdAsync(int id)
        {
            return await _commentDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Comment entity)
        {
            await _commentDal.UpdateAsync(entity);
        }
    }
}
