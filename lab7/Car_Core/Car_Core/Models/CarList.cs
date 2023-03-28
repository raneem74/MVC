﻿using System.Collections.Generic;

namespace Car_Core.Models
{
    public class CarList :List<Car>
    {

        public static CarList cList = new CarList() {
        new Car { Num = 1, Color = "Red", Model = "SUV", Manfacture = "Toyota" },
        new Car { Num = 2, Color = "Blue", Model = "Coupe", Manfacture = "BMW" },
        new Car { Num = 3, Color = "White", Model = "Sedan", Manfacture = "Honda" } };
    }
}
