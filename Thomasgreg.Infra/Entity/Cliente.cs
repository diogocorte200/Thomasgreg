namespace Thomasgreg.Infra.Entity
{

    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public virtual ICollection<Logradouro> Logradouros { get; set; }
    }
}
