# Processador de Comissões de Vendas

Este projeto é uma solução em **C# (Windows Forms)** desenvolvida para resolver o desafio de cálculo de comissões baseado em regras de negócio dinâmicas e processamento de dados via JSON.

## 🎯 O Desafio
O objetivo era ler um JSON com dados "sujos" (nomes com quebras de linha), sanitizar os dados e calcular comissões seguindo a tabela:
- Vendas < R$ 100,00: **Sem comissão**
- Vendas >= R$ 100,00 e < R$ 500,00: **1% de comissão**
- Vendas >= R$ 500,00: **5% de comissão**

## 🚀 Tecnologias e Técnicas Utilizadas
- **.NET 8 (C#)**: Utilização de recursos modernos da linguagem.
- **Windows Forms**: Para interface gráfica rápida e responsiva.
- **System.Text.Json**: Para desserialização performática de dados.
- **LINQ**: Utilizado para agrupamento (GroupBy), somatórios (Sum) e contagem condicional, eliminando loops manuais e deixando o código limpo.
- **Clean Code**: Separação de responsabilidades (Regra de Negócio separada da Interface).

## 📋 Funcionalidades
1. **Sanitização de Dados**: Tratamento automático de strings (remoção de quebras de linha nos nomes).
2. **Relatório Detalhado**: Exibição não apenas dos totais, mas da quantidade de vendas que se enquadraram em cada faixa de comissão (0%, 1% e 5%).
3. **Tratamento de Erros**: O sistema protege contra JSONs inválidos ou nulos.

## Como rodar
1. Clone o repositório.
2. Abra a solução `ProcessadorVendas.sln` no Visual Studio.
3. Execute o projeto (F5).