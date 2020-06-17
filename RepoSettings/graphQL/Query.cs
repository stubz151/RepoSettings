using HotChocolate.Types;
using HotChocolate.Types.Relay;
using RepoSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.graphQL
{
    public class Query
    {
        private readonly RepoService _repoService;
        public Query(RepoService repoService)
        {
            _repoService = repoService;
        }

        [UsePaging(SchemaType = typeof(RepoType))]
        [UseFiltering]
        public List<RepoModel> repoModels()
        {
            return _repoService.GetAll();
        }

    }
}
