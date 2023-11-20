using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class MeetingSponsor
    {

        public Meeting Meeting { get; set; }
        public int IdMeeting { get; set; }
        public Sponsor Sponsor { get; set; }
        public string IdSponsor { get; set; }



        
    }

}
