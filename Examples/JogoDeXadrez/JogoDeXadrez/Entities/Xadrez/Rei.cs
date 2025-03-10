﻿using JogoDeXadrez.Entities.Tabuleiro;

namespace JogoDeXadrez.Entities.Xadrez
{
	internal class Rei : Peca
	{
		public Rei(Cor cor, Tab tab) : base(cor, tab)
		{


		}
		public override string ToString()
		{
			return "R";
		}

		private bool podeMover(Posicao pos)
		{
			Peca p = Tab.peca(pos);
			return p == null || p.Cor != Cor;
		}

		public override bool[,] movimentosPossiveis()
		{
			bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

			Posicao pos = new Posicao(0, 0);


			//verifica acima
			pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
			

			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica nordeste
			pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica direita
			pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}


			// verifica suldeste
			pos.definirValores(Posicao.Linha +1, Posicao.Coluna + 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica abaixo
			pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica sudoeste
			pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica esquerda
			pos.definirValores(Posicao.Linha , Posicao.Coluna - 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			// verifica noroeste
			pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
			if (Tab.posicaoValida(pos) && podeMover(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			return mat;
		}


	}
}
