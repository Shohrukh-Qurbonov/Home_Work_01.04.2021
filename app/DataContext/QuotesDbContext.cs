using Microsoft.EntityFrameworkCore;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataContext
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected QuotesDbContext()
        {
        }
        public DbSet<Quotes> Quotes{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>().HasData
                (
                new Models.Quotes()
                {
                    Id = 1,
                    Text = "Стремитесь не к успеху, а к ценностям, которые он дает.",
                    Author = "Альберт Эйнштейн",
                    InsertDate = DateTime.Now.Date,
                },

                new Quotes()
                {
                    Id = 2,
                    Text = "Своим успехом я обязана тому, что никогда не оправдывалась и не принимала оправданий от других.",
                    Author = "Флоренс Найтингейл",
                    InsertDate = DateTime.Now.Date,
                },

                new Quotes()
                {
                    Id = 3,
                    Text = "Сложнее всего начать действовать, все остальное зависит только от упорства.",
                    Author = "Амелия Эрхарт",
                    InsertDate = DateTime.Now.Date,
                },

                new Quotes()
                {
                    Id = 4,
                    Text = "Надо любить жизнь больше, чем смысл жизни.",
                    Author = "Федор Достоевский",
                    InsertDate = DateTime.Now.Date,
                },

                new Quotes()
                {
                    Id = 5,
                    Text = "Логика может привести Вас от пункта А к пункту Б, а воображение — куда угодно.",
                    Author ="Альберт Эйнштейн",
                    InsertDate = DateTime.Now.Date,
                },
                new Quotes()
                {
                    Id = 6,
                    Text = "Начинать всегда стоит с того, что сеет сомнения.",
                    Author = "Борис Стругацкий",
                    InsertDate = DateTime.Now.Date,
                },
                 new Quotes()
                {
                    Id = 7,
                    Text = "80% успеха - это появиться в нужном месте в нужное время.",
                    Author = "Вуди Аллен",
                    InsertDate = DateTime.Now.Date,
                },
                 new Quotes()
                {
                    Id = 8,
                    Text = "Ваше время ограничено, не тратьте его, живя чужой жизнью.",
                    Author = "Стив Джобс",
                    InsertDate = DateTime.Now.Date,
                }
                );
        }

    }
}