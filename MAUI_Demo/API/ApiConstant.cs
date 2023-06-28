﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo.API
{
    public class ApiConstant
    {
        //public static string BaseApiUrl = "https://dummy.restapiexample.com/"; 
        //public static string GetEmployees = "api/v1/employees";


        public static string BaseApiUrl = "http://fakestoreapi.com/";
        public static string GetProducts = "products";
        public static string DeleteProductById = "products/{0}"; // 0 = id
        public static string ProductDetailsById = "products/{0}"; // 0 = id
        public static string InsertProduct = "products";
    }
}
