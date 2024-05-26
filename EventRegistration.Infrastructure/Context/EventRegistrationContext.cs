using EventRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Infrastructure.Context
{
    public class EventRegistrationContext : DbContext
    {
        public EventRegistrationContext(DbContextOptions<EventRegistrationContext> options)
       : base(options)
        {
        }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventRegister> EventRegister { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>

               entity.HasData(
                            new Events
                            {
                                EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d28"),
                                EventName = "Stargazing Party",
                                EventDescription = "Join us for an enchanting evening under the stars with telescopes and expert guides.",
                                EventImgUrl = "https://images.unsplash.com/photo-1532980210220-1d5b19dec081?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                                MaxSeats = 3
                            },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d29"),
            EventName = "Nature Hike and Picnic",
            EventDescription = "Explore the scenic beauty of the Memorial Park followed by a delightful picnic.",
            EventImgUrl = "https://images.unsplash.com/photo-1525474089639-b5fff4440315?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 30
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d30"),
            EventName = "Board Game Night",
            EventDescription = "Bring your favorite board games for an evening of fun and friendly competition.",
            EventImgUrl = "https://images.unsplash.com/photo-1629760946220-5693ee4c46ac?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 10
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d31"),
            EventName = "Cooking Workshop",
            EventDescription = "Learn to cook delicious meals with our expert chefs in a hands-on workshop.",
            EventImgUrl = "https://images.unsplash.com/photo-1517248135467-4c7edcad34c4",
            MaxSeats = 15
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d32"),
            EventName = "Art and Craft Fair",
            EventDescription = "Discover unique handmade items from local artists and craftspeople.",
            EventImgUrl = "https://plus.unsplash.com/premium_photo-1677130461825-a6af681e401b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 1
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d33"),
            EventName = "Yoga and Meditation Retreat",
            EventDescription = "Relax and rejuvenate with a day of yoga and meditation in a tranquil setting.",
            EventImgUrl = "https://images.unsplash.com/photo-1506748686214-e9df14d4d9d0",
            MaxSeats = 25
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d34"),
            EventName = "Tech Innovation Summit",
            EventDescription = "Join industry leaders to discuss the latest trends and innovations in technology.",
            EventImgUrl = "https://images.unsplash.com/photo-1716436329475-4c55d05383bb?q=80&w=2128&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 100
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d35"),
            EventName = "Wine Tasting Evening",
            EventDescription = "Sample a selection of fine wines from local vineyards.",
            EventImgUrl = "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 30
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d36"),
            EventName = "Coding Bootcamp",
            EventDescription = "Intensive coding bootcamp for beginners and advanced learners.",
            EventImgUrl = "https://images.unsplash.com/photo-1542831371-29b0f74f9713?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 50
        },
        new Events
        {
            EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d37"),
            EventName = "Photography Workshop",
            EventDescription = "Learn the art of photography with hands-on sessions from professionals.",
            EventImgUrl = "https://images.unsplash.com/photo-1471341971476-ae15ff5dd4ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            MaxSeats = 20
        }
        
        
        ));

            modelBuilder.Entity<EventRegister>(entity =>
            {
                entity.HasData(
                    // Registrations for Stargazing Party
                    new EventRegister
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d28") // Stargazing Party
                    },
                    new EventRegister
                    {
                        FirstName = "Emily",
                        LastName = "Clark",
                        Email = "emily.clark@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d28") // Stargazing Party
                    },

                    // Registrations for Nature Hike and Picnic
                    new EventRegister
                    {
                        FirstName = "Alice",
                        LastName = "Johnson",
                        Email = "alice.johnson@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d29") // Nature Hike and Picnic
                    },
                    new EventRegister
                    {
                        FirstName = "Michael",
                        LastName = "Brown",
                        Email = "michael.brown@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d29") // Nature Hike and Picnic
                    },
                    // Add more registrations for Nature Hike and Picnic here...

                    // Registrations for Board Game Night
                    new EventRegister
                    {
                        FirstName = "Sarah",
                        LastName = "Miller",
                        Email = "sarah.miller@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d30") // Board Game Night
                    },
                    new EventRegister
                    {
                        FirstName = "David",
                        LastName = "Wilson",
                        Email = "david.wilson@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d30") // Board Game Night
                    }, 
                    new EventRegister
                    {
                        FirstName = "David",
                        LastName = "Wilson",
                        Email = "david.wilson@example.com",
                        EventId = Guid.Parse("1a0c0d28-7c8f-4f0d-8d28-7c8f4f0d8d32") // Arts and Craft
                    }



                    


                );
            });

        }
    }
}
