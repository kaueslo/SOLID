using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
	public class DefaultProdutoService : IProdutoService
	{
		ILeilaoDao _dao;
		ICategoriaDao _categoriaDao;

		public DefaultProdutoService(ILeilaoDao dao, ICategoriaDao categoriaDao)
		{
			_dao = dao;
			_categoriaDao = categoriaDao;
		}

		public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
		{
			return _categoriaDao.ConsultaCategoriaPorId(id);
		}

		public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao()
		{
			return _categoriaDao
				.ConsultaCategorias()
				.Select(x => new CategoriaComInfoLeilao
				{
					Id = x.Id,
					Descricao = x.Descricao,
					Imagem = x.Imagem,
					EmRascunho = x.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
					EmPregao = x.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
					Finalizados = x.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count()
				});
		}

		public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
		{
			var termoNormalized = termo.ToUpper();

			return _dao.BuscarTodosLeiloes()
				.Where(x =>
				x.Titulo.ToUpper().Contains(termoNormalized) ||
				x.Descricao.ToUpper().Contains(termoNormalized) ||
				x.Categoria.Descricao.ToUpper().Contains(termoNormalized));
		}
	}
}
