using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Concreate
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        SqlDbContext sqlContext = new SqlDbContext();

        public IEnumerable<Product> Products
        {
            get { return sqlContext.GetProducts(); }
        }

        public void SaveProduct(Product product)
        {
            sqlContext.SaveProduct(product);
        }

        public void DeleteProduct(int productID)
        {
            sqlContext.DeleteProduct(productID);
        }

        public void UpdateProduct(Product p)
        {
            sqlContext.UpdateProduct(p);
        }
    }
}
