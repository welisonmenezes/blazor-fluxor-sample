using System.ComponentModel.DataAnnotations;

namespace blazor_blog.Shared
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Body { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? UserId { get; set; }
    }
}
