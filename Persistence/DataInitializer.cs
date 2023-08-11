using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class DataInitializer
{
    public async static Task InitializeData(DataContext context, UserManager<AppUser> userManager)
    {
        // Delete database first to start with fresh data
        //await context.Database.EnsureDeletedAsync();

        if(await context.Database.EnsureCreatedAsync())
        {
            // Add Products
            var products = InitProducts();
            await context.Products.AddRangeAsync(products);

            // Add OrderItems
            var items = InitOrderItems(products);
            await context.OrderItems.AddRangeAsync(items);

            // Add Carts, and add products to some carts
            var carts = InitCarts();
            carts[0].AddItem(items[0]);
            carts[0].AddItem(items[1]);
            carts[0].AddItem(items[2]);
            carts[1].AddItem(items[6]);
            carts[2].AddItem(items[8]);
            await context.Carts.AddRangeAsync(carts);

            // Add Users, and add carts to some users (with products in it)
            var users = InitUsers();
            users[0].Cart = carts[0];
            users[1].Cart = carts[1];
            users[2].Cart = carts[2];

            foreach (var user in users)
                await userManager.CreateAsync(user, "password");

            // Add Orders, and add user + products of carts to it
            var orders = InitOrders(users, carts);
            orders[0].AddItem(items[0]);
            orders[0].AddItem(items[1]);
            orders[0].AddItem(items[2]);
            orders[1].AddItem(items[6]);
            orders[2].AddItem(items[8]);
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }

    

    private static List<Product> InitProducts()
    {
        return new()
        {
            new Product("Product One", 5.50m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-7)),
            new Product("Product Two", 100m, "", true, "This is the description", ProductType.Shirt, DateTime.Today.AddDays(-10)),
            new Product("Product Three", 50m, "", true, "This is the descriptione", ProductType.Jacket, DateTime.Today.AddDays(-50)),
            new Product("Product Four", 9.50m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-100)),
            new Product("Product Five", 19.95m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-1)),
            new Product("Product Six", 16.45m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-8)),
            new Product("Product Seven", 10m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-30)),
            new Product("Product Eight", 30m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-35)),
            new Product("Product Nine", 40m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-7)),
            new Product("Product Ten", 60m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-7)),
            new Product("Product Eleven", 70m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-7)),
            new Product("Product Twelve", 80m, "", true, "This is the description", ProductType.Hoodie, DateTime.Today.AddDays(-7)),
            new Product("Product Thirteen", 40m, "", true, "This is the description", ProductType.Shirt, DateTime.Today.AddDays(-180)),
            new Product("Product Fourteen", 50m, "", true, "This is the description", ProductType.Shirt, DateTime.Today.AddDays(-180)),
            new Product("Product Fifteen", 10m, "", true, "This is the description", ProductType.Jacket, DateTime.Today.AddDays(-2)),
        };
    }

    private static List<OrderItem> InitOrderItems(List<Product> products)
    {
        return new()
        {
            new OrderItem(products[0], 2),
            new OrderItem(products[1], 1),
            new OrderItem(products[2], 3),
            new OrderItem(products[3], 1),
            new OrderItem(products[4], 2),
            new OrderItem(products[5], 1),
            new OrderItem(products[6], 3),
            new OrderItem(products[7], 1),
            new OrderItem(products[8], 2),
            new OrderItem(products[9], 1),
        };
    }

    private static List<Cart> InitCarts()
    {
        return new()
        {
            new Cart(),
            new Cart(),
            new Cart(),
            new Cart(),
            new Cart(),
            new Cart(),
            new Cart(),
        };
    }

    private static List<Order> InitOrders(List<AppUser> users, List<Cart> carts)
    {
        return new()
        {
            new Order(users[0], carts[0].Items),
            new Order(users[0], carts[1].Items),
            new Order(users[0], carts[2].Items),
            new Order(users[1], carts[0].Items),
            new Order(users[2], carts[5].Items),
        };
    }

    private static List<AppUser> InitUsers()
    {
        return new()
        {
            new AppUser("janne.vanschepdael@hotmail.com", "Janne", "Van Schepdael"),
            new AppUser("kobe.vanschepdael@hotmail.com", "Kobe", "Van Schepdael"),
            new AppUser("joe.biden@gmail.com", "Joe", "Biden"),
            new AppUser("jonathano@gmail.com", "Jonathan", "O"),
        };
    }
}