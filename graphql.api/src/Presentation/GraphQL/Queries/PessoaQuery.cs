using graphql.api.src.Application.Entities;
using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;
using graphql.api.src.Presentation.GraphQL.Interfaces;

namespace graphql.api.src.Presentation.GraphQL.Queries
{
    public class PessoaQuery : CustomQuery<Pessoa>
    {
        public PessoaQuery(IRepository<Pessoa> repository) : base(repository)
        {            
        }
    }
}
