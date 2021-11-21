using System;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Client
{
    public class Class1
    {
        static void Main(string[] args)
        {

            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:60173");
            var instructrors = rest.Get<Instructor>("Instructor");
            ;
        }
    }
}
