using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Assignment7
{
    class BankMapper
    {

        SqlConnection dataSource;
        SqlConnection conn;
        SqlCommand stmt;

        public BankMapper()
        {
        }

        public BankMapper(SqlConnection dataSource)
        {
            this.dataSource = dataSource;
        }

        public void setDataSource(SqlConnection dataSource)
        {
            this.dataSource = dataSource;
        }

        public CreditCard createCreditCard(CreditCard creditCard)
        {
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "Insert into creditcard VALUES (" + creditCard.id + ", " + creditCard.account.id + ", '" + creditCard.date + "', '" + creditCard.pinCode + "', " + creditCard.wrongPinCodeAttempts + ", " + creditCard.block + ");";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                stmt.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return creditCard;
        }

        public CreditCard updateCreditCard(CreditCard creditCard)
        {
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "Update creditcard set account_id = " + creditCard.account.id + ", last_used = " + creditCard.date + ", pin_code = '" + creditCard.pinCode + "', wrong_pin_code_attempts = " + creditCard.wrongPinCodeAttempts + ", blocked = " + creditCard.block + " where id = " + creditCard.id + ";";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                stmt.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return creditCard;
        }

        public CreditCard getCreditCard(int id)
        {
            CreditCard card = new CreditCard();
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "select * from creditcard where id = " + id + ";";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                SqlDataReader rs = stmt.ExecuteReader();
                while (rs.Read())
                {
                    card.id = Int32.Parse(rs["id"].ToString());
                    card.account = getAccount(Int32.Parse(rs["account_id"].ToString()));
                    card.date = rs["last_used"].ToString();
                    card.pinCode = Int32.Parse(rs["pin_code"].ToString());
                    card.wrongPinCodeAttempts = Int32.Parse(rs["wrong_pin_code_attempts"].ToString());
                    card.block = Boolean.Parse(rs["blocked"].ToString());
                }
                rs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return card;
        }

        public List<CreditCard> getCreditCards()
        {
            List<CreditCard> list = new List<CreditCard>();
            CreditCard card = new CreditCard();
            String query = "select * from creditcard;";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                SqlDataReader rs = stmt.ExecuteReader();
                while (rs.Read())
                {
                    card.id = Int32.Parse(rs["id"].ToString());
                    card.account = getAccount(Int32.Parse(rs["account_id"].ToString()));
                    card.date = rs["last_used"].ToString();
                    card.pinCode = Int32.Parse(rs["pin_code"].ToString());
                    card.wrongPinCodeAttempts = Int32.Parse(rs["wrong_pin_code_attempts"].ToString());
                    card.block = Boolean.Parse(rs["blocked"].ToString());
                    list.Add(card);
                }
                rs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return list;
        }

        public Account createAccount(Account account)
        {
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "Insert into account VALUES (" + account.id + ", " + account.balance + ");";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                stmt.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return account;
        }

        public Account updateAccount(Account account)
        {
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "update account set balance = " + account.balance + " where id = " + account.id + ";";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                stmt.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return account;
        }

        public Account getAccount(int id)
        {
            Account account = new Account();
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "select * from account where id = " + id + ";";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                SqlDataReader rs = stmt.ExecuteReader();
                while (rs.Read())
                {
                    account.id = Int32.Parse(rs["id"].ToString());
                    account.balance = Double.Parse(rs["balance"].ToString());
                }
                rs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return account;
        }

        public List<Account> getAccounts()
        {
            List<Account> list = new List<Account>();
            Account account = new Account();
            conn = new SqlConnection(dataSource.ConnectionString);
            String query = "select * from account;";
            try
            {
                stmt = new SqlCommand(query, conn);
                stmt.Connection.Open();
                SqlDataReader rs = stmt.ExecuteReader();
                while (rs.Read())
                {
                    account.id = Int32.Parse(rs["id"].ToString());
                    account.balance = Double.Parse(rs["balance"].ToString());
                    list.Add(account);
                }
                rs.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (stmt != null)
                {
                    stmt.Connection.Close();
                }
            }
            return list;
        }
    }
}
