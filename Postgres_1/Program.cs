using System;

namespace Postgres_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Transformer();
            x.GetExtentionProperty(1004, TargetTableName.Store, 1000);
           

            Console.ReadLine();
               
        }
    }
}
