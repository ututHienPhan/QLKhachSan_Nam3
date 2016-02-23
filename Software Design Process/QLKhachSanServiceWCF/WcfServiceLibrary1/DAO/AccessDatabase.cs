using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public enum ParameterType
    {
        Inte = SqlDbType.Int,
        String = SqlDbType.VarChar,
        Datetime = SqlDbType.DateTime,
        Float = SqlDbType.Float
    }

    public class DieuKienParameter
    {
        public string TenDK
        { get; set; }

        public string GiaTri
        { get; set; }

        public ParameterType Type
        { get; set; }

        public DieuKienParameter(string ten, string giatri, ParameterType type)
        {
            TenDK = ten;
            GiaTri = giatri;
            Type = type;
        }
    }

    // For joinning purpose (Don't care about this at this time)
    public class JoinObjectParameter
    {
        public string Joining
        { get; set; }

        public string JoiningName
        { get; set; }

        public int NumberOfItem
        { get; set; }

        public List<string> SelectItem
        { get; set; }

        public DieuKienParameter JoinCondition
        { get; set; }

        public JoinObjectParameter Joined
        { get; set; }

        public JoinObjectParameter(List<string> objectname, List<DieuKienParameter> conname)
        {
            Joining = objectname[0];
            JoinCondition = conname[0];
            NumberOfItem = objectname.Count;

            for (int i = 1; i < objectname.Count; i++)
            {
                List<string> tmpobname = new List<string>();
                List<DieuKienParameter> tmpcon = new List<DieuKienParameter>();

                for (int j = i; j < objectname.Count; j++)
                {
                    tmpobname.Add(objectname[j]);
                    tmpcon.Add(conname[j]);
                }

                Joined = new JoinObjectParameter(tmpobname, tmpcon);
            }
        }

    }

    public abstract class AccessDatabase
    {
        protected string DuongDan;
        // Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Downloads\Software Design Process\QLKhachSan\CSDL\QLKHACHSAN.mdf;Integrated Security=True;Connect Timeout=30
        public AccessDatabase()
        {
            this.DuongDan = @"Server=localhost;Trusted_Connection=yes;database=QLKHACHSAN;connection timeout=30";
        }


        public DataTable Doc_bang_Adap(string TenBang, List<string> Select, List<DieuKienParameter> DieuKien)
        {
            // Define connection
            SqlConnection con = new SqlConnection(DuongDan);

            // Define select target
            string select = "";

            if (Select.Count > 0)
            {
                for (int i = 0; i < Select.Count; i++)
                {
                    if (i != (Select.Count - 1))
                        select += Select[i] + ", ";
                    else
                        select += Select[i];
                }
            }
            else
            {
                select = "* ";
            }

            // Define query string
            string query = "select DISTINCT " + select + " from " + TenBang;

            if (DieuKien.Count > 0)
            {
                query += " where ";
                for (int i = 0; i < DieuKien.Count; i++)
                {
                    if (i != (DieuKien.Count - 1))
                    {
                        query += DieuKien[i].TenDK + "=@" +
                            (DieuKien[i].TenDK[1] == '.' ? DieuKien[i].TenDK.Substring(2) : DieuKien[i].TenDK)
                            + " and ";
                    }
                    else
                        query += DieuKien[i].TenDK + "=@" +
                            (DieuKien[i].TenDK[1] == '.' ? DieuKien[i].TenDK.Substring(2) : DieuKien[i].TenDK);
                }
            }
            else
            {

            }

            // Prepare getting data
            SqlDataAdapter adap = new SqlDataAdapter();

            adap.SelectCommand = new SqlCommand(query, con);

            if (DieuKien.Count > 0)
            {
                foreach (var item in DieuKien)
                {
                    string TenDK = (item.TenDK[1] == '.' ? item.TenDK.Substring(2) : item.TenDK);

                    adap.SelectCommand.Parameters.Add("@" + TenDK, item.Type);
                    if (item.Type == ParameterType.Inte)
                        adap.SelectCommand.Parameters["@" + TenDK].Value = Int32.Parse(item.GiaTri);
                    if (item.Type == ParameterType.String)
                        adap.SelectCommand.Parameters["@" + TenDK].Value = item.GiaTri;
                    if (item.Type == ParameterType.Float)
                        adap.SelectCommand.Parameters["@" + TenDK].Value = Double.Parse(item.GiaTri);
                }
            }

            // Getting and return result
            DataTable result = new DataTable();

            adap.Fill(result);

            return result;
        }

        public bool Them_bang(string TenBang, List<string> Items, List<DieuKienParameter> Values)
        {
            SqlConnection con = new SqlConnection(DuongDan);

            con.Open();

            // Prepare executed string.
            string non_query = "INSERT INTO " + TenBang + "(";

            for (int i = 0; i < Items.Count; i++)
            {
                if (i != Items.Count - 1)
                    non_query += Items[i] + ",";
                else
                    non_query += Items[i] + ") VALUES(";
            }

            for (int i = 0; i < Values.Count; i++)
            {
                if (i != Values.Count - 1)
                {
                    non_query += "@" + Values[i].TenDK + ",";
                }
                else
                {
                    non_query += "@" + Values[i].TenDK + ")";
                }
            }

            // Setting the executed command
            SqlCommand cmd = new SqlCommand(non_query, con);

            foreach (var item in Values)
            {
                cmd.Parameters.Add("@" + item.TenDK, item.Type);

                if (item.Type == ParameterType.Inte)
                    cmd.Parameters["@" + item.TenDK].Value = Int32.Parse(item.GiaTri);
                if (item.Type == ParameterType.String)
                    cmd.Parameters["@" + item.TenDK].Value = item.GiaTri;
                if (item.Type == ParameterType.Float)
                    cmd.Parameters["@" + item.TenDK].Value = Double.Parse(item.GiaTri);
                if (item.Type == ParameterType.Datetime)
                    cmd.Parameters["@" + item.TenDK].Value = item.GiaTri;
            }

            // Execute the insert query
            int result = cmd.ExecuteNonQuery();

            con.Close();

            if (result > 0)
                return true;
            return false;
        }

        public bool TransactSQL(string procName, List<DieuKienParameter> DieuKien)
        {
            using (SqlConnection con = new SqlConnection(DuongDan))
            {
                using (SqlCommand command=new SqlCommand(procName, con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var item in DieuKien)
                    {
                        command.Parameters.Add("@" + item.TenDK, item.Type);

                        if (item.Type == ParameterType.Inte)
                            command.Parameters["@" + item.TenDK].Value = Int32.Parse(item.GiaTri);
                        if (item.Type == ParameterType.String)
                            command.Parameters["@" + item.TenDK].Value = item.GiaTri;
                        if (item.Type == ParameterType.Float)
                            command.Parameters["@" + item.TenDK].Value = Double.Parse(item.GiaTri);
                        if (item.Type == ParameterType.Datetime)
                            command.Parameters["@" + item.TenDK].Value = item.GiaTri;
                    }

                    con.Open();
                    try
                    {
                        int kq = command.ExecuteNonQuery();
                        if (kq == 0)
                            return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Xoa_bang(string TenBang, List<DieuKienParameter> Values)
        {
            SqlConnection con = new SqlConnection(DuongDan);

            con.Open();

            // Prepare executed string.
            string non_query = "DELETE FROM " + TenBang;

            // If we not declare Value, we will delete all the data from the specific table
            if (Values.Count > 0)
            {
                non_query += " WHERE ";
                for (int i = 0; i < Values.Count; i++)
                {
                    if (i != Values.Count - 1)
                    {
                        non_query += Values[i].TenDK + "=@" + Values[i].TenDK + " AND ";
                    }
                    else
                    {
                        non_query += Values[i].TenDK + "=@" + Values[i].TenDK;
                    }
                }
            }

            // Setting the executed command
            SqlCommand cmd = new SqlCommand(non_query, con);

            foreach (var item in Values)
            {
                cmd.Parameters.Add("@" + item.TenDK, item.Type);

                if (item.Type == ParameterType.Inte)
                    cmd.Parameters["@" + item.TenDK].Value = Int32.Parse(item.GiaTri);
                if (item.Type == ParameterType.String)
                    cmd.Parameters["@" + item.TenDK].Value = item.GiaTri;
                if (item.Type == ParameterType.Float)
                    cmd.Parameters["@" + item.TenDK].Value = Double.Parse(item.GiaTri);
            }

            // Execute the insert query
            int result = cmd.ExecuteNonQuery();

            con.Close();

            if (result > 0)
                return true;
            return false;
        }

        public bool Cap_nhap_bang(string TenBang, List<DieuKienParameter> UpdateItem,
            List<DieuKienParameter> DieuKien)
        {
            SqlConnection con = new SqlConnection(DuongDan);

            con.Open();

            // Prepare executed string.
            string non_query = "UPDATE " + TenBang + " SET ";

            // Set the item needed to be updated
            for (int i = 0; i < UpdateItem.Count; i++)
            {
                if (i != UpdateItem.Count - 1)
                    non_query += UpdateItem[i].TenDK + "=@" + UpdateItem[i].TenDK + ",";
                else
                    non_query += UpdateItem[i].TenDK + "=@" + UpdateItem[i].TenDK;
            }

            // If we need to adjust on some specific row, this is the condition
            if (DieuKien.Count > 0)
            {
                non_query += " WHERE ";
                for (int i = 0; i < DieuKien.Count; i++)
                {
                    if (i != DieuKien.Count - 1)
                    {
                        non_query += DieuKien[i].TenDK + "=@" + DieuKien[i].TenDK + i.ToString() + " AND ";
                    }
                    else
                    {
                        non_query += DieuKien[i].TenDK + "=@" + DieuKien[i].TenDK + i.ToString();
                    }
                }
            }

            // Setting the executed command
            SqlCommand cmd = new SqlCommand(non_query, con);

            foreach (var item in UpdateItem)
            {
                cmd.Parameters.Add("@" + item.TenDK, item.Type);

                if (item.Type == ParameterType.Inte)
                    cmd.Parameters["@" + item.TenDK].Value = Int32.Parse(item.GiaTri);
                if (item.Type == ParameterType.String)
                    cmd.Parameters["@" + item.TenDK].Value = item.GiaTri;
                if (item.Type == ParameterType.Float)
                    cmd.Parameters["@" + item.TenDK].Value = Double.Parse(item.GiaTri);
            }

            // We must add parameter for condition case
            if (DieuKien.Count > 0)
            {
                int i = 0;

                foreach (var item in DieuKien)
                {
                    cmd.Parameters.Add("@" + item.TenDK + i.ToString(), item.Type);

                    if (item.Type == ParameterType.Inte)
                        cmd.Parameters["@" + item.TenDK + i.ToString()].Value = Int32.Parse(item.GiaTri);
                    if (item.Type == ParameterType.String)
                        cmd.Parameters["@" + item.TenDK + i.ToString()].Value = item.GiaTri;
                    if (item.Type == ParameterType.Float)
                        cmd.Parameters["@" + item.TenDK + i.ToString()].Value = Double.Parse(item.GiaTri);

                    i++;
                }
            }

            // Execute the insert query
            int result = cmd.ExecuteNonQuery();

            con.Close();

            if (result > 0)
                return true;
            return false;
        }

        public string Doc_bang_Scalar(string TenBang, string SelectedItem, List<DieuKienParameter> DieuKien, string Loai = "")
        {
            // Define connection
            SqlConnection con = new SqlConnection(DuongDan);

            con.Open();

            // Define query string
            string query = "";

            if (Loai != "")
                query = "select " + Loai + "( " + SelectedItem + ") from " + TenBang;
            else
                query = "select " + SelectedItem + " from " + TenBang;

            if (DieuKien.Count > 0)
            {
                query += " where ";
                for (int i = 0; i < DieuKien.Count; i++)
                {
                    if (i != (DieuKien.Count - 1))
                    {
                        query += DieuKien[i].TenDK + "=@" +
                            (DieuKien[i].TenDK[1] == '.' ? DieuKien[i].TenDK.Substring(2) : DieuKien[i].TenDK)
                            + " and ";
                    }
                    else
                        query += DieuKien[i].TenDK + "=@" +
                            (DieuKien[i].TenDK[1] == '.' ? DieuKien[i].TenDK.Substring(2) : DieuKien[i].TenDK);
                }
            }

            // Prepare getting data
            SqlCommand com = new SqlCommand(query, con);

            if (DieuKien.Count > 0)
            {
                foreach (var item in DieuKien)
                {
                    string TenDK = (item.TenDK[1] == '.' ? item.TenDK.Substring(2) : item.TenDK);

                    com.Parameters.Add("@" + TenDK, item.Type);
                    if (item.Type == ParameterType.Inte)
                        com.Parameters["@" + TenDK].Value = Int32.Parse(item.GiaTri);
                    if (item.Type == ParameterType.String)
                        com.Parameters["@" + TenDK].Value = item.GiaTri;
                    if (item.Type == ParameterType.Float)
                        com.Parameters["@" + TenDK].Value = Double.Parse(item.GiaTri);
                }
            }

            // Getting and return result
            string result = Convert.ToString(com.ExecuteScalar());

            con.Close();

            return result;
        }

        public int Dem(string TenBang, List<string> Items)
        {
            int d = 0;
            SqlConnection con = new SqlConnection(DuongDan);

            con.Open();

            string query = "select count(distinct ";
            for (int i = 0; i < Items.Count; i++)
            {
                if (i != Items.Count - 1)
                    query += Items[i] + ",";
                else
                    query += Items[i] + ") as sl from ";
            }
            query = query + TenBang;

            SqlDataAdapter adap = new SqlDataAdapter();

            adap.SelectCommand = new SqlCommand(query, con);
            DataTable kq = new DataTable();
            adap.Fill(kq);
            DataRow row = kq.Rows[0];
            d = int.Parse(row["sl"].ToString());
            return d;
        }
        /*
        public DataTable Doc_bang_Adap_Join(JoinObjectParameter All, List<DieuKienParameter> DieuKien)
        {
            int i;

            // Define connection
            SqlConnection con = new SqlConnection(DuongDan);

            // Define select target
            string select = "";

            JoinObjectParameter tmp = All;

            while(tmp.NumberOfItem>=0)
            {
                if(tmp.SelectItem.Count>0)
                {
                    string name = tmp.JoiningName;
                    for (int j = 0; j < tmp.SelectItem.Count;j++ )
                    {
                        if (j != tmp.SelectItem.Count - 1)
                            select += name + "." + tmp.SelectItem[j] + ",";
                        else
                            select += name + "." + tmp.SelectItem[j];
                    }
                }
                else
                {
                    tmp = tmp.Joined;
                }
            }

            // Define query string
            string query = "select DISTINCT " + select + " from ";

            tmp = All;

            string table = "";

            while(tmp.NumberOfItem>0)
            {
                if (tmp.NumberOfItem == All.NumberOfItem)
                {
                    table += tmp.Joining + " " + tmp.JoiningName + " join "
                        + tmp.Joined.Joining + " " + tmp.Joined.JoiningName + " on "
                        + tmp.JoiningName + "." + tmp.JoinCondition.TenDK + "="
                        + tmp.Joined.JoiningName + "." + tmp.Joined.JoinCondition.TenDK + " ";
                }
                else
                {
                    table += " join "
                        + tmp.Joined.Joining + " " + tmp.Joined.JoiningName + " on "
                        + tmp.JoiningName + "." + tmp.JoinCondition.TenDK + "="
                        + tmp.Joined.JoiningName + "." + tmp.Joined.JoinCondition.TenDK + " ";
                }

                tmp = tmp.Joined;
            }

            query + table;

            if (DieuKien.Count > 0)
            {
                query += " where ";
                for (int i = 0; i < DieuKien.Count; i++)
                {
                    if (i != (DieuKien.Count - 1))
                        query += DieuKien[i].TenDK + "=@" + DieuKien[i].TenDK + " and ";
                    else
                        query += DieuKien[i].TenDK + "=@" + DieuKien[i].TenDK;
                }
            }
            else
            {

            }

            // Prepare getting data
            SqlDataAdapter adap = new SqlDataAdapter();

            adap.SelectCommand = new SqlCommand(query, con);

            if (DieuKien.Count > 0)
            {
                foreach (var item in DieuKien)
                {
                    adap.SelectCommand.Parameters.Add("@" + item.TenDK, item.Type);
                    if (item.Type == ParameterType.Inte)
                        adap.SelectCommand.Parameters["@" + item.TenDK].Value = Int32.Parse(item.GiaTri);
                    if (item.Type == ParameterType.String)
                        adap.SelectCommand.Parameters["@" + item.TenDK].Value = item.GiaTri;
                    if (item.Type == ParameterType.Float)
                        adap.SelectCommand.Parameters["@" + item.TenDK].Value = Double.Parse(item.GiaTri);
                }
            }

            // Getting and return result
            DataTable result = new DataTable();

            adap.Fill(result);

            return result;
        }
         */
    }
}
