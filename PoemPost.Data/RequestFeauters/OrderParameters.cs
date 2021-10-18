namespace PoemPost.Data.RequestFeauters
{
    public abstract class OrderParameters : PaginationParameters
    {
        public string[] OrderByQueryStrings { get; set; }

        public OrderType Order { get; set; }


    }
    public enum OrderType
    {
        Ascending,
        Descending
    }
}
