using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ado_2_instructor_crud
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        string connectionString = "Data Source=DESKTOP-A89CRET;Initial Catalog=ITI;Integrated Security=True";
        
        private void gridfilldata()
        {
            string commandtxt = "select * from instructor";
            SqlCommand command= new SqlCommand(commandtxt , connection);
            connection.Open();
            SqlDataReader sdr = command.ExecuteReader();
           
            List<instructor> instructors = new List<instructor>();

            while (sdr.Read())
            {
                instructor s = new instructor();
                s.ins_id =(int) sdr[0];
                s.ins_name = sdr[1].ToString();
                s.ins_degree = sdr[2].ToString();
                s.ins_salary = (decimal)sdr[3];
                s.dept_id = (int)sdr[4];

                instructors.Add(s);

            }
            connection.Close();

            dgv_inst.DataSource = instructors;

        }
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridfilldata();

            string cmdtxt = "select  DISTINCT i.Dept_Id , d.Dept_Name   from Instructor as i inner join Department d \r\non i.Dept_Id = d.Dept_Id";
            SqlCommand command = new SqlCommand(cmdtxt, connection);
            connection.Open();

            SqlDataReader sdr = command.ExecuteReader();

           List<department> departments = new List<department>();
            while (sdr.Read())
            {
                department department = new department();
                department.dept_id = (int)sdr[0];
                department.dept_name = sdr[1].ToString();

                departments.Add(department);

            }
            connection.Close();
            combo_dept.DataSource = departments;
            combo_dept.DisplayMember = "dept_name";
            combo_dept.ValueMember = "dept_id";

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (connection.State== ConnectionState.Closed)
            {
                connection.Open();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();

            }

        }


        public int getmaxid()
        {
            SqlCommand command = new SqlCommand("select max(ins_id) from instructor", connection);
            // open connection
            connection.Open();
            // excute query
            var res = command.ExecuteScalar();
            int id = (int)res;

            connection.Close();
            return id;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int id = getmaxid() + 1;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;  // defining type
            command.CommandText = "addinst"; // the name of stored proc
            
            
            command.Parameters.AddWithValue("id" , id);
            command.Parameters.AddWithValue("name",txt_name.Text);
            command.Parameters.AddWithValue("spec",txt_degree.Text);
            command.Parameters.AddWithValue("sal",input_salary.Value);
            command.Parameters.AddWithValue("dept",combo_dept.SelectedValue);
            

            command.Connection = connection;

            connection.Open();

           int res =  command.ExecuteNonQuery();
            connection.Close();

            if (res >0)
            {
                MessageBox.Show("inserted successfully");

            }

            gridfilldata();

        }

        private int id;


        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlCommand command= new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "editinst";
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", txt_name.Text);
            command.Parameters.AddWithValue("spec", txt_degree.Text);
            command.Parameters.AddWithValue("sal", input_salary.Value);
            command.Parameters.AddWithValue("dept", combo_dept.SelectedValue);


            command.Connection = connection;

            connection.Open();

            int res = command.ExecuteNonQuery();

            connection.Close();

            if (res >0)
            {
                MessageBox.Show("updted successfully");

            }

            gridfilldata();

        }

        private void dgv_inst_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id =(int) dgv_inst.SelectedRows[0].Cells[0].Value;
            txt_name.Text = dgv_inst.SelectedRows[0].Cells[1].Value.ToString();
            txt_degree.Text = dgv_inst.SelectedRows[0].Cells[2].Value.ToString();
            combo_dept.SelectedValue =(int) dgv_inst.SelectedRows[0].Cells[4].Value;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "deleteinst";

            command.Parameters.AddWithValue("id", id);
            connection.Open();

            int r = command.ExecuteNonQuery();

            connection.Close();
            if (r >0)
            {
                MessageBox.Show("deleted successfully");
            }

            gridfilldata();
        }

        private void combo_dept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}