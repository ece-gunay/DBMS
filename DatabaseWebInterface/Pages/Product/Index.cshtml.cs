using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DatabaseWebInterface.Pages.Product
{
    public class IndexModel : PageModel
    {

        public List<ProductInfo> listProduct = new List<ProductInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-07NFG6R;Initial Catalog=PersonalCareDatabase;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Product";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductInfo productInfo = new ProductInfo();
                                productInfo.ProductID = "" + reader.GetInt32(0);
                                productInfo.ProductName = reader.GetString(1);
                                productInfo.ProductPrice ="" + reader.GetDecimal(2);
                                productInfo.WarehouseCity = reader.GetString(3);
                                productInfo.WarehouseDistrict =  reader.GetString(4);
                                productInfo.WarehouseNeighbourhood = reader.GetString(5);
                                productInfo.WarehouseStreet = reader.GetString(6);
                                productInfo.WarehouseBuildingNumber = "" + reader.GetInt32(7);
                                productInfo.WarehouseApartmentNumber = "" + reader.GetInt32(8);

                                listProduct.Add(productInfo);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    public class ProductInfo
    {
        public String ProductID;
        public String ProductName;
        public String ProductPrice;
        public String WarehouseCity;
        public String WarehouseDistrict;
        public String WarehouseNeighbourhood;
        public String WarehouseStreet;
        public String WarehouseBuildingNumber;
        public String WarehouseApartmentNumber;


    }
}
