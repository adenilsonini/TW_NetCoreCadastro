namespace Cadastro.Domain.Entities
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Disponivel { get; set; }
        public int IdCliente { get; set; }
        public virtual Client Client { get; set; }

    }
}