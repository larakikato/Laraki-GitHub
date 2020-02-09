using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mypartysite.Model
{
    public class EventObjects
    {

        public class person {

            public string name { get; set; }

            public string phoneNumber { get; set; }

            public person ( string n, string pn) {

                this.name = n;
                this.phoneNumber = pn;

            }
        }

        public class venue {

            public int ID { get; set; }
            public string address { get; set; }

            public string name { get; set; }

            public decimal feeAdult { get; set; }

            public decimal feeChild { get; set; }

            public venue ( string a, string n)
            {
                this.address = a;
                this.name = n;
            }

        }
        public abstract class Event {

            public string name { get; set; }

            public DateTime date { get; set; }
            
            public venue place { get; set; }

            public string eventFees { get; set; }

            public List<person> attendees { get; set;}

            public List<person> staff { get; set; }
        }

        public class currentEvent : Event {

            public Dictionary<string, bool> ToDoList { get; set; }

            public List<string> pastEvents { get; set; }

            public string about { get; set; }
            
            public currentEvent (string n, DateTime d, venue p, string ef, List<person> a, List<person> s, string ab, List<string> pE, Dictionary<string, bool> tdl) {

                this.ToDoList = tdl;
                this.pastEvents = pE;
                this.about = ab;
                this.date = d;
                this.name = n;
                this.place = p;
                this.eventFees = ef;
                this.attendees = a;
                this.staff = s;

            }
        }
    }
}