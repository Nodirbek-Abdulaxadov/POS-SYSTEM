using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IClientInterface
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(Guid clientd);
        Task<Client> AddClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid clientId);
    }
}
