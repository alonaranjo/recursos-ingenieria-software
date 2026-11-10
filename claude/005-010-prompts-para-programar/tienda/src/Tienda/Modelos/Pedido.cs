namespace Tienda.Modelos;

public class Pedido
{
    public int Id { get; set; }
    public string Estado { get; set; } = "PENDIENTE";
    public List<ItemPedido> Items { get; set; } = new();
}
