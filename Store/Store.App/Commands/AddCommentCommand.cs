using Store.App.Commands.Contracts;
using Store.App.Models;
using Store.Services.Contracts;

namespace Store.App.Commands
{
    public class AddCommentCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private ICommentService commentService;

        public AddCommentCommand(IUserSessionService userSessionService, ICommentService commentService)
        {
            this.userSessionService = userSessionService;
            this.commentService = commentService;
        }

        public string Execute(params string[] args)
        {
            var productId = int.Parse(args[0]);
            var content = args[1];

            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var authorId = this.userSessionService.User.Id;

            var comment = this.commentService.CreateComment<CommentDto>(content, productId, authorId);

            return "Comment created successfully!";
        }
    }
}
