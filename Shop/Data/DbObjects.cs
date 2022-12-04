using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(IApplicationBuilder app)
        {
            //AppDbContext context;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(GetCategories.Select(c => c.Value));
                }

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(
                        new Car
                        {
                            Name = "Tesla Model S",
                            ShortDesc = "Быстрый автомобиль",
                            LongDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                            Img = "/img/2019_Tesla_Model_3_Performance_AWD_Front.jpg",
                            Price = 45000,
                            IsFavourite = true,
                            Available = true,
                            Category = GetCategories["Электромобили"]
                        },
                        new Car
                        {
                            Name = "Ford Fiesta",
                            ShortDesc = "Тихий и спокойный",
                            LongDesc = "Удобный автомобиль для городской жизни",
                            Img = "/img/Ford_Fiesta_ST_2018_01-1068x712.jpg",
                            Price = 11000,
                            IsFavourite = true,
                            Available = true,
                            Category = GetCategories["Классические автомобили"]
                        },
                        new Car
                        {
                            Name = "BMW M3",
                            ShortDesc = "Дерзкий и стильный",
                            LongDesc = "Удобный автомобиль для городской жизни",
                            Img = "/img/2023-BMW-M3-Touring-49_1.jpg",
                            Price = 65000,
                            IsFavourite = true,
                            Available = true,
                            Category = GetCategories["Классические автомобили"]
                        },
                        new Car
                        {
                            Name = "Mercedes C class",
                            ShortDesc = "Уютный и большой",
                            LongDesc = "Удобный автомобиль для городской жизни",
                            Img = "/img/mercedes-c-klasse-limousine-2021_large.jpg",
                            Price = 40000,
                            IsFavourite = false,
                            Available = false,
                            Category = GetCategories["Классические автомобили"]
                        },
                        new Car
                        {
                            Name = "Nissan Leaf",
                            ShortDesc = "Бесшумный и экономичный",
                            LongDesc = "Удобный автомобиль для городской жизни",
                            Img = "/img/nissanleaf_2018.jpg",
                            Price = 14000,
                            IsFavourite = true,
                            Available = true,
                            Category = GetCategories["Электромобили"]
                        }
                    );
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> GetCategories
        {
            get
            {
                if (category == null)
                {
                    var List = new Category[] {
                        new Category { categoryName = "Электромобили", desc = "Современный вид транспорта" },
                        new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутренного сгорания" }
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category el in List)
                    {
                        category.Add(el.categoryName, el);
                    }

                }

                return category;
            } 
        }
    }
}
