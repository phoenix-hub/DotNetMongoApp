using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class BookServices : IBookServices
    {
        IMongoClient mongoClient = new MongoClient("mongodb://127.0.0.1:27017");

        public List<Book> DeleteBook(string _id)
        {
            var database = mongoClient.GetDatabase("DotNetMongoDb");
            var collection = database.GetCollection<Book>("MyBookStore");
             
            collection.DeleteOne(Builders<Book>.Filter.Eq("Id", _id));

            var result = collection.Find<Book>(a => true).ToList();
            return result;
        }

        public Book GetBook(string _id)
        {
            var database = mongoClient.GetDatabase("DotNetMongoDb");
            var collection = database.GetCollection<Book>("MyBookStore");
            var result = collection.Find<Book>(a => a.Id.Equals(_id)).SingleOrDefault();
            return result;
        }

        public List<Book> GetBooks()
        {
            var database = mongoClient.GetDatabase("DotNetMongoDb");
            var collection = database.GetCollection<Book>("MyBookStore");
            var result = collection.Find<Book>(a => true).ToList();
            return result;
        }
        public List<Book> PostBook(Book book)
        {
            var database = mongoClient.GetDatabase("DotNetMongoDb");
            var collection = database.GetCollection<Book>("MyBookStore");
            collection.InsertOne(book);

            var result = collection.Find<Book>(a => true).ToList();
            return result;
        }

        public Book UpdateBook(Book book)
        {
            var database = mongoClient.GetDatabase("DotNetMongoDb");
            var collection = database.GetCollection<Book>("MyBookStore"); 

            collection.UpdateOne(Builders<Book>.Filter.Eq("Id", book.Id), Builders<Book>.Update.Set("Price", book.Price)
                                                                .Set("Category", book.Category)
                                                                .Set("Author", book.Author));

            var result = collection.Find<Book>(a => a.Id.Equals(book.Id)).FirstOrDefault();
            return result;
        } 
    }
}
