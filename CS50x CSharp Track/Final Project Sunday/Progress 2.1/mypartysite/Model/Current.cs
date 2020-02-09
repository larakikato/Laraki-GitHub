using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mypartysite.Model;

namespace mypartysite.Model
{
    public class Current
    {
        public EventObjects.currentEvent initialize () {
        //attendees & staff
        EventObjects.person one = new EventObjects.person("Dylan Perez", "954-217-5555");
        EventObjects.person two = new EventObjects.person("Iroquois Pliskin", "555-999-5555");
        EventObjects.person three = new EventObjects.person("Chandra Nalaar", "474-613-5555");
        EventObjects.person four = new EventObjects.person("Shawna Vayne", "323-813-5555");
        EventObjects.person five = new EventObjects.person("Kato Laraki", "222-213-5655");
        EventObjects.person six = new EventObjects.person("Deckard Cain", "912-313-4555");

        List<EventObjects.person> currAttendees = new List<EventObjects.person>();
        List<EventObjects.person> currStaff = new List<EventObjects.person>();

        currAttendees.Add(two);
        currAttendees.Add(three);
        currAttendees.Add(four);
        currAttendees.Add(five);

        currStaff.Add(one);
        currStaff.Add(six);

        mypartysite.Model.EventObjects.venue Wolfson = new mypartysite.Model.EventObjects.venue("315 NE 2nd Ave, Miami, FL 33132", "The Idea Center - Miami Dade College, Wolfson Campus");

        string currName = "2017 CS50xMiami C# Bash!";
        DateTime currDate = new DateTime(2017, 6, 30, 18, 30, 0);

        string currEventFees = "Free!";

        string currAbout = "This webpage is dedicated to providing updated information about the status of upcoming events being planned by MyPartySite. Here you can find guest lists," +
            " venue location, date, and pricing information, as well as what's still on our list of To-Do's for events currently in the planning phase.";


        string currP1 = "2016: The Ascendancy";
        string currP2 = "2014: Infiltration of Outer Haven";
        string currP3 = "2009: The Cataclysm of Atreia";
        string currP4 = "1997: Sector 7 Collapse";

        List<string> currPE = new List<string>();
        currPE.Add(currP1);
        currPE.Add(currP2);
        currPE.Add(currP3);
        currPE.Add(currP4);

        // to do list
        Dictionary<string, bool> currToDo = new Dictionary<string, bool>();

        currToDo.Add("Book Venue", true);
        currToDo.Add("Hire Entertainment", true);
        currToDo.Add("Send out pre-event promotional literature", true);
        currToDo.Add("Complete floor plan and send to decorators", true);
        currToDo.Add("Deliver confirmation emails for attendees prior to event", false);
        currToDo.Add("Day-Of preparation", false);

        

        mypartysite.Model.EventObjects.currentEvent cs50x2017cbash = new mypartysite.Model.EventObjects.currentEvent(currName, currDate, Wolfson, currEventFees, currAttendees, currStaff, currAbout, currPE, currToDo);

        return cs50x2017cbash;

        }
    }
    
}