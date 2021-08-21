using DeliveryServiceModel;
using System.Collections.Generic;

namespace LINQTasks
{
    public class TestData
    {
        public Suppliers suppliers { get; set; }

        public void FillData()
        {
            suppliers = new Suppliers() { new Supplier() {
                Name = "Rozetka",
                Region = "Kyiv",
                Stock = new List<Appliance>() {
                    new Appliance() {
                        Amount = 10,
                        Type = Categories.Washer,
                        Id = 1, Name = "Washer3000",
                        Price = 300,
                        ProducingCountry = "China",
                        Guarantee = 12,
                        Dimensions = new Dimensions() { Height = 100, Width = 50, Length = 40 }
                    },
                    new Appliance() {
                        Amount = 5,
                        Type = Categories.Washer,
                        Id = 2, Name = "Washer2000",
                        Price = 200,
                        ProducingCountry = "China",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 110, Width = 44, Length = 40 }
                    },
                    new Appliance() {
                        Amount = 7,
                        Type = Categories.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Korea",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 200, Width = 80, Length = 50 }
                    },
                    new Appliance() {
                        Amount = 12,
                        Type = Categories.Refrigerator,
                        Id = 4, Name = "Refrigerator7500",
                        Price = 700,
                        ProducingCountry = "Germany",
                        Guarantee = 24,
                        Dimensions = new Dimensions() { Height = 150, Width = 80, Length = 60 }
                    },
                    new Appliance() {
                        Amount = 20,
                        Type = Categories.KitchenStove,
                        Id = 5, Name = "KitchenStove3600",
                        Price = 250,
                        ProducingCountry = "Belarus",
                        Guarantee = 12,
                        Dimensions = new Dimensions() { Height = 100, Width = 70, Length = 50 }
                    }
                }
            }, new Supplier() {
                Name = "Foxtrot",
                Region = "Dnipro",
                Stock = new List<Appliance>() {
                    new Appliance() {
                        Amount = 6,
                        Type = Categories.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        Guarantee = 18,
                        Dimensions = new Dimensions() { Height = 100, Width = 50, Length = 40 }
                    },
                    new Appliance() {
                        Amount = 5,
                        Type = Categories.Refrigerator,
                        Id = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "China",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 190, Width = 70, Length = 65 }
                    },
                    new Appliance() {
                        Amount = 5,
                        Type = Categories.Refrigerator,
                        Id = 3, Name = "Refrigerator7000",
                        Price = 400,
                        ProducingCountry = "Russia",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 180, Width = 75, Length = 55 }
                    }
                }
            }, new Supplier() {
                Name = "Comfy",
                Region = "Kharkiv",
                Stock = new List<Appliance>() {
                    new Appliance() {
                        Amount = 10,
                        Type = Categories.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        Guarantee = 18,
                        Dimensions = new Dimensions() { Height = 100, Width = 50, Length = 40 }
                    },
                    new Appliance() {
                        Amount = 12,
                        Type = Categories.Refrigerator,
                        Id = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Japan",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 137, Width = 76, Length = 50 }
                    },
                    new Appliance() {
                        Amount = 3,
                        Type = Categories.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 500,
                        ProducingCountry = "Germany",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 200, Width = 80, Length = 50 }
                    }
                }
            }, new Supplier() {
                Name = "Eldorado",
                Region = "Dnipro",
                Stock = new List<Appliance>() {
                    new Appliance() {
                        Amount = 11,
                        Type = Categories.Washer,
                        Id = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        Guarantee = 18,
                        Dimensions = new Dimensions() { Height = 100, Width = 50, Length = 40 }
                    },
                    new Appliance() {
                        Amount = 8,
                        Type = Categories.Washer,
                        Id = 2, Name = "Washer5555",
                        Price = 600,
                        ProducingCountry = "Japan",
                        Guarantee = 6,
                        Dimensions = new Dimensions() { Height = 200, Width = 80, Length = 50 }
                    },
                    new Appliance() {
                        Amount = 6,
                        Type = Categories.Refrigerator,
                        Id = 3, Name = "Refrigerator9000",
                        Price = 700,
                        ProducingCountry = "Ukraine",
                        Guarantee = 0,
                        Dimensions = new Dimensions() { Height = 180, Width = 80, Length = 50 }
                    },
                    new Appliance() {
                        Amount = 19,
                        Type = Categories.KitchenStove,
                        Id = 4, Name = "KitchenStove3456",
                        Price = 600,
                        ProducingCountry = "Belarus",
                        Guarantee = 12,
                        Dimensions = new Dimensions() { Height = 130, Width = 70, Length = 55 }
                    }
                }
            }
            };
        }
    }
}
