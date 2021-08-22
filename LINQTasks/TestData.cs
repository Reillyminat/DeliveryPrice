using DeliveryServiceModel;
using System.Collections.Generic;

namespace LINQTasks
{
    public class TestData
    {
        public ICollection<Supplier> suppliers { get; set; }

        public void FillData()
        {
            suppliers = new List<Supplier>() { new Supplier() {
                Name = "Rozetka",
                Region = "Kyiv",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 10,
                        CategoryId = Category.Washer,
                        Id = 1, Name = "Washer3000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 12,
                        DepthInMeters=40,
                        HeightInMeters=100,
                        WidthInMeters=50
                    },
                    new Product() {
                        Amount = 5,
                        CategoryId = Category.Washer,
                        Id = 2, Name = "Washer2000",
                        Price = 200,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 6,
                        WidthInMeters=44,
                        DepthInMeters=40,
                        HeightInMeters=110
                    },
                    new Product() {
                        Amount = 7,
                        CategoryId = Category.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Korea",
                        GuaranteeInMonths = 6,
                        WidthInMeters=80,
                        DepthInMeters=50,
                        HeightInMeters=200
                    },
                    new Product() {
                        Amount = 12,
                        CategoryId = Category.Refrigerator,
                        Id = 4, Name = "Refrigerator7500",
                        Price = 700,
                        ProducingCountry = "Germany",
                        GuaranteeInMonths = 24,
                        WidthInMeters=80,
                        DepthInMeters=60,
                        HeightInMeters=150
                    },
                    new Product() {
                        Amount = 20,
                        CategoryId = Category.KitchenStove,
                        Id = 5, Name = "KitchenStove3600",
                        Price = 250,
                        ProducingCountry = "Belarus",
                        GuaranteeInMonths = 12,
                        WidthInMeters=70,
                        DepthInMeters=50,
                        HeightInMeters=100
                    }
                }
            }, new Supplier() {
                Name = "Foxtrot",
                Region = "Dnipro",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 6,
                        CategoryId = Category.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        WidthInMeters=50,
                        HeightInMeters=100,
                        DepthInMeters=40
                    },
                    new Product() {
                        Amount = 5,
                        CategoryId = Category.Refrigerator,
                        Id = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 6,
                        WidthInMeters=70,
                        DepthInMeters=65,
                        HeightInMeters=190
                    },
                    new Product() {
                        Amount = 5,
                        CategoryId = Category.Refrigerator,
                        Id = 3, Name = "Refrigerator7000",
                        Price = 400,
                        ProducingCountry = "Russia",
                        GuaranteeInMonths = 6,
                        WidthInMeters=75,
                        DepthInMeters=55,
                        HeightInMeters=180
                    }
                }
            }, new Supplier() {
                Name = "Comfy",
                Region = "Kharkiv",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 10,
                        CategoryId = Category.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        WidthInMeters=50,
                        DepthInMeters=40,
                        HeightInMeters=100
                    },
                    new Product() {
                        Amount = 12,
                        CategoryId = Category.Refrigerator,
                        Id = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Japan",
                        GuaranteeInMonths = 6,
                        WidthInMeters=76,
                        DepthInMeters=50,
                        HeightInMeters=137
                    },
                    new Product() {
                        Amount = 3,
                        CategoryId = Category.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 500,
                        ProducingCountry = "Germany",
                        GuaranteeInMonths = 6,
                        WidthInMeters=80,
                        DepthInMeters=50,
                        HeightInMeters=200
                    }
                }
            }, new Supplier() {
                Name = "Eldorado",
                Region = "Dnipro",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 11,
                        CategoryId = Category.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        WidthInMeters=50,
                        DepthInMeters=40,
                        HeightInMeters=100
                    },
                    new Product() {
                        Amount = 8,
                        CategoryId = Category.Washer,
                        Id = 2, Name = "Washer5555",
                        Price = 600,
                        ProducingCountry = "Japan",
                        GuaranteeInMonths = 6,
                        WidthInMeters=80,
                        DepthInMeters=50,
                        HeightInMeters=200
                    },
                    new Product() {
                        Amount = 6,
                        CategoryId = Category.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 700,
                        ProducingCountry = "Ukraine",
                        GuaranteeInMonths = 0,
                        WidthInMeters=80,
                        DepthInMeters=50,
                        HeightInMeters=180
                    },
                    new Product() {
                        Amount = 19,
                        CategoryId = Category.KitchenStove,
                        Id = 4, Name = "KitchenStove3456",
                        Price = 600,
                        ProducingCountry = "Belarus",
                        GuaranteeInMonths = 12,
                        WidthInMeters=70,
                        DepthInMeters=55,
                        HeightInMeters=130
                    }
                }
            }
            };
        }
    }
}
