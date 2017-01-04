using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Concreate
{
    class SqlDbContext
    {
        public void UpdateProduct(Product p)
        {
            string cmd = string.Format("UPDATE dbo.Products2 SET Name='{0}', Description = '{1}', Category = '{2}', Price = {3} WHERE ProductID = {4}",
                p.Name, p.Description, p.Category, p.Price.ToString().Replace(',','.'), p.ProductID);
            ExecuteQueryWithoutReturn(cmd);
        }
        public void SaveProduct(Product p)
        {
            string cmd = string.Format("INSERT INTO dbo.Products2(Name, Description, Category, Price) VALUES ('{0}', '{1}', '{2}', {3})",
                    p.Name, p.Description, p.Category, p.Price.ToString().Replace(',', '.'));
            ExecuteQueryWithoutReturn(cmd);
        }

        public void DeleteProduct(int productID)
        {
            string cmd = string.Format("DELETE FROM dbo.Products2 WHERE ProductID = {0}", productID);
            ExecuteQueryWithoutReturn(cmd);
        }

        public IEnumerable<Product> GetProducts()
        {
            Product p = new Product();
            List<Product> Products = new List<Product>();
            {
                new Product() { Category = "Piłka nożna", Name = "Piłka", Description = "Super piłka od Ronaldo", Price = 33.15m, ProductID = 1 };
                new Product() { ProductID = 2, Name = "Korki", Description = "Dodają szybkości", Price = 199.99m, Category = "Piłka nożna" };
                new Product() { ProductID = 3, Name = "Koszulka LeBron'a", Description = "Jeszcze spocona!", Category = "Koszykówka", Price = 243.21m };
                new Product() { ProductID = 4, Name = "Piłeczka tenisowa", Description = "Taka zielona, mała", Category = "Tenis", Price = 31.20m };
                new Product() { ProductID = 5, Name = "Getry", Description = "Dłuższe niż Twoje nogi", Price = 9.99m, Category = "Piłka nożna" };
            }
            //using (SqlConnection conn = new SqlConnection("Data Source=PRZEMEK;Initial Catalog=SportStore;Integrated Security=SSPI"))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Products2", conn);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        p.ProductID = (int)reader["ProductID"];
            //        p.Name = reader["Name"].ToString();
            //        p.Description = reader["Description"].ToString();
            //        p.Category = reader["Category"].ToString();
            //        p.Price = (decimal)reader["Price"];
            //        Products.Add(new Product()
            //        {
            //            ProductID = p.ProductID,
            //            Name = p.Name,
            //            Description = p.Description,
            //            Category = p.Category,
            //            Price = p.Price
            //        });
            //    }               
            //    conn.Close();
            //}
            return Products;
        }

       static void ExecuteQueryWithoutReturn(string query)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=PRZEMEK;Initial Catalog=SportStore;Integrated Security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
