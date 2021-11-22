namespace PoemPost.Data.DTO
{
    public class PostForCreationDTO
    {
        public string Title { get; set; }
        public string PoemText { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
