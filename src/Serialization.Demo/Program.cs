﻿using System;
using Newtonsoft.Json;

namespace Serialization.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
			DataGenerator.PersonsFaker().FinishWith((f,p)=>{
                 Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
            }).Generate(230);
        }
    }
}
