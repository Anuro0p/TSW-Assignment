using System;
using System.Data;
using TSWorksDataAccessLayer;
using TSWorksBusinessLayer;

namespace TSWTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLayer BL = new BusinessLayer();
            DataTable dt = new DataTable();
            BL.GetAllAppleData();

            //foreach(DataRow drow in dt.Rows)
            //{
            //    Console.WriteLine((drow["date"]).ToString());
            //}

            Console.WriteLine("Hello World!");
        }
    }
}
