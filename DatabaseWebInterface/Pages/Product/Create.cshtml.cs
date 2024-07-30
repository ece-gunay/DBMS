using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace DatabaseWebInterface.Pages.Product
{
    public class CreateModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            productInfo.ProductName = Request.Form["name"];
            productInfo.ProductPrice = Request.Form["price"];
            productInfo.WarehouseCity = Request.Form["city"];
            productInfo.WarehouseDistrict = Request.Form["district"];
            productInfo.WarehouseNeighbourhood = Request.Form["neighbourhood"];
            productInfo.WarehouseStreet = Request.Form["street"];
            productInfo.WarehouseBuildingNumber = Request.Form["buildingnumber"];
            productInfo.WarehouseApartmentNumber = Request.Form["apartmentnumber"];

            if (productInfo.ProductName.Length == 0 ||
                productInfo.ProductPrice.Length == 0 || productInfo.WarehouseCity.Length == 0 ||
                productInfo.WarehouseDistrict.Length == 0 || productInfo.WarehouseNeighbourhood.Length == 0
                || productInfo.WarehouseStreet.Length == 0 || productInfo.WarehouseBuildingNumber.Length == 0
                || productInfo.WarehouseApartmentNumber.Length == 0)
            {
                errorMessage = "All the fields are required!";
                return;
            }
            try
            {
                String connectionString = "Data Source=DESKTOP-07NFG6R;Initial Catalog=PersonalCareDatabase;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql =
                        "insert into Product (ProductName,ProductPrice,WarehouseCity,WarehouseDistrict,WarehouseNeighbourhood,WarehouseStreet,WarehouseBuildingNumber,WarehouseApartmentNumber)" +
                        "values (@name,@price,@city,@district,@neighbourhood,@street,@buildingnumber,@apartmentnumber);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", productInfo.ProductName);
                        command.Parameters.AddWithValue("@price", productInfo.ProductPrice);
                        command.Parameters.AddWithValue("@city", productInfo.WarehouseCity);
                        command.Parameters.AddWithValue("@district", productInfo.WarehouseDistrict);
                        command.Parameters.AddWithValue("@neighbourhood", productInfo.WarehouseNeighbourhood);
                        command.Parameters.AddWithValue("@street", productInfo.WarehouseStreet);
                        command.Parameters.AddWithValue("@buildingnumber", productInfo.WarehouseBuildingNumber);
                        command.Parameters.AddWithValue("@apartmentnumber", productInfo.WarehouseApartmentNumber);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            productInfo.ProductName = "";
            productInfo.ProductPrice = "";
            productInfo.WarehouseCity = "";
            productInfo.WarehouseDistrict = "";
            productInfo.WarehouseNeighbourhood = "";
            productInfo.WarehouseStreet = "";
            productInfo.WarehouseBuildingNumber = "";
            productInfo.WarehouseApartmentNumber = "";

            successMessage = "New product has been added properly.";
        }
    }
}
