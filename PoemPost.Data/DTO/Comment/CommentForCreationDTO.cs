namespace PoemPost.Data.DataTransferObjects
{
    public class CommentForCreationDTO
    {
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
}
