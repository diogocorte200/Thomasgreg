using AutoMapper;

using System.Collections.Generic;

using Thomasgreg.Domain.Domain;
using Thomasgreg.Domain.Service.Generic;
using Thomasgreg.Infra.Entity;
using Thomasgreg.Infra.Repositories;
using Thomasgreg.Infra.Repositories.Interfaces;
using Thomasgreg.Infra.UnitofWork;

namespace Thomasgreg.Domain.Service
{
    public class LogradouroService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : LogradouroModel
                                                where Te : Logradouro
    {
        ILogradouroRepository _logradouroRepository;

        public LogradouroService(IUnitofWork unitOfWork, IMapper mapper,
                             ILogradouroRepository logradouroRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_logradouroRepository == null)
                _logradouroRepository = logradouroRepository;
        }

        public Logradouro ModelarLogradouro(LogradouroCreateModel logradouro)
        {
            Logradouro result = new Logradouro()
            {
                Id = Guid.NewGuid(),
                IdCliente = logradouro.IdCliente,
                CEP = logradouro.CEP,
                Rua = logradouro.Rua,
                Cidade = logradouro.Cidade,
                Bairro = logradouro.Bairro,
                Estado = logradouro.Estado,
                Numero = logradouro.Numero,
                Complemento = logradouro.Complemento
            };

            return result;
        }

        //public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> AdicionarLogradouro(LogradouroCreateModel logradouro)
        //{

        //    RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();
        //    try
        //    {
        //        var entityLogradouro = await ModelarLogradouro(logradouro);


        //        _logradouroRepository.Add(entityLogradouro);
        //        _logradouroRepository.Save();


        //        return retornoController;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}


        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> AdicionarLogradouro(LogradouroCreateModel logradouro)
        {
            //var logradouroExistente = await BuscarLogradouroNome(logradouro.NomeLogradouro);

            //if (logradouroExistente != null)
            //{
            //    return null;
            //}

            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();
            try
            {
                var logradouroInserir = ModelarLogradouro(logradouro);
                var entityLogradouro = logradouroInserir;

                _logradouroRepository.Add(entityLogradouro);
                _logradouroRepository.Save();


                return retornoController;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> DeletarLogradouro(string idLogradouro)
        {

            var result = _logradouroRepository.GetSingleOrDefault(x => x.Id.ToString() == idLogradouro);

            if (result == null)
                throw new Exception("Logradouro não encontrado.");

            _logradouroRepository.Remove(result);
            _logradouroRepository.Save();

            return idLogradouro;
        }


        public async Task<List<LogradouroModel>> ListarLougradouros()
        {
            var LougradourosAtivos = _logradouroRepository.GetAll();

            List<LogradouroModel> lougradouros = new List<LogradouroModel>();
            foreach (var elem in LougradourosAtivos)
            {
                var lista = new LogradouroModel
                {
                    Id = elem.Id,
                    CEP = elem.CEP,
                    Rua = elem.Rua,
                    Cidade = elem.Cidade,
                    Bairro = elem.Bairro,
                    Estado = elem.Estado,
                    Numero = elem.Numero,
                    Complemento = elem.Complemento,
                    IdCliente = elem.IdCliente
                };
                lougradouros.Add(lista);
            }
            return lougradouros.ToList();
        }
        //public async Task<Logradouro> BuscarLogradouroNome(string nome)
        //{
        //    var lougradouros = _logradouroRepository.Find(c => c.NomeLogradouro == nome).FirstOrDefault();

        //    return lougradouros;
        //}
    }
}
