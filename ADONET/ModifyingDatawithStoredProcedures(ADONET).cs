using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbProviderFactoryDemo
{
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            ReturnIdentity("Data Source=.;Initial Catalog=northwind;Integrated Security=True");
        }

        private static void ReturnIdentity(string connectionString)
        {
            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                // Create a SqlDataAdapter based on a SELECT query.
                SqlDataAdapter adapter = new SqlDataAdapter(
                  "SELECT CategoryID, CategoryName FROM dbo.Categories",
                  connection);

                // Create a SqlCommand to execute the stored procedure.
                adapter.InsertCommand = new SqlCommand("InsertCategory", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                // Create a parameter for the ReturnValue.
                // the parameter name you can use any words you like.
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add(
                  "@RowCount", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;

                // Create an input parameter for the CategoryName.
                // You do not need to specify direction for input parameters.
                adapter.InsertCommand.Parameters.Add(
                  "@CategoryName", SqlDbType.NChar, 15, "CategoryName");

                // Create an output parameter for the new identity value.
                parameter = adapter.InsertCommand.Parameters.Add(
                  "@Identity", SqlDbType.Int, 0, "CategoryID");
                parameter.Direction = ParameterDirection.Output;

                // Create a DataTable and fill it.
                DataTable categories = new DataTable();
                adapter.Fill(categories);

                // Add a new row.
                DataRow categoryRow = categories.NewRow();
                categoryRow["CategoryName"] = "New Beverages";
                categories.Rows.Add(categoryRow);

                // Update the database.
                adapter.Update(categories);

                // Retrieve the ReturnValue.
                Int32 rowCount =
                    (Int32)adapter.InsertCommand.Parameters["@RowCount"].Value;
                Int32 output =
                    (Int32)adapter.InsertCommand.Parameters["@Identity"].Value;

                Console.WriteLine("ReturnValue: {0}", rowCount.ToString());
                Console.WriteLine("Output Value: {0}", output.ToString());
                Console.WriteLine("All Rows:");
                foreach (DataRow row in categories.Rows)
                {
                    {
                        Console.WriteLine("  {0}: {1}", row[0], row[1]);
                    }
                }
            }
        }
    }
}
