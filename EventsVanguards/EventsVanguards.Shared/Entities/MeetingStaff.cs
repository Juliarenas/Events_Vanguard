using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class MeetingStaff
    {

        public Meeting Meeting { get; set; }
        public int IdMeeting { get; set; }
        public EventStaff EventStaff { get; set; }
        public string IdEventStaff { get; set; }


    }
}
