using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbProviderFactoryDemo
{
    using System.Configuration;
    using System.Data.Common;

    class Program
    {
        static void Main(string[] args)
        {
            string providerName = "System.Data.OleDb";
            string connectionString = GetConnectionStringByProvider(providerName);
            var connection = CreateDbConnection(providerName, connectionString);
        }

        // Retrieve a connection string by specifying the providerName.
        // Assumes one connection string per provider in the config file.
        static string GetConnectionStringByProvider(string providerName)
        {
            // Return null on failure.
            string returnValue = null;

            // Get the collection of connection strings.
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            // Walk through the collection and return the first 
            // connection string matching the providerName.
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        returnValue = cs.ConnectionString;
                        break;
                    }
                }
            }
            return returnValue;
        }

        // Given a provider name and connection string, 
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.
        static DbConnection CreateDbConnection(
            string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }
    }
}
