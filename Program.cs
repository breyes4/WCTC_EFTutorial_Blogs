using System;
using EFTutorial.Models;
using System.Linq;

namespace EFTutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Enter your selection:");
                Console.WriteLine("1) Display all blogs");
                Console.WriteLine("2) Add Blog");
                Console.WriteLine("3) Display Post");
                Console.WriteLine("4) Add Posts");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Display all blogs
                    using (var context = new BlogContext())
                    {
                        var blogList = context.Blogs.ToList();

                        Console.WriteLine("The blogs are: ");
                        foreach (var blog in blogList)
                        {
                            Console.WriteLine($"     {blog.Name}");
                        }
                    }
                }
                else if (choice == "2")
                {
                    // Add blog
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Enter a blog name");
                        var blogName = Console.ReadLine();

                        var blog = new Blog();
                        blog.Name = blogName;

                        context.Blogs.Add(blog);
                        context.SaveChanges();
                    }
                }
                else if (choice == "3")
                {
                    //Display Post
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Which blogs posts would you like to see?");
                        var blogPosts = Convert.ToInt32(Console.ReadLine());

                        var postsList = context.Posts.Where(p => p.BlogId == blogPosts).ToList();

                        Console.WriteLine("The Posts are:");
                        foreach (var post in postsList)
                        {
                            Console.WriteLine($"Blog:     {post.Blog.Name}");
                            Console.WriteLine($"     {post.Title}");
                        }
                    }

                }
                else if (choice == "4")
                {
                    // Add Post 
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Which blog?");
                        var blogId = Console.ReadLine();
                        Console.WriteLine("Enter a post title");
                        var title = Console.ReadLine();
                        Console.WriteLine("Enter post content");
                        var content = Console.ReadLine();


                        var post = new Post();
                        post.Title = title;
                        post.Content = content;
                        post.BlogId = Convert.ToInt32(blogId);

                        context.Posts.Add(post);
                        context.SaveChanges();

                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid selection");
                }

            } while (choice == "1" || choice == "2" || choice == "3" || choice == "4");



        }
    }


}
