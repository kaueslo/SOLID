using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
	public interface ICommand<T>
	{
		void Incluir(T obj);
		void Alterar(T obj);
		void Excluir(T obj);
	}
}
