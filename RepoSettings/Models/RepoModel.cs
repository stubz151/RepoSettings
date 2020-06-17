using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.Models
{
    public class RepoModel
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public DateTime MaximumLastCommitDate { get; set; }

        public Boolean ShouldBeCleaned { get; set; } = false;

        public int AmountOfReleaseBranchesToKeep { get; set; } = 9999;
    }
}
