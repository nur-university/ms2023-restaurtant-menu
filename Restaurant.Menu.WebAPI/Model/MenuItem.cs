namespace Restaurant.Menu.WebAPI.Model
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool EsInventariable { get; set; }
        public decimal Precio { get; set; }
    }
}
