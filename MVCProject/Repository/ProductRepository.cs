using System.Collections.Generic;
using System.Linq;
namespace MVCProject.Models
{
    public class productRepository : IproductRepository
    {
        SalesDbContext dbContext = new SalesDbContext();
        //CRUD
        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }
        public Product FindById(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.Id == id);
        }
        public int insert(Product product1)
        {
            dbContext.Products.Add(product1);
            int rawAfficted = dbContext.SaveChanges();
            return rawAfficted;
        }
        public int Edit(int id, Product product1)
        {
            Product oldproduct = FindById(id);
            if (oldproduct != null)
            {
                oldproduct.Id = id;
                oldproduct.price = product1.price;
                oldproduct.image = product1.image;
                oldproduct.tilte = product1.tilte;
                oldproduct.describtion = product1.describtion;
                int rawAfficted = dbContext.SaveChanges();
                return rawAfficted;
            }
            return 0;

        }
        public int Delete(int id)
        {
            Product oldproduct = FindById(id);
            dbContext.Products.Remove(oldproduct);
            return dbContext.SaveChanges();

        }

        public List<Product> FindByCategoryId(int categoryId)
        {
            List<Product> products =
            dbContext.Products.Where(s => s.categoryId == categoryId).ToList();
            return products;
        }
    }
}


