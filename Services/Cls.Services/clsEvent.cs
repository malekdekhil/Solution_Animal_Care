using DAO.Services;
using Domains;
using Services.UnitOfWorkManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Cls.Services
{
    public class clsEvent: IEvent
    {
       private readonly IUnitOfWork unitOfWork;

        public clsEvent(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await unitOfWork.Events.GetAllAsync();
        }

        public async ValueTask<Event> GetEventByIdAsync(int id)
        {
            return await unitOfWork.Events.GetByIdAsync(id);
        }

        public async Task<Event> RemoveEvent(Event delEvent)
        {
                unitOfWork.Events.Remove(delEvent);
            await  unitOfWork.CommitAsync();
            return delEvent;
        }

        public async Task<Event> CreateEventAsync(Event CreateEvent)
        {
              await unitOfWork.Events.AddAsync(CreateEvent);
            await unitOfWork.CommitAsync();
            return CreateEvent;


        }

        public async Task UpdateEventAsync(Event currentEvent, Event newEvent)
        {
            currentEvent.DateEvent = newEvent.DateEvent;
            currentEvent.Status = newEvent.Status;
            currentEvent.UserId_FK = newEvent.UserId_FK;
         
            await unitOfWork.CommitAsync();
        }


     
    }
}
