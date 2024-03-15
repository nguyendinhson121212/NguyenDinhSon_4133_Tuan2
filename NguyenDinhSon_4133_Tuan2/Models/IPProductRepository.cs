namespace NguyenDinhSon_4133_Tuan2.Models
{
    public interface IPProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
