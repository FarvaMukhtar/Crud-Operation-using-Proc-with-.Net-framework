using lstoneCrud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace lstoneCrud.Service
{
    public class customerDAL
    {
        public SqlConnection conn = new SqlConnection("Data Source=192.168.0.201;Initial Catalog=farvaDb;User ID=xprt;Password=xprt");


        public List<customermodel> GetCustomers()
        {

                DataTable ds;
                SqlCommand cmd = new SqlCommand("customersDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);
                List<customermodel> list = new List<customermodel>();
                foreach(DataRow dr in ds.Rows)
            {
                list.Add(new customermodel
                {
                    id = Convert.ToInt32(dr["CustomerID"]),
                    name = dr["CustomerName"].ToString(),
                    salary = dr["Salary"].ToString(),
                    email = dr["Email"].ToString(),
                    phoneno = dr["PhoneNo"].ToString(),
                    address = dr["Address"].ToString(),

                });
                conn.Close();
            }
            return list;
        }


        public bool InsertCustomer(customermodel customer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_customer_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customer.id);
                cmd.Parameters.AddWithValue("@CustomerName", customer.name);
                cmd.Parameters.AddWithValue("@Salary", customer.salary);
                cmd.Parameters.AddWithValue("@Email", customer.email);
                cmd.Parameters.AddWithValue("@PhoneNo", customer.phoneno);
                cmd.Parameters.AddWithValue("@Address", customer.address);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool UpdateCustomer(customermodel customer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_customer_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customer.id);
                cmd.Parameters.AddWithValue("@CustomerName", customer.name);
                cmd.Parameters.AddWithValue("@Salary", customer.salary);
                cmd.Parameters.AddWithValue("@Email", customer.email);
                cmd.Parameters.AddWithValue("@PhoneNo", customer.phoneno);
                cmd.Parameters.AddWithValue("@Address", customer.address);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public int DeleteCustomer(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_customer_delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", id);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}