using System;
using System.Collections.Generic;
using Catalog.Models;
using MySqlConnector;

namespace Catalog.Services;

public static class DatabaseService
{
    private static MySqlConnection _connection;

    static DatabaseService()
    {
        _connection = new MySqlConnection(
            "database=1125_260126;userid=student;password=student;server=192.168.200.13;characterset=utf8");
    }

    public static List<Product> GetProducts()
    {
        string sql =
            "select p.id, p.title, p.year, p.price, p.manufacturer_id, m.title as mtitle from `product` p join `manufacturer` m on p.manufacturer_id = m.Id";
        List<Product> products = new List<Product>();
        Dictionary<int, Manufacturer> manufacturers = new();
        if (OpenConnection())
        {
            using (var command = new MySqlCommand(sql, _connection))
            using (var reader = command.ExecuteReader())
                while (reader.Read())
                {
                    int ManufacturerId = reader.GetInt32("id");
                    Manufacturer manufacturer;
                    if (!manufacturers.ContainsKey(ManufacturerId))
                    {
                        manufacturer = new Manufacturer();
                        manufacturer.Title = reader.GetString("mtitle");
                        manufacturers[ManufacturerId] = manufacturer;
                    }
                    else
                    {
                        manufacturer = manufacturers[ManufacturerId];
                    }

                    Product product = new Product
                    {
                        Title = reader.GetString("title"),
                        Year = reader.GetInt32("year"),
                        Price = reader.GetDecimal("price"),
                        ProductId = reader.GetInt32("id"),
                        Manufacturer = manufacturer
    
                    }; products.Add(product);
                }
        }

        return products;
    }

    static bool OpenConnection()
    {
        try
        {
            _connection.Open();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
    
    static void CloseConnection()
    {
        try
        {
            _connection.Close();
        }
        catch (Exception e)
        {
        }
    }
}

