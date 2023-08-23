using Thomasgreg.Infra.Context;
using Thomasgreg.Infra.Entity;
using Thomasgreg.Infra.Repositories.Interfaces;

namespace Thomasgreg.Infra.Repositories
{
    public class ClienteRepository : RepositoryGeneric<Cliente>, IClienteRepository
    {
        private ClientContext _appContext => (ClientContext)_context;

        public ClienteRepository(ClientContext context) : base(context)
        { }



    }
}
