using graphql.api.src.Application.Entities;
using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;
using graphql.api.src.Presentation.GraphQL.Interfaces;

namespace graphql.api.src.Presentation.GraphQL.Mutations
{
    public class RamoMutation : CustomMutation<Ramo>
    {
        public RamoMutation(IRepository<Ramo> repository) : base(repository)
        {
        }
    }
}
