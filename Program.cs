using ClashOfHeroes;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o nome do primeiro herói:");
        var nomeHeroi1 = Console.ReadLine();

        Console.WriteLine($"Digite a vida do herói {nomeHeroi1}:");
        var vidaHeroi1 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite o dano do herói {nomeHeroi1}:");
        var danoHeroi1 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite a defesa do herói {nomeHeroi1}:");
        var defesaHeroi1 = int.Parse(Console.ReadLine());


        // Bloco Herói 2

        Console.WriteLine("Digite o nome do segundo herói:");
        var nomeHeroi2 = Console.ReadLine();

        Console.WriteLine($"Digite a vida do herói {nomeHeroi2}:");
        var vidaHeroi2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite o dano do herói {nomeHeroi2}:");
        var danoHeroi2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite a defesa do herói {nomeHeroi2}:");
        var defesaHeroi2 = int.Parse(Console.ReadLine());

        Console.Clear();

        var heroi1 = new Heroi(vidaHeroi1, danoHeroi1, defesaHeroi1, nomeHeroi1);
        var heroi2 = new Heroi(vidaHeroi2, danoHeroi2, defesaHeroi2, nomeHeroi2);

        Console.WriteLine(heroi1.toString());
        Console.WriteLine(heroi2.toString());

        //Bloco de Batalha
        Console.WriteLine("");
        Console.WriteLine("Iniciando Batalha");

        Random random = new Random();
        int heroiEscolhido = random.Next(1, 3);

        Heroi[] ordemHerois;

        if (heroiEscolhido == 1)
            ordemHerois = [heroi1, heroi2];
        else
            ordemHerois = [heroi2, heroi1];

        var count = 0;
        while (heroi1.Vida > 0 && heroi2.Vida > 0)
        {
            ExecutaAcao(ordemHerois);
            count++;
        }
        Console.WriteLine($"Número de acões executadas {count}");
    }

    public static void ExecutaAcao(Heroi[] ordemHerois) 
    {
        for (int i = 0; i < ordemHerois.Length; i++)
        {
            var heroiEscolhido = ordemHerois[i];

            if(heroiEscolhido.Vida == 0)
            {
                Console.WriteLine($"O herói {heroiEscolhido.Nome} morreu");
                continue;
            }

            var outroHeroi = ordemHerois.Where(heroi => heroi.Nome != heroiEscolhido.Nome).FirstOrDefault();

            Random random = new Random();
            int randomAcao= random.Next(0, 2);

            var acaoEscolhida = heroiEscolhido.Acoes[randomAcao];
            heroiEscolhido.UltimaAcaoEscolhida = acaoEscolhida;

            var danoEfetivo = heroiEscolhido.Dano;
            if (acaoEscolhida == AcaoEnum.Atacar)
            {
                int vidaAposDano;
                if (outroHeroi.UltimaAcaoEscolhida == AcaoEnum.Defender)
                {
                    var danoAposDefesa = heroiEscolhido.Dano - outroHeroi.Defesa;
                    if (danoAposDefesa > 0)
                    {
                        vidaAposDano = outroHeroi.Vida - danoAposDefesa;
                        danoEfetivo = danoAposDefesa;
                    }
                    else
                    {
                        vidaAposDano = outroHeroi.Vida;
                        danoEfetivo = 0;
                    }

                }
                else
                {
                    vidaAposDano = outroHeroi.Vida - heroiEscolhido.Dano;
                }

                if (vidaAposDano >= 0)
                    outroHeroi.Vida = vidaAposDano;
                else
                    outroHeroi.Vida = 0;
            }
            Console.WriteLine("");
            Console.WriteLine($"O {heroiEscolhido.Nome} escolheu {heroiEscolhido.UltimaAcaoEscolhida.ToString()}");

            if (heroiEscolhido.UltimaAcaoEscolhida == AcaoEnum.Atacar)
            {
                Console.WriteLine($"O {heroiEscolhido.Nome} tirou {danoEfetivo} de vida do {outroHeroi.Nome}");
            }
            Console.WriteLine($"Vida Atual - {heroiEscolhido.Nome}:{heroiEscolhido.Vida}. {outroHeroi.Nome}:{outroHeroi.Vida}");
        }
     }
}
 