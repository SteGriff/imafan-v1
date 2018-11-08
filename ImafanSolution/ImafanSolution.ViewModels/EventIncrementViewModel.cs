using ImafanSolution.Data;
using ImafanSolution.Models;
using System;
using System.Linq;

namespace ImafanSolution.ViewModels
{
    public class EventIncrementViewModel
    {
        public static void IncrementEvent(int eventId)
        {
            using (EventsContext context = new EventsContext())
            {
                Event eventItem = context.Events.Single(e => e.Id == eventId);
                eventItem.RegistrationCount++;
                context.SaveChanges();
            }
        }
    }
}