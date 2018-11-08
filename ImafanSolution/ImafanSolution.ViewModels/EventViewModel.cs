using ImafanSolution.Data;
using ImafanSolution.Models;
using System;
using System.Linq;

namespace ImafanSolution.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(string eventKey)
        {
            using (EventsContext context = new EventsContext())
            {
                this.Event = context.Events.SingleOrDefault(e => e.EventKey == eventKey);
            }
        }

        public Event Event { get; set; }
    }
}