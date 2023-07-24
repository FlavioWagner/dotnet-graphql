namespace graphql.api.src.Presentation.GraphQL.Mutations
{
    public class Mutation
    {
        public PessoaMutation pessoa { get; set; }
        public PessoaFisicaMutation pessoaFisica { get; set; }

        public Mutation(PessoaMutation pessoa,
                        PessoaFisicaMutation pessoaFisica)
        {
            this.pessoa = pessoa;
            this.pessoaFisica = pessoaFisica;
        }
    }
}
