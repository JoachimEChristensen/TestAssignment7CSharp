using System;
using System.Collections.Generic;
using System.Text;
using DbUnit;
using Xunit;
using System.Data.SqlClient;
using DbUnit.Dataset;

namespace Assignment7
{
    public class dbunitTest
    {
        SqlConnection DataSource = new SqlConnection();
        public dbunitTest()
        {

        }
        

        [Fact]
        public void get()
        {
            BankMapper bm = new BankMapper(DtSce());
            CreditCard cc = bm.getCreditCard(3);
            Account a = bm.getAccount(3);

            Assert.True(cc.id == new CreditCard(3, new Account(5, 0.00), "2000-1-30 00:00:00", 1111, 0, false).id);
            Assert.True(a.id == new Account(3, 51324.11).id);
        }

        [Fact]
        public void cannotFind()
        {
            BankMapper bm = new BankMapper(DtSce());

            CreditCard cc = bm.getCreditCard(99);
            Account a = bm.getAccount(99);

            Assert.Equal(0, a.id);
            Assert.Equal(0, a.id);
        }

        private SqlConnection DtSce()
        {
            DataSource.ConnectionString = "Data Source=mysql://localhost/dependency?useSSL=false;" +
                    "User id=root;" +
                    "Password = root;";
            return DataSource;
        }

    }
}