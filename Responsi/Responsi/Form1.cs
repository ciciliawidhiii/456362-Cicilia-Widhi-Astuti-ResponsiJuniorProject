using System;
using System.Data;
using Npgsql;


namespace Responsi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "Host:localhost;Port:2022;Username:postgres;Password:informatika;Database:responsi2";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert_newww (:_nama, :_dept)"; 
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                cmd.Parameters.AddWithValue("_dept", tbDept.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data berhasil masuk");
                    conn.Close();
                    btnLoad.PerformClick();
                    tbNama.Text = tbDept.Text = null;


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Fail!");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                dgvData.DataSource = null;
                sql = @"select * from st_select ()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                //gsqlReader rd = cmd.ExecuteReader();
               //t.Load(rd);
                dgvData.DataSource = dt;
                conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Fail!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_delete(:_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id", r.Cells["_id"].Value.ToString());
                // (r = null)
                {
                    MessageBox.Show("mohon pilih data yang ingin dihapus");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Fail!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           // (r = null)
            {
                MessageBox.Show("mohon pilih data yang ingin dihapus");
                return;
            }


        }
    }
}