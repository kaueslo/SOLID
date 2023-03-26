using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
	public interface IQuery<T>
	{
		IEnumerable<T> BuscarTodos();
		T BuscarPorId(int id);
	}
}
