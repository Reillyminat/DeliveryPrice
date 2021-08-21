using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class TestData
    {
        public Suppliers suppliers { get; set; }

        public void FillData()
        {
            suppliers = new Suppliers() { new Supplier() {
                Name = "Rozetka",
                Region = "Kyiv",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 10,
                        ProductTypeId = Categories.Washer,
                        ProductId = 1, Name = "Washer3000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 12,
                        HeightInMeters = 100, WidthInMeters = 50, DepthInMeters = 40
                    },
                    new Product() {
                        Amount = 5,
                        ProductTypeId = Categories.Washer,
                        ProductId = 2, Name = "Washer2000",
                        Price = 200,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 6,
                        HeightInMeters= 110, WidthInMeters = 44, DepthInMeters = 40
                    },
                    new Product() {
                        Amount = 7,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 3, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Korea",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 200, WidthInMeters = 80, DepthInMeters = 50
                    },
                    new Product() {
                        Amount = 12,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 4, Name = "Refrigerator7500",
                        Price = 700,
                        ProducingCountry = "Germany",
                        GuaranteeInMonths = 24,
                        HeightInMeters = 150, WidthInMeters = 80, DepthInMeters = 60
                    },
                    new Product() {
                        Amount = 20,
                        ProductTypeId = Categories.KitchenStove,
                        ProductId = 5, Name = "KitchenStove3600",
                        Price = 250,
                        ProducingCountry = "Belarus",
                        GuaranteeInMonths = 12,
                        HeightInMeters = 100, WidthInMeters = 70, DepthInMeters = 50
                    }
                }
            }, new Supplier() {
                Name = "Foxtrot",
                Region = "Dnipro",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 6,
                        ProductTypeId = Categories.Washer,
                        ProductId = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        HeightInMeters = 100, WidthInMeters = 50, DepthInMeters = 40
                    },
                    new Product() {
                        Amount = 5,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 190, WidthInMeters = 70, DepthInMeters = 65
                    },
                    new Product() {
                        Amount = 5,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 3, Name = "Refrigerator7000",
                        Price = 400,
                        ProducingCountry = "Russia",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 180, WidthInMeters = 75, DepthInMeters = 55
                    }
                }
            }, new Supplier() {
                Name = "Comfy",
                Region = "Kharkiv",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 10,
                        ProductTypeId = Categories.Washer,
                        ProductId = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        HeightInMeters = 100, WidthInMeters = 50, DepthInMeters = 40
                    },
                    new Product() {
                        Amount = 12,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 2, Name = "Refrigerator9000",
                        Price = 600,
                        ProducingCountry = "Japan",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 137, WidthInMeters = 76, DepthInMeters = 50
                    },
                    new Product() {
                        Amount = 3,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 3, Name = "Refrigerator9000",
                        Price = 500,
                        ProducingCountry = "Germany",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 200, WidthInMeters = 80, DepthInMeters = 50
                    }
                }
            }, new Supplier() {
                Name = "Eldorado",
                Region = "Dnipro",
                Stock = new List<Product>() {
                    new Product() {
                        Amount = 11,
                        ProductTypeId = Categories.Washer,
                        ProductId = 1, Name = "Washer2000",
                        Price = 300,
                        ProducingCountry = "China",
                        GuaranteeInMonths = 18,
                        HeightInMeters = 100,WidthInMeters = 50, DepthInMeters = 40
                    },
                    new Product() {
                        Amount = 8,
                        ProductTypeId = Categories.Washer,
                        ProductId = 2, Name = "Washer5555",
                        Price = 600,
                        ProducingCountry = "Japan",
                        GuaranteeInMonths = 6,
                        HeightInMeters = 200, WidthInMeters = 80, DepthInMeters = 50
                    },
                    new Product() {
                        Amount = 6,
                        ProductTypeId = Categories.Refrigerator,
                        ProductId = 3, Name = "Refrigerator9000",
                        Price = 700,
                        ProducingCountry = "Ukraine",
                        GuaranteeInMonths = 0,
                        HeightInMeters = 180, WidthInMeters = 80, DepthInMeters = 50
                    },
                    new Product() {
                        Amount = 19,
                        ProductTypeId = Categories.KitchenStove,
                        ProductId = 4, Name = "KitchenStove3456",
                        Price = 600,
                        ProducingCountry = "Belarus",
                        GuaranteeInMonths = 12,
                        HeightInMeters= 130, WidthInMeters = 70, DepthInMeters = 55
                    }
                }
            }
            };
        }
    }
}
