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

namespace Tabwindowsform
{
    public partial class Form1 : Form
    {
        //Person Table variables
        int dept_Id;
        string F_Name;
        string L_Name;
        string Mobile;
        string Type;
        int return_person_ID;

        //Address Table variables
        string Address;
        int person_Id;
        int c_Id;
        string cityName;
        int return_AddressID;

        //subject Table variables
        string subcode;
        string subname;
        string semester;
        bool common;
        bool elective;

        //Hostel Table variables
        string Name;
        string buildingName;
        int roomNo;
        string Type1;
        public Form1()
        {
            InitializeComponent();
            if (!clsSQLWrapper.s_blnHasConnection())
                MessageBox.Show("Error while connecting to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //---------------------DEPARTMENTS FROM DATABASE
            DataSet ds1 = clsSQLWrapper.runUserQuery("Select * from Department");
            List<Model.clsDepartment> depts = new List<Model.clsDepartment>();
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                Parallel.For(0, ds1.Tables[0].Rows.Count, i =>
                {
                    Model.clsDepartment dept = new Model.clsDepartment();
                    dept.dept_Id = Convert.ToInt32(ds1.Tables[0].Rows[i]["dept_Id"]);
                    dept.deptName = ds1.Tables[0].Rows[i]["deptName"].ToString();
                    lock (depts)
                        depts.Add(dept);
                });
            }
            cmbxDeptName.DataSource = depts;
            cmbxDeptName.DisplayMember = "deptName";
            cmbxDeptName.ValueMember = "dept_Id";

            cmbDepartment.DataSource = depts;
            cmbDepartment.DisplayMember = "deptName";
            cmbDepartment.ValueMember = "dept_Id";

            //---------------------CITIES FROM DATABASE

            DataSet ds2 = clsSQLWrapper.runUserQuery("Select * from City");

            List<Model.clsCity> cities = new List<Model.clsCity>();
            if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds2.Tables[0].Rows.Count, i =>
                {
                    Model.clsCity city = new Model.clsCity();
                    city.cityName = ds2.Tables[0].Rows[i]["cityName"].ToString();
                    city.c_Id = Convert.ToInt32(ds2.Tables[0].Rows[i]["c_Id"]);
                    city.country = ds2.Tables[0].Rows[i]["country"].ToString();
                    city.pinCode = Convert.ToInt32(ds2.Tables[0].Rows[i]["pinCode"]);

                    lock (cities)
                        cities.Add(city);
                });
            }

            cmbxCity.DataSource = cities;
            cmbxCity.DisplayMember = "cityName";
            cmbxCity.ValueMember = "c_Id";



            ///---------------------SEMESTER FROM DATABASE
            DataSet ds3 = clsSQLWrapper.runUserQuery("Select * from Semester");
            List<Model.clsSemester> Sems = new List<Model.clsSemester>();
            if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
            {
                Parallel.For(0, ds3.Tables[0].Rows.Count, i =>
                {
                    Model.clsSemester sem = new Model.clsSemester();
                    sem.sem_id = Convert.ToInt32(ds3.Tables[0].Rows[i]["sem_id"]);
                    sem.sem_Name = ds3.Tables[0].Rows[i]["sem_Name"].ToString();

                    lock (Sems)
                        Sems.Add(sem);
                });
            }
            cmbSemester.DataSource = Sems;
            cmbSemester.DisplayMember = "sem_Name";
            cmbSemester.ValueMember = "sem_id";

            //---------------------------

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            F_Name = txtFirstName.Text;
            L_Name = txtLastName.Text;
            Mobile = txtMobile.Text;

            Address = txtAddress.Text;
            

            cityName = cmbxCity.SelectedItem.ToString();
            //--------------------INSERT_PERSON------------------------------

            if (rbtnStudent.Checked)
            {
                Type = "Student";
            }
            else if (rbtnFaculty.Checked)
            {
                Type = "Faculty";
            }
            else if (rbtnAdministrator.Checked)
            { Type = "Adminsitrator"; }

            string deptName = cmbxDeptName.SelectedItem.ToString();


            if (F_Name != null && L_Name != null && Address != null && Mobile != null && Mobile.Length==10 && cmbxCity.SelectedValue != null && cmbxDeptName.SelectedValue != null && (rbtnStudent.Checked == true || rbtnFaculty.Checked == true || rbtnAdministrator.Checked == true))
            {
                if (clsSQLWrapper.s_blnHasConnection())
                {

                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.VarChar, Value = F_Name });
                    lstPara.Add(new SqlParameter { ParameterName = "@lastName", SqlDbType = SqlDbType.VarChar, Value = L_Name });
                    lstPara.Add(new SqlParameter { ParameterName = "@type", SqlDbType = SqlDbType.VarChar, Value = Type });
                    lstPara.Add(new SqlParameter { ParameterName = "@mobile", SqlDbType = SqlDbType.VarChar, Value = Mobile });
                    lstPara.Add(new SqlParameter { ParameterName = "@dept_Id", SqlDbType = SqlDbType.Int, Value = cmbxDeptName.SelectedValue });

                    return_person_ID = clsSQLWrapper.runProcedure("Insert_Person", lstPara);

                }


                //-----------------------calling INSERT_ADDRESS stored procedure-------------------------

                person_Id = return_person_ID;

                if (clsSQLWrapper.s_blnHasConnection())
                {

                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@Address", SqlDbType = SqlDbType.VarChar, Value = Address });
                    lstPara.Add(new SqlParameter { ParameterName = "@c_Id", SqlDbType = SqlDbType.Int, Value = cmbxCity.SelectedValue });
                    lstPara.Add(new SqlParameter { ParameterName = "@person_Id", SqlDbType = SqlDbType.Int, Value = person_Id });

                    return_AddressID = clsSQLWrapper.runProcedure("Insert_Address", lstPara);
                }
                MessageBox.Show("Record Added Successfully");
                func_Empty_Filled_Person_Details();

                
            }
            else
            {
                MessageBox.Show("Incomplete Details");
            }
            
        }

        //-------  EMPTY METHOD()-----------
        public void func_Empty_Filled_Person_Details()
        {
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobile.Text = "";
            cmbxDeptName.Text = " ";
            cmbxCity.Text = " ";
            rbtnStudent.Checked = false;
            rbtnFaculty.Checked = false;
            rbtnAdministrator.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            funcDisplayPerson();
        }

        //-------DISPLAY METHOD()-------------
        public void funcDisplayPerson()
        {
            //----Person Table-----
            string query;

            query = "select * from Address inner join Person on Address.person_Id=Person.person_Id inner join City on City.c_ID=Address.c_Id left join Department on Department.dept_Id = Person.dept_Id; ";
            DataSet dsData = clsSQLWrapper.runUserQuery(query);

            List<Model.clsPerson> persons = new List<Model.clsPerson>();
            Parallel.For(0, dsData.Tables[0].Rows.Count, i =>
            {
                Model.clsPerson person = new Model.clsPerson();
                Model.clsCity city = new Model.clsCity();
                Model.clsDepartment dept = new Model.clsDepartment();
                Model.clsAddress add = new Model.clsAddress();

                person.person_Id = Convert.ToInt32(dsData.Tables[0].Rows[i]["person_Id"]);
                person.FirstName = dsData.Tables[0].Rows[i]["firstName"].ToString();
                person.LastName = dsData.Tables[0].Rows[i]["lastName"].ToString();

                dept.dept_Id = Convert.ToInt32(dsData.Tables[0].Rows[i]["dept_Id"]);
                dept.deptName = (dsData.Tables[0].Rows[i]["deptName"]).ToString();
                person.personDept = dept.deptName;
                person.type = dsData.Tables[0].Rows[i]["type"].ToString();
                person.mobile = dsData.Tables[0].Rows[i]["mobile"].ToString();
                add.Add_Id = Convert.ToInt32(dsData.Tables[0].Rows[i]["add_Id"]);
                add.Address = (dsData.Tables[0].Rows[i]["Address"]).ToString();

                city.c_Id = Convert.ToInt32(dsData.Tables[0].Rows[i]["c_Id"]);
                city.cityName = (dsData.Tables[0].Rows[i]["cityName"]).ToString();
                city.pinCode = Convert.ToInt32(dsData.Tables[0].Rows[i]["pinCode"]);
                city.country = (dsData.Tables[0].Rows[i]["country"]).ToString();
                add.City = city;

                person.personFullAddress = add.Address + " " + city.cityName + " " + city.country + " " + city.pinCode;
                lock (persons)
                    persons.Add(person);
            });
            dataGridView1.DataSource = persons.OrderBy(x=>x.person_Id).ToList();
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            subcode = textSubcode.Text;
            subname = txtsubname.Text;


            groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (rbtncommonYES.Checked)
            {
                common = true;
            }

            groupBox2.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(rb => rb.Checked);
            if (rbtnelectiveYES.Checked)
            {
                elective = true;
            }

            if (textSubcode.Text != null && txtsubname.Text != null && cmbDepartment.SelectedValue != null && cmbSemester.SelectedValue != null && (rbtncommonYES.Checked == true || rbtncommonNO.Checked == true) && (rbtnelectiveYES.Checked == true || rbtnelectiveNO.Checked == true))
            {
                if (clsSQLWrapper.s_blnHasConnection())
                {
                    string sql1 = "Insert_Subject";
                    List<SqlParameter> lstSPara = new List<SqlParameter>();
                    lstSPara.Add(new SqlParameter { ParameterName = "@sub_code", SqlDbType = SqlDbType.VarChar, Value = subcode });
                    lstSPara.Add(new SqlParameter { ParameterName = "@sub_name", SqlDbType = SqlDbType.VarChar, Value = subname });
                    lstSPara.Add(new SqlParameter { ParameterName = "@isElective", SqlDbType = SqlDbType.Bit, Value = elective });
                    lstSPara.Add(new SqlParameter { ParameterName = "@sem_id", SqlDbType = SqlDbType.Int, Value = cmbSemester.SelectedValue });
                    lstSPara.Add(new SqlParameter { ParameterName = "@isCommonForAll", SqlDbType = SqlDbType.Bit, Value = common });
                    lstSPara.Add(new SqlParameter { ParameterName = "@Dept_Id", SqlDbType = SqlDbType.Int, Value = cmbDepartment.SelectedValue });


                    clsSQLWrapper.runProcedure(sql1, lstSPara);

                    MessageBox.Show("Subject Added Successfully");
                    emptySubject();
                }
            }
            else
            {
                MessageBox.Show("Enter All Required Fields");
            }
        }
      
        public void emptySubject()
        {
            txtsubname.Text = "";
            textSubcode.Text = "";
            cmbSemester.DataSource = null;
            cmbDepartment.DataSource = null;
            rbtncommonYES.Checked = false;
            rbtncommonNO.Checked = false;
            rbtnelectiveYES.Checked = false;
            rbtnelectiveNO.Checked = false;

        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }


        //ADD button of room allocation
        private void button1_Click(object sender, EventArgs e)
        {

            Name = txtName.Text;
            buildingName = cmbxBuildingName.SelectedItem.ToString();
            

            //--------------------Allocate_Hostel------------------------------


            if (Name != null && cmbxBuildingName.SelectedValue != null && cmbxRoomNo.SelectedValue != null)
            {
                
                if (clsSQLWrapper.s_blnHasConnection())
                {
                    if (rbtnStud.Checked)
                        Type1="Student";
                    else if (rbtnFac.Checked)
                        Type1 = "Faculty";
                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = Name });
                    lstPara.Add(new SqlParameter { ParameterName = "@Type", SqlDbType = SqlDbType.VarChar, Value = Type1 });
                    return_person_ID = clsSQLWrapper.runProcedure("Return_Person_Id", lstPara);
                    
                }
                if (return_person_ID != 0)
                {
                    if (clsSQLWrapper.s_blnHasConnection())
                    {

                        List<SqlParameter> lstPara = new List<SqlParameter>();
                        lstPara.Add(new SqlParameter { ParameterName = "@Person_Id", SqlDbType = SqlDbType.VarChar, Value = return_person_ID });
                        lstPara.Add(new SqlParameter { ParameterName = "@Building_Name", SqlDbType = SqlDbType.VarChar, Value = cmbxBuildingName.SelectedValue });
                        lstPara.Add(new SqlParameter { ParameterName = "@RoomNo", SqlDbType = SqlDbType.Int, Value = cmbxRoomNo.SelectedValue });

                        if (rbtnStud.Checked)
                            clsSQLWrapper.runProcedure("Insert_Hostel", lstPara);
                        else if (rbtnFac.Checked)
                            clsSQLWrapper.runProcedure("Insert_Faculty", lstPara);
                    }
                    MessageBox.Show("Room Allocation Successful");
                    //func_Empty_Filled_Person_Details();
                }
                else
                {
                    MessageBox.Show("Enter correect name");
                }


            }
            else
            {
                MessageBox.Show("Incomplete Details");
            }
        }

       
        private void rbtnStud_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds4 = clsSQLWrapper.runUserQuery("Select * from Hostel where id IS NULL");

            List<Model.clsHostel> Hostels = new List<Model.clsHostel>();
            if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                {
                    Model.clsHostel Hostel = new Model.clsHostel();
                    // Hostel.Person_Id = Convert.ToInt32(ds4.Tables[0].Rows[i]["id"]);
                    Hostel.Building_Name = (ds4.Tables[0].Rows[i]["BuildingName"]).ToString();
                    Hostel.Room_No = Convert.ToInt32(ds4.Tables[0].Rows[i]["RoomNumber"]);
                    Hostel.Allocated_To = (ds4.Tables[0].Rows[i]["AllocatedTo"]).ToString();

                    lock (Hostels)
                        Hostels.Add(Hostel);
                });
            }

            cmbxBuildingName.DataSource = Hostels;
            cmbxBuildingName.DisplayMember = "Building_Name";
            cmbxBuildingName.ValueMember = "Building_Name";

            cmbxRoomNo.DataSource = Hostels;
            cmbxRoomNo.DisplayMember = "Room_No";
            cmbxRoomNo.ValueMember = "Room_No";
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds4 = clsSQLWrapper.runUserQuery("Select * from FacultyRoom where id IS NULL");

            List<Model.clsFaculty> Faculties = new List<Model.clsFaculty>();
            if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                {
                    Model.clsFaculty Faculty = new Model.clsFaculty();
                    // Hostel.Person_Id = Convert.ToInt32(ds4.Tables[0].Rows[i]["id"]);
                    Faculty.Building_Name = (ds4.Tables[0].Rows[i]["BuildingName"]).ToString();
                    Faculty.Room_No = Convert.ToInt32(ds4.Tables[0].Rows[i]["RoomNumber"]);
                    Faculty.Allocated_To = (ds4.Tables[0].Rows[i]["AllocatedTo"]).ToString();

                    lock (Faculties)
                        Faculties.Add(Faculty);
                });
            }

            cmbxBuildingName.DataSource = Faculties;
            cmbxBuildingName.DisplayMember = "Building_Name";
            cmbxBuildingName.ValueMember = "Building_Name";

            cmbxRoomNo.DataSource = Faculties;
            cmbxRoomNo.DisplayMember = "Room_No";
            cmbxRoomNo.ValueMember = "Room_No";
        }

    }
}