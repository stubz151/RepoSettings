using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.Models
{
    public class CreateRepoInput
    {
        public string Name { get; set; }

        public DateTime MaximumLastCommitDate { get; set; }

        public CreateRepoInput(string name, DateTime date)
        {
            this.Name = name;
            this.MaximumLastCommitDate = date;
        }
        public CreateRepoInput() { }
    }
}
