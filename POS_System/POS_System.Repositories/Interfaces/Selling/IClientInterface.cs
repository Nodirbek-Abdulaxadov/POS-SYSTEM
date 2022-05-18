using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IClientInterface
    {
        Task<List<Client>> GetClientsAsync();
        Task<List<Client>> GetHasLoanClientsAsync();
        Task<Client> GetClientAsync(Guid clientd);
        Task<Client> AddClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid clientId);
    }
}
