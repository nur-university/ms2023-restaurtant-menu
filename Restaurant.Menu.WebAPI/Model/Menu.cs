namespace Restaurant.Menu.WebAPI.Model
{
    public class Menu
    {

        private readonly Dictionary<string, MenuItem> _items;

        public Menu()
        {
            _items = new Dictionary<string, MenuItem>();
            _items.Add("F0772CD9-A9DA-432F-8E2B-066065725CC9", new MenuItem()
            {
                Id = Guid.Parse("F0772CD9-A9DA-432F-8E2B-066065725CC9"),
                Nombre = "Coca-Cola 2Lt. No Retornable",
                Precio = 12,
                EsInventariable = true
            });

            _items.Add("5A81F6E4-9675-4666-9491-6A8474970FCA", new MenuItem()
            {
                Id = Guid.Parse("5A81F6E4-9675-4666-9491-6A8474970FCA"),
                Nombre = "Pepsi 2Lt. No Retornable",
                Precio = 10,
                EsInventariable = true
            });

            _items.Add("AAAF1BF7-C55C-4A5C-BB88-8D43D6618940", new MenuItem()
            {
                Id = Guid.Parse("AAAF1BF7-C55C-4A5C-BB88-8D43D6618940"),
                Nombre = "Fanta Naranja 2Lt. No Retornable",
                Precio = 10,
                EsInventariable = true
            });

            _items.Add("0F943309-E58F-48EB-AFCE-ADDE338AA752", new MenuItem()
            {
                Id = Guid.Parse("0F943309-E58F-48EB-AFCE-ADDE338AA752"),
                Nombre = "Fanta Guaraná 2Lt. No Retornable",
                Precio = 11,
                EsInventariable = true
            });

            _items.Add("3FB4EF85-07BC-4DF2-BA25-D44FADEE9F7B", new MenuItem()
            {
                Id = Guid.Parse("3FB4EF85-07BC-4DF2-BA25-D44FADEE9F7B"),
                Nombre = "Huari",
                Precio = 8,
                EsInventariable = true
            });
        }


        public MenuItem GetItem(string id)
        {
            return _items.ContainsKey(id) ? _items[id] : null;
        }
    }
}
