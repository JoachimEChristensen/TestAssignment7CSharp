using System;
using System.Data.SqlClient;

namespace Assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dataSource = new SqlConnection();

            dataSource.ConnectionString= "Data Source=mysql://localhost/dependency?useSSL=false;" +
            "User id=root;" +
            "Password = root;";

            BankMapper bm = new BankMapper();
            bm.setDataSource(dataSource);

            bm.createAccount(new Account(10, 55.55));
            bm.createCreditCard(new CreditCard(10, new Account(10, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Console.Write(bm.getAccount(10).balance);
        }
    }
}
