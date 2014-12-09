using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Service
{
    public class TestSevice
    {
        DataSet data = new DataSet();

                foreach (var sheetName in GetExcelSheetNames(excelConnectionString))
                {
                    using (OleDbConnection con = new OleDbConnection(excelConnectionString))
                    {
                        var dataTable = new DataTable(sheetName);
                        string query = string.Format("SELECT * FROM [{0}]", sheetName);
                        con.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                        adapter.Fill(dataTable);
                        data.Tables.Add(dataTable);

                        using (TtestContext dc = new TtestContext())
                        {
                            for (int i = 0; i < dataTable.Tables[0].Rows.Count; i++)
                            {
                                string conn = ConfigurationManager.ConnectionStrings["TtestContext"].ConnectionString;
                                SqlConnection con = new SqlConnection(conn);
                                string query2 = "Insert  into  ExcelTemps(Courier,F2,F3,F4,F5,F6,F7,F8,F9,F10) Values('"
                                + dataTable.Tables[0].Rows[i][0].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][1].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][2].ToString().Replace("'", "''") + "' ,'"
                                + dataTable.Tables[0].Rows[i][3].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][4].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][5].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][6].ToString().Replace("'", "''") + "','"
                                + dataTable.Tables[0].Rows[i][7].ToString().Replace("'", "''") + "','"
                               + dataTable.Tables[0].Rows[i][8].ToString().Replace("'", "''") + "','"
                               + dataTable.Tables[0].Rows[i][9].ToString().Replace("'", "''") + "','"
                                   + dataTable + "')";
                                con.Open();
                                SqlCommand cmd = new SqlCommand(query2, con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }
        }
        return View();
    }

    static string[] GetExcelSheetNames(string connectionString)
    {
        OleDbConnection con = null;
        DataTable dt = null;
        con = new OleDbConnection(connectionString);
        con.Open();
        dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt == null)
        {
            return null;
        }
        String[] excelSheetNames = new String[dt.Rows.Count];
        int i = 0;

        foreach (DataRow row in dt.Rows)
        {
            excelSheetNames[i] = row["TABLE_NAME"].ToString();
            i++;
        }
        return excelSheetNames;
    }

}
    }
}