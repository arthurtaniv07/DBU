using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using test.BLL;
using test.DAL;
using test.Model;
using System.Data;

namespace test.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bll = new Table_1BLL();
            Table_1 t = new Table_1();
            t.Iden = 1;
            t.S1 = 2;
            t.S2 = 4;
            t.UserID = "wq";
            t.ID = 123;
            t.ID = bll.Add(t);
            Console.WriteLine(t.ID);
            Console.WriteLine(t.SSum);
            t.ID = 23;
            var s = bll.Update(t);
            Console.WriteLine("更新成功："+s);
            Console.ReadKey();
        }
    }
}
