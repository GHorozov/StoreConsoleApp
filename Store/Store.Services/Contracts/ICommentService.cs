namespace Store.Services.Contracts
{
    public interface ICommentService
    {
        TModel CreateComment<TModel>(string content, int productId,int authorId);
    }
}
