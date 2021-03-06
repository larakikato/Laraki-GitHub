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

        }
        public int UserId { get; set; }
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
        public int Other { get; set; }
    }

    public class Event
    {
        //user submittance members
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public EventObjects.venue place { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public Bitmap FloorPlan { get; set; }

        //administrative members
        public decimal Price { get; set; }
        public bool AcceptedQ { get; set; } 
        public int CustomerReference { get; set; }
    }
}