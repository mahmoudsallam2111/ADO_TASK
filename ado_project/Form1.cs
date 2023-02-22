using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ado_project
{
    public partial class Form1 : Form
    {

        private SqlConnection connection;


            public Form1()
            {
            InitializeComponent();
            
               connection= new SqlConnection(ConfigurationManager.ConnectionStrings["iti"].ConnectionString);
            }

        private void fillStudentData()
        {
            try
            {
                // define quary
                SqlCommand command = new SqlCommand("select * from Course", connection);
                // open connection
                connection.Open();
                // excute query
                SqlDataReader sdr = command.ExecuteReader();
                

                //prepare data
                List<Course> Courses = new List<Course>();
                while (sdr.Read()) //only farward direction
                {
                    Course c = new Course();
                    c.crs_Id = (int)sdr[0];
                    c.crs_Name = sdr[1]?.ToString();
                    c.crs_Duration = (int)sdr[2];
                    c.topic_Id = (int)sdr[3];

                    Courses.Add(c);
                }
                //close connection
                connection.Close();

                dgv_course.DataSource = Courses;
            }
            catch(Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            fillStudentData();
            try
            {
                // define quary
                SqlCommand command2 = new SqlCommand("select Top_Id , Top_Name from Topic", connection);
                // open connection
                connection.Open();
                // excute query
                SqlDataReader sdr2 = command2.ExecuteReader();

                //prepare data
                List<topic> topics = new List<topic>();
                while (sdr2.Read())  // read row by row
                {
                    topic t = new topic();
                    t.topic_id = (int)sdr2[0];
                    t.topic_name = sdr2[1].ToString();

                    topics.Add(t);
                }
                //close connection
                connection.Close();
                com_topic.DataSource = topics;

            }
            catch(Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex);


            }

            com_topic.DisplayMember= "topic_name";
            com_topic.ValueMember= "topic_id";

            displayedButtons(true);
            dgv_course.Columns[2].Visible= false;

        }

     public int getmaxid()
        {
            SqlCommand command = new SqlCommand("select max(crs_id) from Course ", connection);
            // open connection
            connection.Open();
            // excute query
           var res = command.ExecuteScalar();
            int id =(int)res;

            connection.Close();
            return id;

        }

        //add 
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_coursename.Text == "" || nu_courseDuration.Value == 0)
            {
                MessageBox.Show("enter all fields !!!!!!");

            }
            else {
                int id = getmaxid() + 1;
                string commandTxt = "insert into Course(Crs_Id ,Crs_Name , Crs_Duration , Top_Id )\r\nvalues(@id,@couursename ,@courseDuration, @top)";
                
                SqlCommand command3 = new SqlCommand(commandTxt, connection);
                command3.Parameters.AddWithValue("id", id);
                command3.Parameters.AddWithValue("couursename", txt_coursename.Text);
                command3.Parameters.AddWithValue("courseDuration", nu_courseDuration.Value);
                command3.Parameters.AddWithValue("top", com_topic.SelectedValue);

                connection.Open();
                int res = command3.ExecuteNonQuery();
                connection.Close();
                if (res > 0)
                {
                    MessageBox.Show("data inserted sucessfully");
                    fillStudentData();

                }

                clearinputs();
                fillStudentData();


            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string commandTxt = "update Course set Crs_Name = @name , Crs_Duration = @dur , Top_Id=@topic where Crs_Id = @id";

                SqlCommand command = new SqlCommand(commandTxt, connection);
                command.Parameters.AddWithValue("name", txt_coursename.Text);
                command.Parameters.AddWithValue("dur", nu_courseDuration.Value);
                command.Parameters.AddWithValue("topic", com_topic.SelectedValue);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                var res = command.ExecuteNonQuery();
                connection.Close();

                if (res > 0)
                {
                    MessageBox.Show("updated successfully");
                }

            }
            catch (Exception ex) {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            clearinputs();
            fillStudentData();


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string commandTxt = "delete from Course where Crs_Id = @id";

            SqlCommand command = new SqlCommand(commandTxt, connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();

            var res = command.ExecuteNonQuery();
            connection.Close();
            if (res>0)
            {
                MessageBox.Show("deleted successfully");
            }
            clearinputs();
            fillStudentData();

        }



        private int id;   // specify id when duble click on row 
        private void dgv_course_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           id =(int) dgv_course.SelectedRows[0].Cells[0].Value;
            txt_coursename.Text = dgv_course.SelectedRows[0].Cells[1].Value.ToString();
            nu_courseDuration.Value = (int)dgv_course.SelectedRows[0].Cells[2].Value;
            com_topic.SelectedValue = (int)dgv_course.SelectedRows[0].Cells[3].Value;
            displayedButtons(false);

        }


        public void displayedButtons(bool show)
        {
            btn_add.Visible = show;
            btn_delete.Visible = !show;
            btn_update.Visible  = !show;
        }
        private void clearinputs()
        {
            txt_coursename.Clear();
            nu_courseDuration.Value = 0;


        }

        /*                 bonus part             */
        private void dgv_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_course.Columns[e.ColumnIndex].Name == "delete")
            {
                string commandTxt = "delete from Course where Crs_Id = @id";

                SqlCommand command = new SqlCommand(commandTxt, connection);
               

                int iddd = Convert.ToInt32(this.dgv_course.Rows[e.RowIndex].Cells[2].Value);
                command.Parameters.AddWithValue("id", iddd);
                connection.Open();

                var res = command.ExecuteNonQuery();
                connection.Close();
                
                if (res > 0)
                {
                    MessageBox.Show("deleted successfully");
                }
                clearinputs();
                fillStudentData();


            }else if(dgv_course.Columns[e.ColumnIndex].Name == "update")
            {

                string commandTxt = "update Course set Crs_Name = @cName , Crs_Duration = @duration , Top_Id=@topicnum where Crs_Id = @id";

                int iddd = Convert.ToInt32(this.dgv_course.Rows[e.RowIndex].Cells[2].Value);
                string cName = this.dgv_course.Rows[e.RowIndex].Cells[3].Value.ToString();
                 int dd =(int)this.dgv_course.Rows[e.RowIndex].Cells[4].Value;
                int top_id = (int)this.dgv_course.Rows[e.RowIndex].Cells[5].Value;


                SqlCommand command = new SqlCommand(commandTxt, connection);
                command.Parameters.AddWithValue("cName", cName);
                command.Parameters.AddWithValue("duration", dd);
                command.Parameters.AddWithValue("topicnum", top_id);
                command.Parameters.AddWithValue("id", iddd);
                connection.Open();

                var res = command.ExecuteNonQuery();
                connection.Close();

                if (res > 0)
                {
                    MessageBox.Show("updated successfully");
                }

            }

        }


    }
}