using MongoFramework;
using mvc_mongodb.Models;

namespace mvc_mongodb.Data
{
    public class AppDbContext : MongoDbContext
    {
        public AppDbContext(IMongoDbConnection connection) : base(connection)
        {
        }

        public MongoDbSet<Departman> Departmanlar { get; set; }
    }
}
