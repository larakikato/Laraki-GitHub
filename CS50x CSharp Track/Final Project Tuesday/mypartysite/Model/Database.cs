using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace mypartysite.Model
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bitmap> Bitmaps { get; set; }
        public DbSet<Event> Events { get; set; }
    }

    public class User
    {
        public User(string n, string p, string e)
        {
        
            this.UserName = n;
            this.Password = p;
            this.email = e;
            this.securityLevel = "user";

        }

        public User(string n, string p)
        {
            this.UserName = n;
            this.Password = p;
        }

        public User()
        {
            
        }

        public int UserId { get; set; }

        public string securityLevel { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public List<Event> myEvents { get; set; }
    }

    public class Bitmap
    {
        public int BitmapId { get; set; }
        public int EventReference { get; set; }
        public string BitsFileReference { get; set; }
        public int Chairs { get; set; }
        public int Tables { get; set; }
        public int Stages { get; set; }
        public int Other { get; set; }
    }

    public class Event
    {
        public Event ( string n, string d, string vn, string va, string desc, string c, string nog, string es, string ea, string ev, string cr)
        {
            this.Name = n;
            this.date = d;
            
            this.place = new EventObjects.venue (va, vn);

            this.Description = desc;
            this.Comments = c;
            this.numOfGuest = nog;
            this.eventStage = es;
            this.eventAudio = ea;
            this.eventVideo = ev;
            int temp = 0;
            Int32.TryParse(cr, out temp);
            this.CustomerReference =  temp;

            this.AcceptedQ = "Awaiting Approval";

        }

        public Event()
        {

        }
        //user submittance members
        public int EventId { get; set; }
        public string Name { get; set; }
        public string date { get; set; }
        public EventObjects.venue place { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public Bitmap FloorPlan { get; set; }
        public string numOfGuest { get; set;}
        public string eventStage {get; set;}
        public string eventAudio {get; set;}
        public string eventVideo {get; set;}



        //administrative members
        public decimal Price { get; set; }
        public string AcceptedQ { get; set; } 
        public int CustomerReference { get; set; }
    }
}