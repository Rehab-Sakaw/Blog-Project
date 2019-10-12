namespace Blog.Migrations
{
    using Blog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Models.BlogContext context)
        {
            //context.User.Add(new User() { Name = "Rehab", Age = 26, Email = "rehab@gmail.com", Password = "123456", Role = "Admin" });
            //context.User.Add(new User() { Name = "Aya", Age = 23, Email = "aya@gmail.com", Password = "123456", Role = "User" });
            //context.User.Add(new User() { Name = "Islam", Age = 25, Email = "islam@gmail.com", Password = "123456", Role = "Admin" });
            //context.User.Add(new User() { Name = "Mohamed", Age = 26, Email = "mohamed@gmail.com", Password = "123456", Role = "User" });


            context.Category.AddOrUpdate(c => c.ID,
                new Categories() { Name = "Books" },
                new Categories() { Name = "Sports" },
                new Categories() { Name = "Health" });

            context.User.AddOrUpdate(u => u.ID ,
                new User() { Name = "Rehab", Age = 26, Email = "rehab@gmail.com", Password = "123456", Role = "Admin" },
                new User() { Name = "Aya", Age = 23, Email = "aya@gmail.com", Password = "123456", Role = "User" },
                new User() { Name = "Islam", Age = 25, Email = "islam@gmail.com", Password = "123456", Role = "Admin" },
                new User() { Name = "Mohamed", Age = 26, Email = "mohamed@gmail.com", Password = "123456", Role = "User" }
                );

            //context.Post.AddOrUpdate(p => p.ID,
            //    new Posts() { Title = "The Real Food Dietitians", Describtion = "What it’s all about: Eating well, living well, and being well. Not only are there tons of dietitian-authored recipes, but you can also opt in for customized meal plans.", PostTime = DateTime.Now.Date, UserID = 1, CategoryID = 1 },
            //    new Posts() { Title = "A Life in Books", Describtion = "Blogger Susan Osborne has done it all—she has worked in book sales, as a writer, and as a magazine editor. As she puts it, her aims are to select snippets of book news that interest[her] talk about some of the books[she's] just read and alert readers to titles that might not find themselves in the glare of the publicity spotlight.", PostTime = DateTime.Now.Date, UserID = 1, CategoryID = 2 },
            //    new Posts() { Title = "The Real Food Dietitians", Describtion = "What it’s all about: Eating well, living well, and being well. Not only are there tons of dietitian-authored recipes, but you can also opt in for customized meal plans.", PostTime = DateTime.Now.Date, UserID = 1, CategoryID = 1 }
            //    );

        }
    }
}
