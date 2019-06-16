using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Xunit;

namespace Assignment7
{
    class TestMain
    {

        SqlConnection dataSource = new SqlConnection();
        BankMapper bm = new BankMapper();

        public TestMain()
        {
            dataSource.ConnectionString = "Data Source=mysql://localhost/dependency?useSSL=false;" +
            "User id=root;" +
            "Password = root;";
            bm.setDataSource(dataSource);
        }

        public void One()
        {
            bm.createAccount(new Account(11, 55.55));
            CreditCard cc = bm.createCreditCard(new CreditCard(11, new Account(11, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Assert.Equal(cc, bm.getCreditCard(11));
        }


        public void Two()
        {
            bm.createAccount(new Account(12, 55.55));
            CreditCard cc = bm.createCreditCard(new CreditCard(12, new Account(12, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Assert.False(cc == bm.getCreditCard(11));
        }


        public void Three()
        {
            bm.createAccount(new Account(13, 55.55));
            CreditCard cc = bm.createCreditCard(new CreditCard(13, new Account(13, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Assert.True(bm.getAccounts().Count == 13);
        }


        public void Four()
        {
            bm.createAccount(new Account(14, 55.55));
            CreditCard cc = bm.createCreditCard(new CreditCard(14, new Account(14, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Assert.False(bm.getCreditCards().Count == 0);
        }


        public void Five()
        {
            bm.createAccount(new Account(15, 55.55));
            CreditCard cc = bm.createCreditCard(new CreditCard(15, new Account(15, 55.55), "1996-9-2 00:00:00", 2222, 0, false));
            Assert.NotSame(bm.getCreditCards(), bm.getAccounts());
        }
    }
}
