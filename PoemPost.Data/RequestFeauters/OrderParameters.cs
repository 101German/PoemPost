namespace PoemPost.Data.RequestFeauters
{
    public abstract class OrderParameters : PaginationParameters
    {
        public string OrderString { get; set; }
    }
}
