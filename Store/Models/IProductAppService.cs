namespace Store.Models
{
    public interface IProductAppService 
    {
        Task<List<ProductDetail>> GetAll();
    }
}
