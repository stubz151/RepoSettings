using HotChocolate.Types;
using HotChocolate.Types.Relay;
using RepoSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.graphQL
{
    [ExtendObjectType(Name = "Mutation")]
    public class Mutation
    {
        private readonly RepoService _repoService;

        public Mutation(RepoService repoService)
        {
            _repoService = repoService;
        }

        public RepoModel CreateRepo(CreateRepoInput insertRepo)
        {
            var newRepo = new RepoModel
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = insertRepo.Name,
                MaximumLastCommitDate = insertRepo.MaximumLastCommitDate
            };
            return _repoService.Insert(newRepo);
        }

        public RepoModel UpdateRepo(RepoModel repoModel)
        {
            return _repoService.Update(repoModel);
        }
    }
}
