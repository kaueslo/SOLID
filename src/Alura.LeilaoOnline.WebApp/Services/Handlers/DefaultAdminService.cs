using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
	public class DefaultAdminService : IAdminService
	{
		ILeilaoDao _leilaodao;
		ICategoriaDao _categoriaDao;

		public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
		{
			_leilaodao = leilaoDao;
			_categoriaDao = categoriaDao;
		}

		public void CadastraLeilao(Leilao leilao)
		{
			_leilaodao.Incluir(leilao);
		}

		public IEnumerable<Categoria> ConsultaCategorias()
		{
			return _categoriaDao.BuscarTodos();
		}

		public Leilao ConsultaLeilaoPorId(int id)
		{
			return _leilaodao.BuscarPorId(id);
		}

		public IEnumerable<Leilao> ConsultaLeiloes()
		{
			return _leilaodao.BuscarTodos();
		}

		public void FinalizaPregaoDoLeilaoComId(int id)
		{
			var leilao = _leilaodao.BuscarPorId(id);
			if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
			{
				leilao.Situacao = SituacaoLeilao.Finalizado;
				leilao.Termino = DateTime.Now;
				_leilaodao.Alterar(leilao);
			}
		}

		public void IniciaPregaoDoLeilaoComId(int id)
		{
			var leilao = _leilaodao.BuscarPorId(id);
			if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
			{
				leilao.Situacao = SituacaoLeilao.Pregao;
				leilao.Inicio = DateTime.Now;
				_leilaodao.Alterar(leilao);
			}
		}

		public void ModificaLeilao(Leilao leilao)
		{
			_leilaodao.Alterar(leilao);
		}

		public void RemoveLeilao(Leilao leilao)
		{
			if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
			{
				_leilaodao.Excluir(leilao);
			}
		}
	}
}
