using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiLoginUsuarios.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        //[BsonElement("Name")]
        public string? Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string SenhaLembrete { get; set; } = null!;
        public int Codigo { get; set; }
        public int Idade { get; set; }
        public string? Telefone { get; set; }
        public string? Sexo { get; set; } = null!;
    }
}
