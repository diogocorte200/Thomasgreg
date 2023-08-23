using Thomasgreg.Infra.Context;
using Thomasgreg.Infra.Entity;
using Thomasgreg.Infra.Repositories.Interfaces;

namespace Thomasgreg.Infra.Repositories
{
    public class LogradouroRepository : RepositoryGeneric<Logradouro>, ILogradouroRepository
    {
        private ClientContext _appContext => (ClientContext)_context;

        public LogradouroRepository(ClientContext context) : base(context)
        { }



    }
}
