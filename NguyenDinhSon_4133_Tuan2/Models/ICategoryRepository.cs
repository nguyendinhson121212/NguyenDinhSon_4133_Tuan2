namespace NguyenDinhSon_4133_Tuan2.Models
{
    public interface ICategoryRepository
    {
        void Delete(int id);
        IEnumerable<Category> GetALLCategories();
    }
}
