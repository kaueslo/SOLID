using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ILeilaoDao : ICommand<Leilao>, IQuery<Leilao>
	{
	}
}
