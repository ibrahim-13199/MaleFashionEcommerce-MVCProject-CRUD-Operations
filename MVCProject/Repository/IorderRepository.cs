using System.Collections.Generic;

namespace MVCProject.Models
{
    public interface IorderRepository
    {
        int Delete(int id);
        int Edit(int id, Order order1);
        Order FindById(int id);
        List<Order> GetAll();
        int insert(Order order1);
    }
}