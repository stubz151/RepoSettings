using MongoDB.Bson.IO;
using MongoDB.Driver;
using RepoSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepoSettings
{
    public class RepoService
    {
        private readonly IMongoCollection<RepoModel> _repos;

        public RepoService(IRepoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _repos = database.GetCollection<RepoModel>(settings.RepoCollectionName);
        }

        public List<RepoModel> GetAll() => _repos.Find(x => true).ToList();

        public RepoModel GetSpecific(string id) => _repos.Find(x => x.Id == id).FirstOrDefault();

        public RepoModel Insert(RepoModel newRepo)
        {
            _repos.InsertOne(newRepo);
            return newRepo;
        }

        public RepoModel Update(RepoModel updatedRepo)
        {
            _repos.ReplaceOne(x => x.Id == updatedRepo.Id, updatedRepo);
            return updatedRepo;
        }

        public void Remove(RepoModel repoToBeDeleted) => _repos.DeleteOne(x => x.Id == repoToBeDeleted.Id);

        public void Remove(string id) => _repos.DeleteOne(x => x.Id == id);
    }
}
