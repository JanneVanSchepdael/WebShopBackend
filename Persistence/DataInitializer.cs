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
        // Always delete database first to start with fresh data
        await context.Database.EnsureDeletedAsync();

        if(await context.Database.EnsureCreatedAsync())
        {
            // Add Products
            var products = InitProducts();
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Add Carts, and add products to some carts
            var carts = InitCarts();
            carts[0].AddProduct(products[0]);
            carts[0].AddProduct(products[1]);
            carts[0].AddProduct(products[2]);
            carts[5].AddProduct(products[6]);

            await context.Carts.AddRangeAsync(carts);
            await context.SaveChangesAsync();

            // Add Users, and add carts to some users
            var users = InitUsers();
            users[0].Cart = carts[0];
            users[1].Cart = carts[1];
            users[2].Cart = carts[2];

            foreach (var user in users)
                await userManager.CreateAsync(user, "password");

            // Add Orders, and add user + products of carts to it
            var orders = InitOrders(users, carts);
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }

    private static List<Product> InitProducts()
    {
        return new()
        {
            new Product("Product One", 5.50m, "", true, "This is the description", 5, ProductType.Hoodie),
            new Product("Product Two", 100m, "", true, "This is the description", 1, ProductType.Shirt),
            new Product("Product Three", 50m, "", true, "This is the descriptione", 2, ProductType.Jacket),
            new Product("Product Four", 9.50m, "", true, "This is the description", 3, ProductType.Hoodie),
            new Product("Product Five", 19.95m, "", true, "This is the description", 0, ProductType.Hoodie),
            new Product("Product Six", 16.45m, "", true, "This is the description", 0, ProductType.Hoodie),
            new Product("Product Seven", 10m, "", true, "This is the description", 1, ProductType.Hoodie),
            new Product("Product Eight", 30m, "", true, "This is the description", 2, ProductType.Hoodie),
            new Product("Product Nine", 40m, "", true, "This is the description", 3, ProductType.Hoodie),
            new Product("Product Ten", 60m, "", true, "This is the description", 0, ProductType.Hoodie),
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
            new Order(users[0], carts[0].Products),
            new Order(users[0], carts[1].Products),
            new Order(users[0], carts[2].Products),
            new Order(users[1], carts[0].Products),
            new Order(users[2], carts[5].Products),
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