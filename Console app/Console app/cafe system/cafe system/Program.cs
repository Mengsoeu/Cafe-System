using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace cafe_system
{
    internal class Program
    {

        private const float price = 2;
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=mssql-157124-0.cloudclusters.net,10041;Initial Catalog=""console database"";User ID=admin;Password=Admin123;Integrated Security=False;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {

                
                string ans;
                Console.WriteLine("Connected");
                do
                {

                    //insertttt
                    Console.WriteLine("============== Welcome to our Cafe system =================");
                    Console.WriteLine("To make order please select from option below\n1.Create order\n2.display order\n3.edit order\n4.delete order\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            
                            Console.Write("Enter product name");Console.Write("\t"); string proname = Console.ReadLine();
                            Console.Write("Enter quantity"); Console.Write("\t"); int quantity = int.Parse(Console.ReadLine());
                            Console.Write("Enter Size"); Console.Write("\t"); string size =Console.ReadLine();
                            Console.Write("Enter description"); Console.Write("\t"); string note = Console.ReadLine();
                            Console.Write("Enter price"); Console.Write("\t"); float total = float.Parse(Console.ReadLine());
                            


                            total = total * quantity;

                            /*float  total = price * quantity;
                            total =float.Parse(Console.ReadLine());*/








                            string insertQuery = "INSERT INTO DETAIL(product,qty,size,note,total) VALUES ('" + proname + "', " + quantity + ",'" + size + "','" + note + "', " + total + ")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("data successfully added");
                            break;
                        case 2:
                            //Read////////////////
                            String display = "SELECT * FROM DETAIL";
                            SqlCommand displayCommand = new SqlCommand(display, sqlConnection);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();

                            while (dataReader.Read())
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------");
                                Console.Write("Id: " + dataReader.GetValue(0).ToString());
                                Console.Write("\t\t");
                                Console.Write("Product: " + dataReader.GetValue(1).ToString());
                                Console.Write("\t\t");
                                Console.Write("Qty: " + dataReader.GetValue(2).ToString());
                                Console.Write("\t\t");
                                Console.Write("size: " + dataReader.GetValue(3).ToString());
                                Console.Write("\t\t");
                                Console.Write("note: " + dataReader.GetValue(4).ToString());
                                Console.Write("\t\t");
                                Console.Write("total: " + dataReader.GetValue(5).ToString());
                                Console.Write("\t\t");
                                Console.WriteLine("\n");
                            } 
                            dataReader.Close();
                           /* sqlConnection.Close();*/
                            break;
                        case 3:

                            // update ///
                            int a;
                            string product;
                            int q;
                            string s;
                            Console.Write("Enter order id you would like to change"); Console.Write("\t"); a = int.Parse(Console.ReadLine());
                            Console.Write("Enter New product: "); product =(Console.ReadLine());
                            Console.Write("Enter New Qty: "); q = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Size: "); s = (Console.ReadLine());
                            

                            

                            string updatequery = "UPDATE DETAIL SET product = '" + product + "', qty = " + q + ",size ='" + s + "' WHERE id = " + a + "";
                            SqlCommand updateCommand = new SqlCommand(updatequery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data updated");
                            /*sqlConnection.Close();*/
                            break;
                        case 4:
                            //delete //
                            int d_id;
                            Console.WriteLine("Enter order id you want to delete"); d_id = int.Parse(Console.ReadLine());
                            string deleletquery = "DELETE FROM DETAIL WHERE id =" + d_id;
                            SqlCommand deleteCommand = new SqlCommand(deleletquery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("deleted done");
                            /*sqlConnection.Close();*/
                            break;
                        default:
                            Console.WriteLine("Invalid value");
                            break;
                    }
                    Console.WriteLine("Make another order?"); ans = Console.ReadLine();
                } while (ans != "No");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

       
        }
    }
}
