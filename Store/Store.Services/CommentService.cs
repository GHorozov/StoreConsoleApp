using AutoMapper;
using Store.Data;
using Store.Models;
using Store.Services.Contracts;

namespace Store.Services
{
    public class CommentService : ICommentService
    {
        private StoreDbContext context;
        private IMapper mapper;

        public CommentService(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel CreateComment<TModel>(string content, int productId, int authorId)
        {
            var comment = new Comment(content, productId, authorId);
            this.context.Comments.Add(comment);
            this.context.SaveChanges();

            var commentDto = mapper.Map<TModel>(comment);

            return commentDto;
        }
    }
}
