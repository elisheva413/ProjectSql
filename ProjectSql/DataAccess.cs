using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSql
{
    internal class DataAccess
    {
        public int insertDataToCategories(string connectionString)
        {
            string Category_Name;
            Console.WriteLine("insert Category Name");
            Category_Name = Console.ReadLine();
            string query = "INSERT INTO Categories(Category_Name) " +
            "VALUES (@Category_Name) ";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                cmd.Parameters.Add("@Category_Name", SqlDbType.VarChar, 30).Value = Category_Name;
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("rowsAffected: " + rowsAffected);
                return rowsAffected;
            }

        }
        public int InsertDataToProducts(string connectionString)
        {
            string Product_Name, Description_Product, Path;
            int Category_ID;
            float Price;
            Console.WriteLine("insert Category_ID");
            Category_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("insert Product_Name");
            Product_Name = Console.ReadLine();
            Console.WriteLine("insert Description_Product");
            Description_Product = Console.ReadLine();
            Console.WriteLine("insert Price");
            Price = float.Parse(Console.ReadLine());
            Console.WriteLine("insert Path");
            Path = Console.ReadLine();

            string query = "INSERT INTO Products(Category_ID,Product_Name,Description_Product,Price,Path) " +
           "VALUES (@Category_ID,@Product_Name,@Description_Product, @Price, @Path) ";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                cmd.Parameters.Add("@Category_ID", SqlDbType.Int, 30).Value = Category_ID;
                cmd.Parameters.Add("@Product_Name", SqlDbType.VarChar, 30).Value = Product_Name;
                cmd.Parameters.Add("@Description_Product", SqlDbType.VarChar, 30).Value = Description_Product;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = Price;
                cmd.Parameters.Add("@Path", SqlDbType.VarChar, 40).Value = Path;
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("rowsAffected: " + rowsAffected);
                return rowsAffected;
            }

        }


        public void insertData(string connectionString)
        {
            Console.WriteLine("Do you want to insert data  into Categories table? y/n");
            string select = Console.ReadLine();
            while (select == "y" || select == "Y")
            {
                insertDataToCategories(connectionString);
                Console.WriteLine("Do you want insert more params into Categories table? y/n");
                select = Console.ReadLine();
            }

            Console.WriteLine("Do you want to insert data  into Products table? y/n");
            string select1 = Console.ReadLine();
            while (select1 == "y" || select1 == "Y")
            {
                InsertDataToProducts(connectionString);
                Console.WriteLine("Do you want insert more params into Products table? y/n");
                select1 = Console.ReadLine();
            }
        }

  

        public void readDataProducts(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.ReadLine();

            }
        }

        public void readDataCategories(string connectionString)
        {
            string queryString = "select * from Categories ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.ReadLine();

            }
        }
        public void PrintDataOnScreen(string connectionString)
        {
            Console.WriteLine("Do you want to print Categories table? y/n");
            string select = Console.ReadLine();
            if (select == "y" || select == "Y")
            {

                readDataCategories(connectionString);
            }
            Console.WriteLine("Do you want to print Products table? y/n");
            string select2 = Console.ReadLine();
            if (select2 == "y" || select2=="Y")
            {
                readDataProducts(connectionString);

            }

        }
    }
}



        




    

