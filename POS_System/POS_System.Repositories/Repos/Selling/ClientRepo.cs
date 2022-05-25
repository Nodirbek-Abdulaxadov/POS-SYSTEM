using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Selling
{
    public class ClientRepo : IClientInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Client> AddClientAsync(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return Task.FromResult(client);
        }

        public Task DeleteClientAsync(Guid clientId)
        {
            _dbContext.Clients.Remove(_dbContext.Clients.FirstOrDefault(p => p.Id == clientId));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<Client> GetClientAsync(Guid clientId) =>
            _dbContext.Clients.FirstOrDefaultAsync(p => p.Id == clientId);

        public Task<PagedList<Client>> GetClients(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Client>.ToPagedList(_dbContext.Clients.OrderBy(c => c.FullName), parameters.PageNumber, parameters.PageSize));
        }

        public Task<List<Client>> GetClientsAsync() =>

           Task.FromResult(_dbContext.Clients.OrderBy(c => c.FullName).ToList());




        public Task<List<Client>> GetHasLoanClientsAsync()
        {
            return Task.FromResult(_dbContext.Clients
                .Where(c => c.HasLoan == true).ToList());
        }

        public Task<bool> IsNameExist(string Name)
        {
            return Task.FromResult(_dbContext.Clients.Any(c => c.FullName == Name));
        }

        public Task<Client> UpdateClientAsync(Client client)
        {
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            return Task.FromResult(client);
        }
    }
}
