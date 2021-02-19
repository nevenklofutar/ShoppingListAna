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

        public UnitOfWork(IGroupRepository groupRepository, IItemRepository itemRepository)
        {
            Groups = groupRepository;
            Items = itemRepository;
        }
    }
}
