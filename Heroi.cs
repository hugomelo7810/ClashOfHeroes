using System;
using System.Collections.Generic;
using System.Text;

namespace ClashOfHeroes
{
    public class Heroi
    {
        public Heroi(int vida, int dano, int defesa, string nome)
        {
            Vida = vida;
            Dano = dano;
            Defesa = defesa;
            Nome = nome;
            Acoes = [AcaoEnum.Atacar, AcaoEnum.Defender];
        }

        public string toString()
        {
            return $"O herói {Nome} tem {Vida} de vida, {Dano} de dano e {Defesa} de defesa";
        }
        
        public int Vida { get; set; }
        public int Dano { get; set; }
        public int Defesa { get; set; }
        public string Nome { get; set; }
        public AcaoEnum[] Acoes { get; set; }
        public AcaoEnum UltimaAcaoEscolhida { get; set; }
    }
}
