using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampathNarayananAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BursaryApplication.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.responses.Any())
            {
                context.responses.AddRange(
                new FormResponse
                {
                    Name = "John",
                    Email = "john@gmail.com",
                    Phone = "4372231777",
                    IsInternationalStudent = false
                },

                new FormResponse
                {
                    Name = "Mark",
                    Email = "mark@gmail.com",
                    Phone = "4372231763",
                    IsInternationalStudent = false
                },

                 new FormResponse
                 {
                     Name = "Molly",
                     Email = "molly@gmail.com",
                     Phone = "4371131666",
                     IsInternationalStudent = false
                 },

                new FormResponse
                {
                    Name = "Kylie",
                    Email = "kylie@yahoo.com",
                    Phone = "1234567891",
                    IsInternationalStudent = false
                },

                new FormResponse
                {
                    Name = "Gon",
                    Email = "gon@gmail.com",
                    Phone = "4372231777",
                    IsInternationalStudent = false
                },

                 new FormResponse
                 {
                     Name = "Bobby",
                     Email = "bobby@yahoo.com",
                     Phone = "4351239875",
                     IsInternationalStudent = false
                 },

                new FormResponse
                {
                    Name = "Monty",
                    Email = "monty@gmail.com",
                    Phone = "4372231444",
                    IsInternationalStudent = false
                },

                new FormResponse
                {
                    Name = "Makise",
                    Email = "kurisu@gmail.com",
                    Phone = "9876512343",
                    IsInternationalStudent = false
                },

                 new FormResponse
                 {
                     Name = "kelly",
                     Email = "kelly@gmail.com",
                     Phone = "9872348763",
                     IsInternationalStudent = false
                 }
                );
                context.SaveChanges();
            }
        }
    }
}
