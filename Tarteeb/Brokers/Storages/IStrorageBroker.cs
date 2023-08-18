//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Tarteeb.Models.Tasks;
using Task = Tarteeb.Models.Tasks.Task;

namespace Tarteeb.Brokers.Storages
{
    public interface IStorageBroker
    {
        ValueTask<Task> InsertTaskAsync(Task task);
    }
}
