using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcessadorVendas
{
    // 1. MODELO (POCO)
    public class Venda
    {
        [JsonPropertyName("vendedor")]
        public string VendedorRaw { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

        public string Vendedor => VendedorRaw?.Replace("\n", " ").Trim();
    }

    public class ListaVendas
    {
        [JsonPropertyName("vendas")]
        public List<Venda> Vendas { get; set; }
    }

    // 2. LÓGICA DE NEGÓCIO
    public class CalculadoraComissao
    {
        public decimal Calcular(decimal valorVenda)
        {
            if (valorVenda < 100) return 0;
            if (valorVenda < 500) return valorVenda * 0.01m; // 1%
            return valorVenda * 0.05m; // 5%
        }
    }

    // 3. DTO (RELATÓRIO) - ATUALIZADO
    public class RelatorioVendedor
    {
        public string Nome { get; set; }
        public int QuantidadeVendas { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal TotalComissao { get; set; }

        // --- NOVAS COLUNAS PARA O DETALHAMENTO ---
        public int VendasSemComissao { get; set; } // < 100
        public int Vendas1Porcento { get; set; }   // 100 a 499
        public int Vendas5Porcento { get; set; }   // >= 500
    }
}