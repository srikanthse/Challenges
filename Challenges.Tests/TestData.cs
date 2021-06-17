using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenges.API.Request;
using Challenges.Application.Domain;

namespace Challenges.Tests
{
    public static class TestData
    {
        internal const string TestProduct1 = "Test Product A";
        internal const string TestProduct2 = "Test Product B";
        internal const decimal LowestPrice = 100;
        internal const decimal HighestPrice = 200;
        internal const decimal TrolleyProductPrice = 50;
        internal const long TrolleySpecialQuantity = 50;
        internal const decimal TrolleySpecialPrice = 10;

        internal static async Task<IEnumerable<Product>> GetTestProducts()
        {
            var testProducts = new List<Product>
            {
                new Product
                {
                    Name = TestProduct1,
                    Quantity = 0,
                    Price = LowestPrice
                },
                new Product
                {
                    Name = TestProduct2,
                    Quantity = 0,
                    Price = HighestPrice
                },
            }.AsEnumerable();

            return await Task.FromResult(testProducts);
        }
        
        internal static async Task<IEnumerable<ShopperHistory>> GetTestShopperHistory()
        {
            var testShopperHistories = new List<ShopperHistory>
            {
                new ShopperHistory
                {
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = TestProduct1,
                            Quantity = 1,
                            Price = 100
                        },
                        new Product
                        {
                            Name = TestProduct2,
                            Quantity = 10,
                            Price = 1000
                        }
                    }
                },
                new ShopperHistory
                {
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = TestProduct1,
                            Quantity = 1,
                            Price = 100
                        },
                        new Product
                        {
                            Name = TestProduct2,
                            Quantity = 100,
                            Price = 10000
                        }
                    }
                },
            }.AsEnumerable();

            return await Task.FromResult(testShopperHistories);
        }

        internal static async Task<TrolleyTotalRequest> GetTestTrolleyTotalRequest()
        {
            var testTrolleyTotalRequest = new TrolleyTotalRequest
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = TestProduct1,
                        Price = TrolleyProductPrice,
                    }
                },
                Specials = new List<Special>
                {
                    new Special
                    {
                        Quantities = new List<Product>
                        {
                            new Product
                            {
                                Name = TestProduct1,
                                Quantity = TrolleySpecialQuantity
                            }
                        },
                        Total = TrolleySpecialPrice
                    }
                },
                Quantities = new List<Product>
                {
                    new Product
                    {
                        Name = TestProduct1,
                        Quantity = TrolleySpecialQuantity
                    }
                }
            };

            return await Task.FromResult(testTrolleyTotalRequest);
        }

    }
}
