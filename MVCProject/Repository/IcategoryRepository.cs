using System.Collections.Generic;

namespace MVCProject.Models
{
    public interface IcategoryRepository
    {
        int Delete(int id);
        int Edit(int id, Category category1);
        Category FindById(int id);
        List<Category> GetAll();
        int insert(Category category1);
    }
}