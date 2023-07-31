namespace graphql.api.src.Presentation.GraphQL.Queries
{
    public class Query
    {
        public PessoaQuery pessoa { get; set; }
        public PessoaFisicaQuery pessoaFisica { get; set; }
        public RamoQuery Ramo { get; set; }

        public Query(PessoaQuery pessoa,
                     PessoaFisicaQuery pessoaFisica,
                     RamoQuery ramo)
        {
            this.pessoa = pessoa;
            this.pessoaFisica = pessoaFisica;
            this.Ramo = ramo;
        }
    }
}
