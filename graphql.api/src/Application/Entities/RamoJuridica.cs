namespace graphql.api.src.Application.Entities
{
    public partial class RamoJuridica
    {
        public long Id { get; set; }
        public long IdPessoaJuridica { get; set; }
        public long IdRamo { get; set; }

        public virtual PessoaJuridica IdPessoaJuridicaNavigation { get; set; } = null!;
        public virtual Ramo IdRamoNavigation { get; set; } = null!;
    }
}
