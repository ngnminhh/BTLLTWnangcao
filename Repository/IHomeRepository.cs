namespace QLTV.Repository
{
    public interface IHomeRepository
    {
        public IEnumerable<dynamic> GetDMBooks();
        public IEnumerable<dynamic> GetItemDetail(string id);
        public IEnumerable<dynamic> GetBookWithCategory(string id);
        public IEnumerable<dynamic> GetListBooksBorrow(string currentUser);
        public void AddBook(string currentUser);

    }
}
