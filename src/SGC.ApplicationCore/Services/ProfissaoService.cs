using SGC.ApplicationCore.Enity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.ApplicationCore.Interfaces.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Services
{
    public class ProfissaoService : IProfissaoService
    {
        private readonly IProfissaoRepository _profissaoRepository;

        public ProfissaoService(IProfissaoRepository profissaoRepository)
        {
            _profissaoRepository = profissaoRepository;
        }
           
        public Profissao Adicionar(Profissao entity)
        {
            return _profissaoRepository.Adicionar(entity); 
        }

        public void Atualizar(Profissao entity)
        {
            _profissaoRepository.Atualizar(entity);
        }

        public IEnumerable<Profissao> Buscar(Expression<Func<Profissao, bool>> predicado)
        {
            return _profissaoRepository.Buscar(predicado);

        }

        public Profissao ObterPorId(int id)
        {
           return _profissaoRepository.ObterPorId(id);

        }

        public IEnumerable<Profissao> ObterTodos()
        {
            return _profissaoRepository.ObterTodos();

        }

        public void Remover(Profissao entity)
        {
            _profissaoRepository.Remover(entity);

        }

   
    }
}
