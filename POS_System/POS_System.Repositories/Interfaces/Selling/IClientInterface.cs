<<<<<<< HEAD
﻿using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using POS_System.Domains.Selling;
>>>>>>> b311fa986d7499b34f282e41b2dc5b713b797deb

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IClientInterface
    {
        Task<PagedList<Client>> GetClients(QueryStringParameters parameters);
        Task<List<Client>> GetClientsAsync();
        Task<List<Client>> GetHasLoanClientsAsync();
        Task<Client> GetClientAsync(Guid clientd);
        Task<Client> AddClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid clientId);
    }
}
