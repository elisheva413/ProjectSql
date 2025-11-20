using ProjectSql;
using System;



namespace ProjectSql
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string connection_string = "Data Source = srv2\\pupils; Initial Catalog = Store_215962135; Integrated Security = True; Trust Server Certificate=True";
            DataAccess da = new DataAccess();
            da.insertData(connection_string);
            da.PrintDataOnScreen(connection_string);

        }

    }
}
