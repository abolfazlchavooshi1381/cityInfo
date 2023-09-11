using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() { Id = 1 , Name = "Tehran" , Description = "This Is Tehran" ,
                PointOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 11 ,
                            Name = "Point Of Intrest 11" ,
                            Description = "This Is Point Of Intrest 11"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 12 ,
                            Name = "Point Of Intrest 12" ,
                            Description = "This Is Point Of Intrest 12"
                        },
                    }
                },

                new CityDto() { Id = 2 , Name = "Mashhad", Description = "This Is Mashhad" ,
                PointOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 21 ,
                            Name = "Point Of Intrest 21" ,
                            Description = "This Is Point Of Intrest 21"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 22 ,
                            Name = "Point Of Intrest 22" ,
                            Description = "This Is Point Of Intrest 22"
                        },
                    }
                },

                new CityDto() { Id = 3 , Name = "Shahroud", Description = "This Is Shahroud" ,
                PointOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 31 ,
                            Name = "Point Of Intrest 31" ,
                            Description = "This Is Point Of Intrest 31"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 32 ,
                            Name = "Point Of Intrest 32" ,
                            Description = "This Is Point Of Intrest 32"
                        },
                    }
                },

                new CityDto() { Id = 4 , Name = "Esfehan", Description = "This Is Esfehan" ,
                PointOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 41 ,
                            Name = "Point Of Intrest 41" ,
                            Description = "This Is Point Of Intrest 41"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 42 ,
                            Name = "Point Of Intrest 42" ,
                            Description = "This Is Point Of Intrest 42"
                        },
                    }
                },

                new CityDto() { Id = 5 , Name = "Tanriz", Description = "This Is Tanriz" ,
                PointOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 51 ,
                            Name = "Point Of Intrest 51" ,
                            Description = "This Is Point Of Intrest 51"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 52 ,
                            Name = "Point Of Intrest 52" ,
                            Description = "This Is Point Of Intrest 52"
                        },
                    }
                }
            };
        }
    }
}
