using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGroupRepository Groups { get; }
        public IItemRepository Items { get; }

        public IAuthRepository Auth { get; }

        public UnitOfWork(IGroupRepository groupRepository, IItemRepository itemRepository, IAuthRepository authRepository)
        {
            Groups = groupRepository;
            Items = itemRepository;
            Auth = authRepository;
        }
    }
}
