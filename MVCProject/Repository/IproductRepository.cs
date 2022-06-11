using System.Collections.Generic;

namespace MVCProject.Models
{
    public interface IproductRepository
    {
        int Delete(int id);
        int Edit(int id, Product product1);
        Product FindById(int id);
        List<Product> GetAll();
        int insert(Product product1);
        List<Product> FindByCategoryId(int categoryId);
    }
}