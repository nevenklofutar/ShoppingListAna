using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitOfWork
    {
        IGroupRepository Groups { get; }
        IItemRepository Items { get; }
        IAuthRepository Auth { get; }
    }
}
