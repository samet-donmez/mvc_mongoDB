// mvc_mongodb.Models/Departman.cs

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace mvc_mongodb.Models
{
    public class Departman
    {
        // string kullanıyorsanız, Id'yi null atanabilir (string?) yapmayı deneyin
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // string yerine string? (nullable string) yapın

        [Required(ErrorMessage = "Departman adı boş bırakılamaz")]
        public string DepartmanAd { get; set; }

        // Personeller listesi KESİNLİKLE YOK
    }
}