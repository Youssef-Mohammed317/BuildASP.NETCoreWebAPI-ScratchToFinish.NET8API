using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Infra.Identity.Domian.Interfaces
{
    public interface IAuthUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ITokenRepository TokenRepository { get; }
        Task SaveChangesAsync();
    }
}
