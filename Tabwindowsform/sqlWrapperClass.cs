using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace Tabwindowsform
{
    public static class clsSQLWrapper
    {
        private static string strConnectionString
        {
            get { return "data source=MD4KYC2C\\SQLEXPRESS; database=College_Database; integrated security = SSPI"; }
        }
        //private static SqlConnection sqlcon;
        //public SqlCommand sqlcmd;  //("To run Procedure")
        //public SqlDataAdapter sqlDA; //  '("Return resul from sqlcommand and push to data set")
        //public DataSet sqlDS;
        //public SqlDataReader sqlReader;

        static clsSQLWrapper()
        {
            //sqlcon = new SqlConnection(strConnectionString);
        }

        public static bool s_blnHasConnection()
        {
            //SqlConnection sqlcon;
            using (SqlConnection sqlcon = new SqlConnection(strConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    sqlcon.Close(); ;
                    return true;
                }
                catch
                {
                    //Interaction.MsgBox(ex.Message);
                    return false;
                }
                //finally
                //{
                //    if (sqlcon != null)
                //    {
                //        sqlcon = null;
                //    }
                //}
            }


        }

        public static DataSet runUserQuery(string Query, Object blnError = null)
        {
            //SqlConnection sqlcon;
            using (SqlConnection sqlcon = new SqlConnection(strConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    //Create Command
                    SqlCommand sqlcmd;
                    SqlDataAdapter sqlDA;
                    DataSet sqlDS;
                    sqlcmd = new SqlCommand(Query, sqlcon);
                    sqlDA = new SqlDataAdapter(sqlcmd);
                    sqlDS = new DataSet();
                    sqlDA.Fill(sqlDS);
                    sqlcmd.Parameters.Clear();
                    return sqlDS;
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    //Interaction.MsgBox(ex.Message);
                    //If query Fails conncetion closed

                    if (blnError != null)
                    {
                        blnError = true;
                    }
                    return null;
                }
                finally
                {
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        sqlcon.Close();
                    }
                    //if (sqlcon != null)
                    //{
                    //    sqlcon = null;
                    //}
                }
            }
            //sqlcon = new SqlConnection(strConnectionString);
        }
        public static DataSet runProcedureUser(string i_procedureName, List<SqlParameter> i_lstParamas)
        {
            //SqlConnection sqlcon;
            //sqlcon = new SqlConnection(strConnectionString);
            using (SqlConnection sqlcon = new SqlConnection(strConnectionString))
            {
                try
                {
                    //Using cn As SqlConnection = sqlUserCon
                    DataSet sqlDS;
                    // Create the command with the sproc name and add the parameter required'
                    using (SqlCommand cmd = new SqlCommand(i_procedureName, sqlcon))
                    {
                        sqlcon.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //string para = "";
                        //string value = "";
                        for (int iCount = 0; iCount <= i_lstParamas.Count - 1; iCount++)
                        {
                            //para = i_lstParamas(iCount).Split(";")(0)
                            //value = i_lstParamas(iCount).Split(";")(1)
                            cmd.Parameters.Add(i_lstParamas[iCount]);
                        }
                        //cmd.ExecuteNonQuery()
                        //sqlReader = Nothing
                        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

                        //DataTable table = new DataTable();
                        sqlDS = new DataSet();
                        sqlda.Fill(sqlDS);
                        cmd.Parameters.Clear();
                        return sqlDS;
                        //If sqlReader.HasRows Then


                        //Else
                        //    Console.WriteLine("No rows found.")
                        //End If

                        //sqlReader.Close()

                        // If the SqlDataReader.Read returns true then there is a customer with that ID'
                        //If r.Read() Then

                        //    i_SqlDS = r
                        //    ' Get the first and second field frm the reader'
                        //    'lblName.Text = r.GetString(0)
                        //    'lblAddress.Text = r.GetString(1)
                        //End If
                    }
                    //End Using
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    //MessageBox.Show("Error Occured", "Database Management", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;

                }
                finally
                {
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        sqlcon.Close();
                    }
                    //if (sqlcon != null)
                    //{
                    //    sqlcon = null;
                    //}
                }
            }

        }

        public static int runProcedure(string i_procedureName, List<SqlParameter> i_lstParamas)
        {
            //SqlConnection sqlcon;
            //sqlcon = new SqlConnection(strConnectionString);
            using (SqlConnection sqlcon = new SqlConnection(strConnectionString))
            {
                try
                {
                    //Using cn As SqlConnection = sqlUserCon

                    // Create the command with the sproc name and add the parameter required'
                    using (SqlCommand cmd = new SqlCommand(i_procedureName, sqlcon))
                    {
                        sqlcon.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int iCount = 0; iCount <= i_lstParamas.Count - 1; iCount++)
                        {
                            cmd.Parameters.Add(i_lstParamas[iCount]);
                        }
                        SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        int id = (int)returnParameter.Value;
                        cmd.Parameters.Clear();
                        //sqlReader = Nothing
                        //SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

                        ////DataTable table = new DataTable();
                        //sqlDS = new DataSet();
                        //sqlda.Fill(sqlDS);
                        //cmd.Parameters.Clear();
                        return id;
                        //If sqlReader.HasRows Then


                        //Else
                        //    Console.WriteLine("No rows found.")
                        //End If

                        //sqlReader.Close()

                        // If the SqlDataReader.Read returns true then there is a customer with that ID'
                        //If r.Read() Then

                        //    i_SqlDS = r
                        //    ' Get the first and second field frm the reader'
                        //    'lblName.Text = r.GetString(0)
                        //    'lblAddress.Text = r.GetString(1)
                        //End If
                    }
                    //End Using
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    //MessageBox.Show("Error Occured", "Database Management", MessageBoxButton.OK, MessageBoxImage.Information);
                    return 11;

                }
                finally
                {
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        sqlcon.Close();
                    }
                    //if (sqlcon != null)
                    //{
                    //    sqlcon = null;
                    //}
                }
            }
        }

    }
}