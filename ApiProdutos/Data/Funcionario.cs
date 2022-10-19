using System;

namespace ApiProdutos.Data
{
    public class Funcionario
    {
        public int funcionarioId { get; set; }
        public string nome { get; set; }
        public int departamento_id { get; set; }
        public DateTime data_entrada { get; set; }
    }
}
