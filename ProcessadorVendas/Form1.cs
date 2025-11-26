using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ProcessadorVendas
{
    public partial class Form1 : Form
    {
        string jsonInput = @"
        {
         ""vendas"": [
          { ""vendedor"": ""João\nSilva"", ""valor"": 1200.50 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 950.75 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 1800.00 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 1400.30 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 1100.90 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 1550.00 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 1700.80 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 250.30 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 480.75 },
          { ""vendedor"": ""João\nSilva"", ""valor"": 320.40 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 2100.40 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 1350.60 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 950.20 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 1600.75 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 1750.00 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 1450.90 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 400.50 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 180.20 },
          { ""vendedor"": ""Maria\nSouza"", ""valor"": 90.75 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 800.50 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 1200.00 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 1950.30 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 1750.80 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 1300.60 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 300.40 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 500.00 },
          { ""vendedor"": ""Carlos\nOliveira"", ""valor"": 125.75 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1000.00 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1100.50 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1250.75 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1400.20 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1550.90 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 1650.00 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 75.30 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 420.90 },
          { ""vendedor"": ""Ana\nLima"", ""valor"": 315.40 }
         ]
        }";

        private readonly CalculadoraComissao _calculadora;
        private ListaVendas _dadosCarregados;

        public Form1()
        {
            InitializeComponent();
            _calculadora = new CalculadoraComissao();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _dadosCarregados = JsonSerializer.Deserialize<ListaVendas>(jsonInput);

                if (_dadosCarregados?.Vendas != null)
                {
                    gridVendas.DataSource = _dadosCarregados.Vendas;
                    gridVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    gridVendas.Columns["Valor"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (_dadosCarregados?.Vendas == null) return;

            // --- LÓGICA ATUALIZADA ---
            var relatorio = _dadosCarregados.Vendas
                .GroupBy(v => v.Vendedor)
                .Select(grupo => new RelatorioVendedor
                {
                    Nome = grupo.Key,

                    // Totais Gerais
                    QuantidadeVendas = grupo.Count(),
                    TotalVendido = grupo.Sum(v => v.Valor),
                    TotalComissao = grupo.Sum(v => _calculadora.Calcular(v.Valor)),

                    // --- DETALHAMENTO DAS REGRAS (AQUI ESTÁ O TRUQUE) ---
                    // Conta quantas vendas são menores que 100
                    VendasSemComissao = grupo.Count(v => v.Valor < 100),

                    // Conta quantas estão entre 100 e 500
                    Vendas1Porcento = grupo.Count(v => v.Valor >= 100 && v.Valor < 500),

                    // Conta quantas são 500 ou mais
                    Vendas5Porcento = grupo.Count(v => v.Valor >= 500)
                })
                .OrderByDescending(r => r.TotalComissao)
                .ToList();

            dataGridView1.DataSource = relatorio;

            // Formatação Visual
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["TotalVendido"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["TotalComissao"].DefaultCellStyle.Format = "C2";

            // Renomeando os cabeçalhos para ficar profissional
            dataGridView1.Columns["QuantidadeVendas"].HeaderText = "Total Vendas";
            dataGridView1.Columns["TotalVendido"].HeaderText = "Total R$";
            dataGridView1.Columns["TotalComissao"].HeaderText = "Comissão Total";

            // Cabeçalhos novos
            dataGridView1.Columns["VendasSemComissao"].HeaderText = "Qtd (0%)";
            dataGridView1.Columns["Vendas1Porcento"].HeaderText = "Qtd (1%)";
            dataGridView1.Columns["Vendas5Porcento"].HeaderText = "Qtd (5%)";
        }
    }
}