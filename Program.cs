using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        const int valorMaximo = 100000;

        var acoes = new Dictionary<string, Acao>
        {
            { "A", new Acao { Custo = 30000, Retorno = 40000 } },
            { "B", new Acao { Custo = 50000, Retorno = 60000 } },
            { "C", new Acao { Custo = 40000, Retorno = 45000 } },
            { "D", new Acao { Custo = 10000, Retorno = 15000 } },
            { "E", new Acao { Custo = 20000, Retorno = 25000 } }
        };

        List<AcaoSelecionada> items = acoes.Select(acao => new AcaoSelecionada
        {
            Nome = acao.Key,
            Custo = acao.Value.Custo,
            Retorno = acao.Value.Retorno,
            Razao = Razao(acao.Value)
        })
        .OrderBy(item => item.Razao)
        .ToList();

        int valorAtual = 0;
        List<AcaoSelecionada> acoesEscolhidas = new List<AcaoSelecionada>();

        foreach (var item in items)
        {
            if ((valorAtual + item.Custo) > valorMaximo)
            {
                continue;
            }

            while ((valorAtual + item.Custo) <= valorMaximo)
            {
                acoesEscolhidas.Add(item);
                valorAtual += item.Custo;
            }
        }

        foreach (var acao in acoesEscolhidas)
        {
            Console.WriteLine($"Ação: {acao.Nome}, Custo: {acao.Custo}, Retorno: {acao.Retorno}, Razão: {acao.Razao}");
        }
    }

    static double Razao(Acao acao)
    {
        return (double)acao.Custo / acao.Retorno;
    }

    class Acao
    {
        public int Custo { get; set; }
        public int Retorno { get; set; }
    }

    class AcaoSelecionada : Acao
    {
        public string Nome { get; set; } = null!;
        public double Razao { get; set; }
    }
}
