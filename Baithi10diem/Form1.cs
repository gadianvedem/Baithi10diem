using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baithi10diem
{
    public partial class Form1 : Form
    { 
        
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=COGAINAMAY\SQLEXPRESS01;Initial Catalog=qlthuvien;Integrated Security=True";
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        SqlDataAdapter adapter2 = new SqlDataAdapter();
        
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();


        void loaddata()
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Lấy dữ liệu cho table1 và hiển thị trong dataGridView2
                command = new SqlCommand("SELECT * FROM SINH_VIEN", connection);
                adapter1.SelectCommand = command;
                table1.Clear();
                adapter1.Fill(table1);
                dataGridView1.DataSource = table1;

                // Lấy dữ liệu cho table2 và hiển thị trong dataGridView1
                command = new SqlCommand("SELECT * FROM PHIEU_MUON", connection);
                adapter2.SelectCommand = command;
                table2.Clear();
                adapter2.Fill(table2);
                dataGridView2.DataSource = table2;

                connection.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO SINH_VIEN (MSSV,Ten_sinh_vien,Ma_lop,Ten_lop) " +
                "VALUES (@MSSV,@Ten_sinh_vien,@Ma_lop,@Ten_lop);";
                    command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                    command.Parameters.AddWithValue("@Ten_sinh_vien", Ten_sinh_vien.Text);
                    command.Parameters.AddWithValue("@Ma_lop", Ma_lop.Text);
                    command.Parameters.AddWithValue("@Ten_lop", Ten_lop.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM SINH_VIEN WHERE MSSV=@MSSV";
                    command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentCell.RowIndex;
            MSSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            Ten_sinh_vien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            Ma_lop.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            Ten_lop.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE SINH_VIEN SET " +
                            " Ten_sinh_vien=@Ten_sinh_vien,Ma_lop=@Ma_lop,Ten_lop=@Ten_lop WHERE MSSV=@MSSV";
                        command.Parameters.AddWithValue("@Ten_sinh_vien", Ten_sinh_vien.Text);
                        command.Parameters.AddWithValue("@Ma_lop", Ma_lop.Text);
                        command.Parameters.AddWithValue("@Ten_lop", Ten_lop.Text);
                        command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO PHIEU_MUON (So_phieu,Ngay_muon,Ngay_tra,MSSV,Ma_sach) " +
                "VALUES (@So_phieu,@Ngay_muon,@Ngay_tra,@Masv,@Ma_sach);";
                    command.Parameters.AddWithValue("@So_phieu", So_phieu.Text);
                    command.Parameters.AddWithValue("@Ngay_muon", Ngay_muon.Text);
                    command.Parameters.AddWithValue("@Ngay_tra", Ngay_tra.Text);
                    command.Parameters.AddWithValue("@Masv", Masv.Text);
                    command.Parameters.AddWithValue("@Ma_sach", Ma_sach.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM PHIEU_MUON WHERE So_phieu=@So_phieu";
                    command.Parameters.AddWithValue("@So_phieu", So_phieu.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
 

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = dataGridView2.CurrentCell.RowIndex;
            So_phieu.Text = dataGridView2.Rows[n].Cells[0].Value.ToString();
            Ngay_muon.Text = dataGridView2.Rows[n].Cells[1].Value.ToString();
            Ngay_tra.Text = dataGridView2.Rows[n].Cells[2].Value.ToString();
            Masv.Text = dataGridView2.Rows[n].Cells[3].Value.ToString();
            Ma_sach.Text = dataGridView2.Rows[n].Cells[4].Value.ToString();
            loaddata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE PHIEU_MUON SET " +
                            " Ngay_muon=@Ngay_muon,Ngay_tra=@Ngay_tra,MSSV=@Masv,Ma_sach=@Ma_sach WHERE So_phieu=@So_phieu";
                        command.Parameters.AddWithValue("@Ngay_muon", Ngay_muon.Text);
                        command.Parameters.AddWithValue("@Ngay_tra", Ngay_tra.Text);
                        command.Parameters.AddWithValue("@Masv", Masv.Text);
                        command.Parameters.AddWithValue("@Ma_sach", Ma_sach.Text);
                        command.Parameters.AddWithValue("@So_phieu", So_phieu.Text);
                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
