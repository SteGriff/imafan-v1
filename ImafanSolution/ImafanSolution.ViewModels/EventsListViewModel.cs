using ImafanSolution.Data;
using ImafanSolution.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImafanSolution.ViewModels
{
    public class EventsListViewModel
    {
        public EventsListViewModel()
        {
            using (EventsContext context = new EventsContext())
            {
                this.Events = context.Events.OrderBy(e => e.StartTime).ToList();
            }
        }

        public List<Event> Events { get; set; }
    }
}