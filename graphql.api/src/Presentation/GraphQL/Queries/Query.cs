namespace graphql.api.src.Presentation.GraphQL.Queries
{
    public class Query
    {
        public PessoaQuery pessoa { get; set; }
        public PessoaFisicaQuery pessoaFisica { get; set; }

        public Query(PessoaQuery pessoa,
                     PessoaFisicaQuery pessoaFisica)
        {
            this.pessoa = pessoa;
            this.pessoaFisica = pessoaFisica;
        }
    }
}
