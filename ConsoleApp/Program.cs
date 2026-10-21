using Domain.Models;
using Infrastructure.Repositories;

var now = new AuthorRepositories();

while (true)
{
    Console.WriteLine("==============================");
    Console.WriteLine(@"1.Show all authors.
    2.Show author by id.
    3.Add author.
    4.Delete author.
    5.Update author.
    0. Exits");
    var a = Console.ReadLine();
    Console.WriteLine("==============================");
    switch (a)
    {
        case "1":
        var authors = now.GetAuthors();
        foreach (var item in authors)
        {
            System.Console.WriteLine($"{item.Id} {item.fullname} {item.country} {item.birthyear}");
        }
        break;
        case "2":
        Console.Write("Enter id: ");
        var d = Convert.ToInt32(Console.ReadLine());
        var get = now.GetAuthor(d);
        System.Console.WriteLine($"{get.Id} {get.fullname} {get.country} {get.birthyear}");
        break;
        case "3":
        Console.Write("Enter fullname: ");
        var t = Console.ReadLine();
        Console.Write("Enter country: ");
        var p = Console.ReadLine();
        Console.Write("Enter birthyear: ");
        var tc = Convert.ToInt32(Console.ReadLine());
        var m = new Author()
        {
            fullname = t,
            country = p,
            birthyear = tc
        };
        now.Add(m);
        break;
        case "4":
        Console.Write("Enetr id for delete: ");
        var id = Convert.ToInt32(Console.ReadLine());
        now.Delete(id);
        break;
        case "5":
        Console.Write("Enetr id for update: ");
        var h = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter fullname for update: ");
        var tt = Console.ReadLine();
        Console.Write("Enter country for update: ");
        var pp = Console.ReadLine();
        Console.Write("Enter birthyear for update: ");
        var tcc = Convert.ToInt32(Console.ReadLine());
        var o = new Author()
        {
            Id = h,
            fullname = tt,
            country = pp,
            birthyear = tcc
        };
        now.Update(o);
        break;
        case "0":
        System.Console.WriteLine("Exiting ....");
        return;
    }

}