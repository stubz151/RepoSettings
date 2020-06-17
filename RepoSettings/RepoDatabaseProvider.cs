using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.Models
{
    public class RepoDatabaseSettings : IRepoDatabaseSettings
    {
        public string RepoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRepoDatabaseSettings
    {
        string RepoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
