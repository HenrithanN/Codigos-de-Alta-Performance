using System;

public static class GlobalMembers
{
	//retorna se a pilha está vazia ou não
	public static bool pilhaVazia(PILHA p)
	{
		if (p.topo == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	//retorna se a pilha está cheia ou não
	public static bool pilhaCheia(PILHA p)
	{
		int tam = p.item.Length; //determina o tamanho do vetor

		if (p.topo < tam)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	//adiciona valor na pilha
	public static void empilha(PILHA p, int x)
	{
		p.item[p.topo++] = x;
	}

	//remove valor da pilha
	public static int desempilha(PILHA p)
	{
		return p.item[--p.topo];
	}

	//retorna o valor que está em cima na pilha
	public static int valorTopo(PILHA p)
	{
		return p.item[p.topo - 1];
	}

	//mostra os valores armazenados na pilha
	public static void mostraPilha(PILHA p)
	{
		Console.Write("Valores da pilha: ");
		if (p.topo > 0)
		{
			for (int i = 0; i < p.topo; i++)
			{
				Console.Write(p.item[i]);
				Console.Write(" ");
			}
		}
		else
		{
			Console.Write("pilha vazia");
		}
		Console.Write("\n");
	}

	public static void mostraPorto(PILHA[] vet)
	{
		for (int i = 0; i < DefineConstants.tamPorto; i++)
		{
			Console.Write("Porto ");
			Console.Write(i + 1);
			Console.Write(" -> ");
			mostraPilha(vet[i]);
		}
	}

	//determina qual pilha está mais vazia retornando a posição no vetor
	public static int pilhaMaisVazia(PILHA[] vet)
	{
		//armazena o menor valor e que pilha (posicao) ele esta
		int menor = vet[0].topo;
		int posicao = 0;
		for (int i = 1; i < DefineConstants.tamPorto; i++)
		{
			if (vet[i].topo < menor)
			{
				menor = vet[i].topo;
				posicao = i;
			}
		}

		return posicao;
	}

	public static void mostraOpcoes()
	{
		Console.Write("Opcoes disponiveis: ");
		Console.Write("\n");
		Console.Write("0: sair");
		Console.Write("\n");
		Console.Write("1: adicionar container");
		Console.Write("\n");
		Console.Write("2: remover   container");
		Console.Write("\n");
		Console.Write("Digite sua opcao: ");
	}

	//verifica se o código está presente em alguma das pilhas do porto
	//se existir retorna a posicao no vetor (local do porto)
	public static int codigoExiste(PILHA[] vet, int cod)
	{
		for (int i = 0; i < DefineConstants.tamPorto; i++)
		{
			for (int j = 0; j < vet[i].topo; j++)
			{
				if (vet[i].item[j] == cod)
				{
					return i;
				}
			}
		}
		return -1; //se não encontrar o código vai retornar aqui
	}

	internal static void Main()
	{
		PILHA[] local = Arrays.InitializeWithDefaultInstances<PILHA>(DefineConstants.tamPorto); //cria um vetor de pilhas
		int opcao;
		int codigo;

		while (true)
		{
			mostraOpcoes();
			opcao = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (opcao == 0)
			{
				break;
			}

			Console.Write("Informe o codigo do container: ");
			codigo = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

			if (opcao == 1)
			{ //adicionar container
				if (codigoExiste(local, codigo) != -1)
				{
					Console.Write("###################################################");
					Console.Write("\n");
					Console.Write("###################Codigo invalido!################");
					Console.Write("\n");
					Console.Write("###################################################");
					Console.Write("\n");
				}
				else
				{
					int posicaoPorto = pilhaMaisVazia(local);
					if (pilhaCheia(local[posicaoPorto]))
					{
						Console.Write("###################################################");
						Console.Write("\n");
						Console.Write("###################Impossivel empilhar!################");
						Console.Write("\n");
						Console.Write("###################################################");
						Console.Write("\n");
					}
					else
					{
						empilha(local[posicaoPorto], codigo);
					}
				}
			}
			else
			{ //remover container
				int posicaoPorto = codigoExiste(local, codigo);
				if (posicaoPorto == -1)
				{
					Console.Write("###################################################");
					Console.Write("\n");
					Console.Write("###################Codigo invalido!################");
					Console.Write("\n");
					Console.Write("###################################################");
					Console.Write("\n");
				}
				else
				{
					if (valorTopo(local[posicaoPorto]) == codigo)
					{
						desempilha(local[posicaoPorto]);
					}
					else
					{
						Console.Write("###################################################");
						Console.Write("\n");
						Console.Write("###################Impossivel desempilhar!################");
						Console.Write("\n");
						Console.Write("###################################################");
						Console.Write("\n");
					}
				}
			}

			mostraPorto(local);
			Console.Write("\n");
		}

	}
}