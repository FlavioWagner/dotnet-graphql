namespace graphql.api.src.Application.Entities
{
    public partial class Ramo : IEntity
    {
        public Ramo()
        {
            RamoJuridica = new HashSet<RamoJuridica>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<RamoJuridica> RamoJuridica { get; set; }
    }
}
