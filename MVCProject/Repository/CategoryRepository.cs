using System.Collections.Generic;
using System.Linq;

namespace MVCProject.Models
{
    public class categoryRepository : IcategoryRepository
    {
        /* SalesDbContext dbContext; *///new SalesDbContext();
                                       //public productRepository(SalesDbContext _dbContext)
                                       //{
                                       //    dbContext = _dbContext;
                                       //      //}
        SalesDbContext dbContext = new SalesDbContext();
        //CRUD
        public List<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }
        public Category FindById(int id)
        {
            return dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }
        public int insert(Category category1)
        {
            dbContext.Categories.Add(category1);
            int rawAfficted = dbContext.SaveChanges();
            return rawAfficted;
        }
        public int Edit(int id, Category category1)
        {
            Category oldcategory = FindById(id);
            if (oldcategory != null)
            {
               
                oldcategory.name = category1.name;
                oldcategory.image = category1.image;
                oldcategory.type = category1.type;

                int rawAfficted = dbContext.SaveChanges();
                return rawAfficted;
            }
            return 0;

        }
        public int Delete(int id)
        {
            Category oldcategory = FindById(id);
            dbContext.Categories.Remove(oldcategory);
            return dbContext.SaveChanges();

        }
    }
}
