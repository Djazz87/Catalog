using System;
using System.Collections.Generic;
using Catalog.Models;
using CommunityToolkit.Mvvm.Input;
using MySqlConnector;

namespace Catalog.Services;

public class DatabaseService
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
                    int ManufacturerId = reader.GetInt32("manufacturer_id");
                    Manufacturer manufacturer;
                    if (!manufacturers.ContainsKey(ManufacturerId))
                    {
                        manufacturer = new Manufacturer();
                        manufacturer.ManufacturerId = ManufacturerId;
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
            CloseConnection();
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

    public static bool Delete(int productId)
    {
        if (OpenConnection())
        {
            string sql = "delete from `product` where `id` = @id";
            using var mc =  new MySqlCommand(sql, _connection);
            mc.Parameters.AddWithValue("@id", productId);
            mc.ExecuteNonQuery();
            CloseConnection();
            return true;
        }
        return false;
    }
    
  
    public static bool Update(Product ToProduct)
    {
        if (OpenConnection())
        {
            string sql = "update `product` set title=@title,year=@year,price=@price,manufacturer_id=@m_id where Id=@id";
            using var mc = new MySqlCommand(sql, _connection);
            mc.Parameters.AddWithValue("@title", ToProduct.Title);
            mc.Parameters.AddWithValue("@year", ToProduct.Year);
            mc.Parameters.AddWithValue("@price", ToProduct.Price);
            mc.Parameters.AddWithValue("@id", ToProduct.ProductId);
            mc.Parameters.AddWithValue("@m_id", ToProduct.Manufacturer.ManufacturerId);
            int row = mc.ExecuteNonQuery();
            CloseConnection();
            return true;
        }
        return false;
    }
    
}


