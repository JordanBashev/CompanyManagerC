namespace CompanyManagerC.Models
{
    public class TableView<T> where T : BaseModel
    {
        public List<T>? itemList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
