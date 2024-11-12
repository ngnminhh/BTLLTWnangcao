namespace QLTV.Repository
{
    public interface IAdminRepository
    {
        public IEnumerable<dynamic> GetDanhMuc();
        public IEnumerable<dynamic> GetListSach();
        public IEnumerable<dynamic> UpdateSach(IFormCollection form);

    }
}
