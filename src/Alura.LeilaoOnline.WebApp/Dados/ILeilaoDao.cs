using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ILeilaoDao
	{
		Leilao BuscarLeilaoPorId(int id);

		IEnumerable<Leilao> BuscarTodosLeiloes();

		IEnumerable<Categoria> BuscarTodasCategorias();

		void IncluirLeilao(Leilao obj);

		void AlterarLeilao(Leilao obj);

		void ExcluirLeilao(Leilao leilao);
	}
}
