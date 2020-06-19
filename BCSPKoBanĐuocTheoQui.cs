using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace QuanLyCuaHangSach
{
    public partial class FrmBCSPKoBánĐươcTheoQuí : Form
    {
        public FrmBCSPKoBánĐươcTheoQuí()
        {
            InitializeComponent();
        }

        private void FrmBCSPKoBánĐươcTheoQuí_Load(object sender, EventArgs e)
        {

            this.rpwBCSPKoBánĐược.RefreshReport();
            this.rpwBCSPKoBánĐược.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.QuanLyCuaHangSachConnectionString;
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText = "BCSPKoBánĐượcTheoQuí";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@ThángKoBánĐược",dtpThangKoBánĐc.Value.Date));
            //Khai báo dataset để chứa dữ liệu
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            //Thiết lập báo cáo
            rpwBCSPKoBánĐược.ProcessingMode = ProcessingMode.Local;
            rpwBCSPKoBánĐược.LocalReport.ReportPath = "rptBCSPKoBánĐượcTheoQuí.rdlc";
            MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
            if(ds.Tables[0].Rows.Count>0)
            {
                ReportDataSource rds=new ReportDataSource();
                rds.Name="BCSPKoBánĐượcTheoQuí";
                rds.Value=ds.Tables[0];
                //Gắn lên mẫu báo cáo
                rpwBCSPKoBánĐược.LocalReport.DataSources.Clear();
                rpwBCSPKoBánĐược.LocalReport.DataSources.Add(rds);
                rpwBCSPKoBánĐược.RefreshReport();


            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
