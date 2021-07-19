using System;
using System.Collections.Generic;
using order_management.common.Models;
using order_management.services.converters;
using Xunit;

namespace order_management.tests.Converters
{
    public class OrderManagementServiceConverter
    {
        #region From common.Models.Order to repository.models.Order

        public class TestData1

        {
            public common.Models.Order Input { get; set; }
            public repository.Models.Order Expected { get; set; }
        }

        public static IEnumerable<object[]> TestDataList1 => new List<object[]>()
        {
            new object[]
            {
                new TestData1()
                {
                    Input = null,
                    Expected = null
                }
            },
            new object[]
            {
                new TestData1()
                {
                    Input = new Order
                    {
                        Id = "123123",
                        DateTime = new DateTime(2021, 01, 01),
                        FIO = "Vasya Pupkin",
                        Description = "test",
                        Cost = 999.99m
                    },
                    Expected = new repository.Models.Order
                    {
                        Id = "123123",
                        DateTime = new DateTime(2021, 01, 01),
                        FIO = "Vasya Pupkin",
                        Description = "test",
                        Cost = 999.99m
                    }
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestDataList1))]
        public void Tests(TestData1 data)
        {
            data.Expected.AssertWith(data.Input.MapToModel());
        }
        
        #endregion

        #region From repository.models.Order to common.Models.Order

        public class TestData2
        {
            public repository.Models.Order Input { get; set; }
            public Order Expect { get; set; }
        }

        public static IEnumerable<object[]> TestDataList2 => new List<object[]>()
        {
            new object[]
            {
                new TestData2()
                {
                    Input = null,
                    Expect = null
                },
            },
            new object[]
            {
                new TestData2()
                {
                    Input = new repository.Models.Order
                    {
                        Id = "123321",
                        DateTime = new DateTime(2021, 02, 02),
                        FIO = "Dmitry Donskoy",
                        Description = "test 2",
                        Cost = 987
                    },
                    Expect = new Order
                    {
                        Id = "123321",
                        DateTime = new DateTime(2021, 02, 02),
                        FIO = "Dmitry Donskoy",
                        Description = "test 2",
                        Cost = 987
                    }
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestDataList2))]
        public void Tests2(TestData2 data)
        {
            data.Expect.AssertWith(data.Input.MapToModel());
        }
        
        #endregion

        #region From IEnumerable<repository.Models.Order> to IEnumerable<common.Models.Order>

        public class TestData3
        {
            public List<repository.Models.Order> Input { get; set; }
            public List<Order> Expected { get; set; }
        }

        public static IEnumerable<object[]> TestDataList3 => new List<object[]>()
        {
            new object[]
            {
                new TestData3()
                {
                    Input = null,
                    Expected= null
                }
            },
            new object[]
            {
                new TestData3()
                {
                    Input = new List<repository.Models.Order>()
                    {
                        new repository.Models.Order
                        {
                            Id = "09131",
                            DateTime = new DateTime(2021, 03, 03),
                            FIO = "Testovyi Test",
                            Description = "test 3",
                            Cost = 1.00m
                        },
                        new repository.Models.Order
                        {
                            Id = "3321",
                            DateTime = new DateTime(2021, 03, 04),
                            FIO = "AAAA BBBB",
                            Description = "test 3",
                            Cost = 1.00m
                        },
                        new repository.Models.Order
                        {
                            Id = "999",
                            DateTime = new DateTime(2021, 03, 05),
                            FIO = null,
                            Description = null,
                            Cost = 0
                        }
                    },
                    Expected = new List<Order>()
                    {
                        new Order
                        {
                            Id = "09131",
                            DateTime = new DateTime(2021, 03, 03),
                            FIO = "Testovyi Test",
                            Description = "test 3",
                            Cost = 1.00m
                        },
                        new Order()
                        {
                            Id = "3321",
                            DateTime = new DateTime(2021, 03, 04),
                            FIO = "AAAA BBBB",
                            Description = "test 3",
                            Cost = 1.00m
                        },
                        new Order()
                        {
                            Id = "999",
                            DateTime = new DateTime(2021, 03, 05),
                            FIO = null,
                            Description = null,
                            Cost = 0
                        }
                    }
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestDataList3))]
        public void Tests3(TestData3 data)
        {
            data.Expected.AssertWith(data.Input.MapToModel());
        }
        
        #endregion
    }
}