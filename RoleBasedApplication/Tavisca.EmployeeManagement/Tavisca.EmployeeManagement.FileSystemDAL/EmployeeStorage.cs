using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ErrorSpace;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Model;
using Newtonsoft.Json;


namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public Model.Employee Save(Model.Employee employee)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //random employee ID
                Random rand = new Random();
                employee.Id = rand.Next(5000).ToString();
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                SqlCommand insertCommand = new SqlCommand("CreateEmp", connection);
                insertCommand.CommandType = CommandType.StoredProcedure;
                insertCommand.Parameters.Add(new SqlParameter("Id", employee.Id));
                insertCommand.Parameters.Add(new SqlParameter("Title", employee.Title));
                insertCommand.Parameters.Add(new SqlParameter("FirstName", employee.FirstName));
                insertCommand.Parameters.Add(new SqlParameter("LastName", employee.LastName));
                insertCommand.Parameters.Add(new SqlParameter("Email", employee.Email));
                insertCommand.Parameters.Add(new SqlParameter("Phone", employee.Phone));
                insertCommand.Parameters.Add(new SqlParameter("DOJ", DateTime.UtcNow));
                insertCommand.Parameters.Add(new SqlParameter("Password", employee.Password));
                insertCommand.Parameters.Add(new SqlParameter("Role", employee.Role));
                connection.Open();
                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
            return employee;
        }

        public Model.Remark AddRemark(string employeeId, Remark remark)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                connection.Open();
                SqlCommand AddRemarkCommand = new SqlCommand("insertEmpRemark", connection);
                AddRemarkCommand.CommandType = CommandType.StoredProcedure;

                if (remark != null)
                {
                    AddRemarkCommand.Parameters.Add(new SqlParameter("@emp_id", employeeId));
                    AddRemarkCommand.Parameters.Add(new SqlParameter("@text", remark.Text));
                    AddRemarkCommand.Parameters.Add(new SqlParameter("@timestamp", DateTime.UtcNow));
                    AddRemarkCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
            return remark;
        }

        public Model.Employee Authenticate(Model.LoginAuthentication employeeDetails)
        {
            Model.Employee employeeData = new Model.Employee();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                connection.Open();
                SqlCommand authCommanad = new SqlCommand("AuthenticateEmp", connection);
                authCommanad.CommandType = CommandType.StoredProcedure;
                authCommanad.Parameters.Add(new SqlParameter("UserId", employeeDetails.EmailId));

                using (SqlDataReader reader = authCommanad.ExecuteReader())
                {
                    if (reader.HasRows == false) throw new System.Exception("Invalid Email");
                    while (reader.Read())
                    {
                        //TODO : remove extra params
                        employeeData.Id = reader[0].ToString();
                        employeeData.Title = reader[1].ToString();
                        employeeData.FirstName = reader[2].ToString();
                        employeeData.LastName = reader[3].ToString();
                        employeeData.Email = reader[4].ToString();
                        employeeData.Phone = reader[5].ToString();
                        employeeData.DOJ = Convert.ToDateTime(reader[6]);
                        employeeData.Password = reader[7].ToString();
                        employeeData.Role = reader[8].ToString();
                    }
                    if (string.Compare(employeeDetails.Password, employeeData.Password) != 0) throw new System.Exception("Invalid Password");
                }
            }
            return employeeData;
        }

        public Model.Employee Get(string employeeId)
        {
            Model.Employee employee = new Model.Employee();
            SqlConnection connection = new SqlConnection();
            using (connection)
            {
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                connection.Open();
                SqlCommand getCommand = new SqlCommand("GetEmp", connection);
                getCommand.CommandType = CommandType.StoredProcedure;
                getCommand.Parameters.Add(new SqlParameter("Id", employeeId));

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee.Id = reader[0].ToString();
                        employee.Title = reader[1].ToString();
                        employee.FirstName = reader[2].ToString();
                        employee.LastName = reader[3].ToString();
                        employee.Email = reader[4].ToString();
                        employee.Phone = reader[5].ToString();
                        employee.DOJ = Convert.ToDateTime(reader[6]);
                    }
                }
            }
            connection.Close();
            //displaying remarks of employee
            //List<Model.Remark> remarkList = new List<Model.Remark>();
            //Model.Remark remark = new Model.Remark();
            //using (SqlConnection connectionRemark = new SqlConnection())
            //{
            //    connectionRemark.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
            //    connectionRemark.Open();
            //    SqlCommand command = new SqlCommand("getEmpRemark", connectionRemark);
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.Add(new SqlParameter("@emp_id", employeeId));
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        remark.Text = reader[1].ToString();
            //        remark.CreateTimeStamp = Convert.ToDateTime(reader[2]);
            //        remarkList.Add(remark);
            //    }
            //    employee.Remarks = remarkList;
            //    reader.Close();
            //}
            //connection.Close();
            return employee;
        }

        public List<Model.Remark> GetRemarks(string employeeId, string pageSize, string pageNumber)
        {
            List<Model.Remark> remarkList = new List<Model.Remark>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                connection.Open();
                //setting remark count -- Jugaad
                Model.Remark remarkcount = new Model.Remark();
                SqlCommand getcount = new SqlCommand("select count(*) from EmpRemarks where emp_Id= @emp_id", connection);
                getcount.Parameters.Add(new SqlParameter("@emp_id", employeeId));

                getcount.CommandType = CommandType.Text;
                var totalRemarks = (Int32)getcount.ExecuteScalar();
                //--------------------------------------------------------
                SqlCommand command = new SqlCommand("getEmpRemark", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@emp_id", employeeId));
                command.Parameters.Add(new SqlParameter("@row_num_start", (Int32.Parse(pageNumber) - 1) * Int32.Parse(pageSize) + 1));
                command.Parameters.Add(new SqlParameter("@row_num_end", (Int32.Parse(pageNumber) * Int32.Parse(pageSize))));
                SqlDataReader remarkReader = command.ExecuteReader();

                while (remarkReader.Read())
                {
                    Model.Remark remark = new Model.Remark();
                    remark.Text = remarkReader[0].ToString();
                    remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[1]);
                    remarkList.Add(remark);
                }
                remarkReader.Close();
                //jugaad
                remarkcount.Text = totalRemarks.ToString();
                remarkcount.CreateTimeStamp = DateTime.UtcNow;
                remarkList.Add(remarkcount);
                //-------------------------------------
            }
            return remarkList;
        }

        public List<Model.Employee> GetAll()
        {
            SqlConnection connection = new SqlConnection();
            List<Model.Employee> emplist = new List<Model.Employee>();

            connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
            connection.Open();
            SqlCommand command = new SqlCommand("getAllValues", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Model.Employee employee = new Model.Employee();
                employee.Id = reader[0].ToString();
                employee.Title = reader[1].ToString();
                employee.FirstName = reader[2].ToString();
                employee.LastName = reader[3].ToString();
                employee.Email = reader[4].ToString();
                employee.Phone = reader[5].ToString();
                employee.DOJ = Convert.ToDateTime(reader[6]); //DateTime.UtcNow;
                employee.Password = reader[7].ToString();
                employee.Role = reader[8].ToString();
                emplist.Add(employee);
            }
            connection.Close();
            return emplist;
        }

        public bool changePassword(ChangePassword newCredentials)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=TRAINING4;Initial Catalog=EmployeeRecord;User ID=sa;Password=test123!@#";
                connection.Open();
                SqlCommand changePassword = new SqlCommand("changePassword", connection);
                changePassword.CommandType = CommandType.StoredProcedure;

                if (changePassword != null)
                {
                    changePassword.Parameters.Add(new SqlParameter("@emp_id", newCredentials.Id));
                    changePassword.Parameters.Add(new SqlParameter("@password", newCredentials.NewPassword));
                    changePassword.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

    }
}
