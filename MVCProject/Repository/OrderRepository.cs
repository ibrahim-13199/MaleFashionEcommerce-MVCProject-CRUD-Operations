using System.Collections.Generic;
using System.Linq;
namespace MVCProject.Models
{
    public class orderRepository : IorderRepository
    {
        SalesDbContext dbContext = new SalesDbContext();
        //CRUD
        public List<Order> GetAll()
        {
            return dbContext.Orders.ToList();
        }
        public Order FindById(int id)
        {
            return dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }
        public int insert(Order order1)
        {
            dbContext.Orders.Add(order1);
            int rawAfficted = dbContext.SaveChanges();
            return rawAfficted;
        }
        public int Edit(int id, Order order1)
        {
            Order oldorder = FindById(id);
            if (oldorder != null)
            {
                oldorder.Id = id;
                oldorder.address = order1.address;
                oldorder.totalPrice = order1.totalPrice;
                oldorder.date = order1.date;

                int rawAfficted = dbContext.SaveChanges();
                return rawAfficted;
            }
            return 0;

        }
        public int Delete(int id)
        {
            Order oldorder = FindById(id);
            dbContext.Orders.Remove(oldorder);
            return dbContext.SaveChanges();

        }
    }
}


