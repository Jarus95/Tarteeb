using Microsoft.EntityFrameworkCore;
using Tarteeb.Models.Tasks;

namespace Tarteeb.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Models.Tasks.Task> Tasks { get; set; }
    }
}
