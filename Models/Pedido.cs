namespace RaizesUrbanaWeb.Models
{
    public class Pedido
    {
        public int Id { get; set; }  // ID único do pedido
        public string NomeRemetente { get; set; }  // Nome do cliente
        public string Endereco { get; set; }  // Endereço de entrega
        public string Produto { get; set; }  // Nome do produto
        public int Quantidade { get; set; }  // Quantidade do produto
        public string FormaPagamento { get; set; }  // Forma de pagamento (PIX ou Cartão)
        public bool FreteGratis { get; set; }  // Se o frete foi grátis ou pago
        public decimal PrecoTotal { get; set; }  // Preço total do pedido
        public DateTime DataPedido { get; set; }  // Data e hora do pedido
    }
}
