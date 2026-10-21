using Domain.Interfrances;
using Domain.Models;
using Infrastructure.DataBases;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepositories : IAuthor
{
    public void Add(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into author(fullname,country,birthyear) values('{author.fullname}', '{author.country}', '{author.birthyear}')";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Added!");
    }

    public void Delete(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from author where id = {id}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Deleted!");
    }

    public Author GetAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select id,fullname,country,birthyear from author where id = {id}";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var author = new Author();
        while (data.Read())
        {
            author.Id = data.GetInt32(0);
            author.fullname = data.GetString(1);
            author.country = data.GetString(2);
            author.birthyear = data.GetInt32(3);
        }
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select id,fullname,country,birthyear from author";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var authors = new List<Author>();
        while (data.Read())
        {
            var author = new Author();
            author.Id = data.GetInt32(0);
            author.fullname = data.GetString(1);
            author.country = data.GetString(2);
            author.birthyear = data.GetInt32(3);
            authors.Add(author);
        }
        return authors;
    }

    public void Update(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update author set fullname = '{author.fullname}', country = '{author.country}', birthyear = '{author.birthyear}' where id = {author.Id}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteReader();
        System.Console.WriteLine("Updated!");
    }

}
