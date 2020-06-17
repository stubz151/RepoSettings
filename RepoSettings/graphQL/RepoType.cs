using HotChocolate.Types;
using RepoSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoSettings.graphQL
{
    public class RepoType : ObjectType<RepoModel>
    {
        protected override void Configure(IObjectTypeDescriptor<RepoModel> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.AmountOfReleaseBranchesToKeep).Type<IntType>();
            descriptor.Field(a => a.ShouldBeCleaned).Type<BooleanType>();
            descriptor.Field(a => a.MaximumLastCommitDate).Type<DateType>();
        }
    }
}
