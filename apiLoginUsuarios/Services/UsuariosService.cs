using apiLoginUsuarios.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace apiLoginUsuarios.Services
{
    public class UsuariosService
    {
        private readonly IMongoCollection<Usuario> _usuariosCollection;
        public UsuariosService(IOptions<UsuariosDatabaseSettings> usuariosDatabaseSettings)
        {
            var mongoclient = new MongoClient(
                usuariosDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(
                usuariosDatabaseSettings.Value.DatabaseName);
            _usuariosCollection = mongoDatabase.GetCollection<Usuario>(
                usuariosDatabaseSettings.Value.UsuariosCollectionName);
        }

        public async Task<List<Usuario>> GetAsync() =>
            await _usuariosCollection.Find(_ => true).ToListAsync();
        public async Task<Usuario?> GetAsync(string id) =>
            await _usuariosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Usuario?> GetAsyncByEmail(string email) =>
            await _usuariosCollection.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario newUsuario) =>
            await _usuariosCollection.InsertOneAsync(newUsuario);

        public async Task UpdateAsync(string id, Usuario updatedUsuario) =>
            await _usuariosCollection.ReplaceOneAsync(x => x.Id == id, updatedUsuario);

        public async Task RemoveAsync(string id) =>
            await _usuariosCollection.DeleteOneAsync(x => x.Id == id);
    }
}