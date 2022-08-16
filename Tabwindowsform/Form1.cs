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

        int flag = 0;
        string currBuildingName;
        string prevBuildingName;

        //ELECTIVE subject Allocation Variables
        int return_person_ID2;
        int flag2=0;
        string subCodeSelected;

        //Subject Allocation Tab Variables
        string currDept;
        string prevDept;
        string currSem;
        string prevSem;
        int flagShowRoom=0;

        //Subject De-Allocation Tab Variables
        int currPersonId;
        int prevPersonId;

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
            depts = depts.OrderBy(x => x.deptName).ToList();
            //-----Tab1 dept
            cmbxDeptName.DataSource = depts;
            cmbxDeptName.DisplayMember = "deptName";
            cmbxDeptName.ValueMember = "dept_Id";

            //-----Tab3 dept
            cmbDepartment.DataSource = depts;
            cmbDepartment.DisplayMember = "deptName";
            cmbDepartment.ValueMember = "dept_Id";

            //-----Tab4 dept
            cmbxDept_Name.DataSource = depts;
            cmbxDept_Name.DisplayMember = "deptName";
            cmbxDept_Name.ValueMember = "dept_Id";
            
            //-----Tab6 
            cmbxDept__Name.DataSource = depts;
            cmbxDept__Name.DisplayMember = "deptName";
            cmbxDept__Name.ValueMember = "dept_Id";

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
            cities = cities.OrderBy(x => x.cityName).ToList();
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
            Sems = Sems.OrderBy(x => x.sem_Name).ToList();
            //Tab-3
            cmbSemester.DataSource = Sems;
            cmbSemester.DisplayMember = "sem_Name";
            cmbSemester.ValueMember = "sem_id";

            //Tab-4
            cmbxSem_Name.DataSource = Sems;
            cmbxSem_Name.DisplayMember = "sem_Name";
            cmbxSem_Name.ValueMember = "sem_id";

            //Tab-6
            cmbxSem__Name.DataSource = Sems;
            cmbxSem__Name.DisplayMember = "sem_Name";
            cmbxSem__Name.ValueMember = "sem_id";


            
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
            //query = "select * from Address inner join Person on Address.person_Id=Person.person_Id inner join City on City.c_ID=Address.c_Id left join Department on Department.dept_Id = Person.dept_Id; ";
            query = "select * from Person " +
                "inner join Address on Address.person_Id=Person.person_Id " +
                "inner join City on City.c_ID=Address.c_Id " +
                "left join Department on Department.dept_Id = Person.dept_Id;";
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
            currBuildingName= cmbxBuildingName.SelectedItem.ToString();
            if (currBuildingName == prevBuildingName)
            { 
                buildingName = currBuildingName;
                Name = cmbxFirstName.SelectedItem.ToString();

                //--------------------Allocate_Hostel------------------------------

                if (cmbxFirstName.SelectedValue != null && cmbxBuildingName.SelectedValue != null && cmbxRoomNo.SelectedValue != null)
                {

                    if (clsSQLWrapper.s_blnHasConnection())
                    {
                        if (rbtnStud.Checked)
                            Type1 = "Student";
                        else if (rbtnFac.Checked)
                            Type1 = "Faculty";
                        List<SqlParameter> lstPara = new List<SqlParameter>();
                        lstPara.Add(new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = cmbxFirstName.SelectedValue });
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

                            List<SqlParameter> lst_Para = new List<SqlParameter>();
                            lst_Para.Add(new SqlParameter { ParameterName = "@Search_Id", SqlDbType = SqlDbType.Int, Value = return_person_ID });
                            int flag;
                            if (rbtnStud.Checked)
                            {
                                flag = clsSQLWrapper.runProcedure("spCheckId_in_Hostel", lst_Para);
                                //when person_Id doesn't exist in Hostel
                                if (flag == 0)
                                {
                                    clsSQLWrapper.runProcedure("Insert_Hostel", lstPara);
                                    MessageBox.Show("Room Allocation Successful");
                                }

                                else
                                {
                                    MessageBox.Show("Room Already Allocated for selected person\nSelect New Person");
                                }

                            }

                            else if (rbtnFac.Checked)
                            {
                                flag = clsSQLWrapper.runProcedure("spCheckId_in_Faculty", lst_Para);
                                //when person_Id doesn't exist in Faculty
                                if (flag == 0)
                                {
                                    clsSQLWrapper.runProcedure("Insert_Faculty", lstPara);
                                    MessageBox.Show("Room Allocation Successful");
                                }
                                else
                                {
                                    MessageBox.Show("Room Already Allocated for selected person\nSelect New Person");
                            
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incomplete Details");
                }
            }
            else
            {
                MessageBox.Show("You have changed your Building Name \nClick Next to refresh and Try Again");
            }
        }

       
        private void rbtnStud_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewShowroom.DataSource = null;
            dataGridViewShowroom.Rows.Clear();
            //---------------------FirstName FROM Person Table

            //DataSet ds6 = clsSQLWrapper.runUserQuery("Select * from Person where type='Student';");
            string query = "Select * from Person " +
                "where type='Student' " +
                "and NOT exists(select id from Hostel where Hostel.id=Person.person_Id);";
            DataSet ds6 = clsSQLWrapper.runUserQuery(query);
            List<Model.clsPerson> persons = new List<Model.clsPerson>();
            if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds6.Tables[0].Rows.Count, i =>
                {
                    Model.clsPerson person = new Model.clsPerson();
                    person.FirstName = ds6.Tables[0].Rows[i]["firstName"].ToString();
                   
                    lock (persons)
                        persons.Add(person);
                });
            }
            
            cmbxFirstName.DataSource = persons.OrderBy(x => x.FirstName).ToList();
            cmbxFirstName.DisplayMember = "firstName";
            cmbxFirstName.ValueMember = "firstName";


            //---------------------Building Name And Room no from Hostel
            DataSet ds4 = clsSQLWrapper.runUserQuery("Select * from Hostel where id IS NULL");

            List<Model.clsHostel> Hostels = new List<Model.clsHostel>();
            if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                {
                    Model.clsHostel Hostel = new Model.clsHostel();
                    Hostel.Building_Name = (ds4.Tables[0].Rows[i]["BuildingName"]).ToString();

                    lock (Hostels)
                        Hostels.Add(Hostel);
                });
            }

            List<string> buildingNameHostel = Hostels.Select(s => s.Building_Name).Distinct().ToList();
            buildingNameHostel.Sort();
            cmbxBuildingName.DataSource = buildingNameHostel;

        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewShowroom.DataSource = null;
            dataGridViewShowroom.Rows.Clear();
            //---------------------FirstName FROM Person Table
            string query = "Select * from Person " +
                "where type='Faculty' " +
                "and NOT exists(select id from FacultyRoom where FacultyRoom.id=Person.person_Id);";
            //DataSet ds6 = clsSQLWrapper.runUserQuery("Select * from Person where type='Faculty';");
            DataSet ds6 = clsSQLWrapper.runUserQuery(query);
            List<Model.clsPerson> persons = new List<Model.clsPerson>();
            if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds6.Tables[0].Rows.Count, i =>
                {
                    Model.clsPerson person = new Model.clsPerson();
                    person.FirstName = ds6.Tables[0].Rows[i]["firstName"].ToString();
                    lock (persons)
                        persons.Add(person);
                });
            }

            cmbxFirstName.DataSource = persons.OrderBy(x => x.FirstName).ToList();
            cmbxFirstName.DisplayMember = "firstName";
            cmbxFirstName.ValueMember = "firstName";


            //---------------------Building Name And Room no from Faculty
            DataSet ds4 = clsSQLWrapper.runUserQuery("Select * from FacultyRoom where id IS NULL");

            List<Model.clsFaculty> Faculties = new List<Model.clsFaculty>();
            if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                {
                    Model.clsFaculty Faculty = new Model.clsFaculty();
                    Faculty.Building_Name = (ds4.Tables[0].Rows[i]["BuildingName"]).ToString();

                    lock (Faculties)
                        Faculties.Add(Faculty);
                });
            }
            List<string> buildingNameFaculty = Faculties.Select(s => s.Building_Name).Distinct().ToList();
            buildingNameFaculty.Sort();
            cmbxBuildingName.DataSource = buildingNameFaculty;

            //----------------------
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            funcDisplayAllSubjects();
        }
        public void funcDisplayAllSubjects()
        {
            //----Subject Table-----
            string QueryForSubject;

            QueryForSubject = "Select sub_code,Department.dept_Id,sub_name,deptName,sem_Name,isElective,isCommonForAll " +
                "from Subject inner join Department on Subject.dept_Id = Department.dept_Id " +
                "inner join Semester on Subject.sem_id = Semester.sem_id;";

            DataSet dsData2 = clsSQLWrapper.runUserQuery(QueryForSubject);

            List<Model.clsSubject> subject = new List<Model.clsSubject>();
            Parallel.For(0, dsData2.Tables[0].Rows.Count, i =>
            {
                Model.clsPerson person1 = new Model.clsPerson();
                Model.clsDepartment dept1 = new Model.clsDepartment();
                Model.clsSubject sub = new Model.clsSubject();
                Model.clsSemester semester = new Model.clsSemester();

                sub.sub_code = dsData2.Tables[0].Rows[i]["sub_code"].ToString();
                sub.sub_name = dsData2.Tables[0].Rows[i]["sub_name"].ToString();
                sub.isElective = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isElective"]);

                dept1.dept_Id = Convert.ToInt32(dsData2.Tables[0].Rows[i]["dept_Id"]);
                dept1.deptName = dsData2.Tables[0].Rows[i]["deptName"].ToString();

                semester.sem_Name = dsData2.Tables[0].Rows[i]["sem_Name"].ToString();
                sub.isCommonForAll = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isCommonForAll"]);
                sub.sub_sem_name = semester.sem_Name;
                sub.sub_dept_name = dept1.deptName;
               
                lock (subject)
                    subject.Add(sub);
            });
            
            dataGridViewSou.DataSource = subject.OrderBy(x => x.sub_dept_name).ToList(); ;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            funcDisplaySubSemDeptWise();
        }
        public void funcDisplaySubSemDeptWise()
        {
            int intSelectedDept = Convert.ToInt32(cmbxDept_Name.SelectedValue);
            int intSelectedSem = Convert.ToInt32(cmbxSem_Name.SelectedValue);
            string QueryForSubject;

            QueryForSubject = "Select_Sub_Dept_Sem_Wise";

            List<SqlParameter> lstPara = new List<SqlParameter>();
            lstPara.Add(new SqlParameter { ParameterName = "@Dept_Id", SqlDbType = SqlDbType.VarChar, Value = intSelectedDept });
            lstPara.Add(new SqlParameter { ParameterName = "@Sem_Id", SqlDbType = SqlDbType.VarChar, Value = intSelectedSem });

            DataSet dsData2 = clsSQLWrapper.runProcedureUser(QueryForSubject,lstPara);

            List<Model.clsSubject> subject = new List<Model.clsSubject>();
            Parallel.For(0, dsData2.Tables[0].Rows.Count, i =>
            {
                Model.clsPerson person1 = new Model.clsPerson();
                Model.clsDepartment dept1 = new Model.clsDepartment();
                Model.clsSubject sub = new Model.clsSubject();
                Model.clsSemester semester = new Model.clsSemester();

                dept1.deptName = dsData2.Tables[0].Rows[i]["deptName"].ToString();
                sub.sub_dept_name = dept1.deptName;
                sub.sub_code = dsData2.Tables[0].Rows[i]["sub_code"].ToString();
                sub.sub_name = dsData2.Tables[0].Rows[i]["sub_name"].ToString();
                
                sub.isElective = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isElective"]);
                semester.sem_Name = dsData2.Tables[0].Rows[i]["sem_Name"].ToString();
                sub.isCommonForAll = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isCommonForAll"]);
                sub.sub_sem_name = semester.sem_Name;
                

                lock (subject)
                    subject.Add(sub);
            });

            dataGridViewSou.DataSource = subject.OrderBy(x => x.sub_name).ToList(); ;

        }

        private void cmbxDept_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            flagShowRoom = 0;
            if (rbtnStud.Checked)
                funcDisplayHostelRoom();
            else if (rbtnFac.Checked)
                funcDisplayFacultylRoom();
            else
            {
                MessageBox.Show("Select \"Student\" or \"Faculty\"");
            }
        }
        public void funcDisplayHostelRoom()
        {
            //----Hostel Table-----
            string QueryForHostelDetails;

            QueryForHostelDetails = "Select id,firstName,lastName,BuildingName,RoomNumber,AllocatedTo " +
                "from Hostel inner join Person on Hostel.id = Person.person_Id;";

            DataSet dsData2 = clsSQLWrapper.runUserQuery(QueryForHostelDetails);

            List<Model.clsHostel> lstHostel = new List<Model.clsHostel>();
            Parallel.For(0, dsData2.Tables[0].Rows.Count, i =>
            {
                Model.clsPerson person = new Model.clsPerson();
                Model.clsHostel Hostel=new Model.clsHostel();

                person.FirstName = dsData2.Tables[0].Rows[i]["firstName"].ToString();
                person.LastName = dsData2.Tables[0].Rows[i]["lastName"].ToString();

                Hostel.Person_Id = Convert.ToInt32(dsData2.Tables[0].Rows[i]["id"]);
                Hostel.Building_Name = dsData2.Tables[0].Rows[i]["BuildingName"].ToString();
                Hostel.Room_No = Convert.ToInt32(dsData2.Tables[0].Rows[i]["RoomNumber"]);
                Hostel.Allocated_To = dsData2.Tables[0].Rows[i]["AllocatedTo"].ToString();

                Hostel.FullName = person.FirstName + " " + person.LastName;

                lock (lstHostel)
                    lstHostel.Add(Hostel);
            });
            if(flagShowRoom == 0)
                dataGridViewShowroom.DataSource = lstHostel.OrderBy(x => x.Person_Id).ToList();
            else
            dataGridView3.DataSource = lstHostel.OrderBy(x => x.Person_Id).ToList();

        }
        public void funcDisplayFacultylRoom()
        {
            //----Facullty Table-----
            string QueryForHostelDetails;

            QueryForHostelDetails = "Select Id,firstName,lastName,BuildingName,RoomNumber,AllocatedTo " +
                "from FacultyRoom inner join Person on FacultyRoom.id = Person.person_Id;";

            DataSet dsData2 = clsSQLWrapper.runUserQuery(QueryForHostelDetails);

            List<Model.clsHostel> lstHostel = new List<Model.clsHostel>();
            Parallel.For(0, dsData2.Tables[0].Rows.Count, i =>
            {
                Model.clsPerson person = new Model.clsPerson();
                Model.clsHostel Hostel = new Model.clsHostel();

                person.FirstName = dsData2.Tables[0].Rows[i]["firstName"].ToString();
                person.LastName = dsData2.Tables[0].Rows[i]["lastName"].ToString();

                Hostel.Person_Id = Convert.ToInt32(dsData2.Tables[0].Rows[i]["id"]);
                Hostel.Building_Name = dsData2.Tables[0].Rows[i]["BuildingName"].ToString();
                Hostel.Room_No = Convert.ToInt32(dsData2.Tables[0].Rows[i]["RoomNumber"]);
                Hostel.Allocated_To = dsData2.Tables[0].Rows[i]["AllocatedTo"].ToString();

                Hostel.FullName = person.FirstName + " " + person.LastName;

                lock (lstHostel)
                    lstHostel.Add(Hostel);
            });
            if (flagShowRoom == 0)
                dataGridViewShowroom.DataSource = lstHostel.OrderBy(x => x.Person_Id).ToList();
            else
            dataGridView3.DataSource = lstHostel.OrderBy(x => x.Person_Id).ToList();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnAddElectiveSub_Click(object sender, EventArgs e)
        {
            //Dept and Sem value while clicking Elective Add button 
            currDept = cmbxDept__Name.SelectedValue.ToString();
            currSem = cmbxSem__Name.SelectedValue.ToString();
            if (currDept == prevDept && currSem == prevSem)
            {

                if (clsSQLWrapper.s_blnHasConnection())
                {
                    string query = "Insert_Elective_Subject";
                    List<SqlParameter> lstSPara = new List<SqlParameter>();
                    lstSPara.Add(new SqlParameter { ParameterName = "@person_ID", SqlDbType = SqlDbType.Int, Value = cmbx__FirstName.SelectedValue });
                    lstSPara.Add(new SqlParameter { ParameterName = "@sub_code", SqlDbType = SqlDbType.VarChar, Value = cmbxElecSub.SelectedValue });

                    //Checks If Elective subject already alloted to the person
                    int checkIfExist = clsSQLWrapper.runProcedure(query, lstSPara);
                    if (checkIfExist == 0)
                    {
                        MessageBox.Show("Elective Subject already added for the person");
                    }
                    else if (checkIfExist == 1)
                    {
                        MessageBox.Show("Elective Subject added Successfully for the person");
                    }
                }
            }
            else
            {
                MessageBox.Show("You have changed your Dept or Sem \nClick Next to refresh and Try Again");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbxBuildingName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnToShowName_Click(object sender, EventArgs e)
        {
            //Dept and Sem value while clicking Next button
            prevDept = cmbxDept__Name.SelectedValue.ToString();
            prevSem = cmbxSem__Name.SelectedValue.ToString();

            if (currDept != prevDept || currSem != prevSem)
            {
                //Clear DataGridView
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
            }

            //---------------------FirstName FROM Person Table for Subject Allocation
            if (clsSQLWrapper.s_blnHasConnection())
            {

                List<SqlParameter> lstPara = new List<SqlParameter>();
                lstPara.Add(new SqlParameter { ParameterName = "@dept_Id", SqlDbType = SqlDbType.Int, Value = cmbxDept__Name.SelectedValue });

                string query = "spName_WRT_Dept";
                DataSet ds9 = clsSQLWrapper.runProcedureUser(query, lstPara);

                List<Model.clsPerson> persons = new List<Model.clsPerson>();
                if (ds9 != null && ds9.Tables[0].Rows.Count > 0)
                {

                    Parallel.For(0, ds9.Tables[0].Rows.Count, i =>
                    {
                        Model.clsPerson person = new Model.clsPerson();
                        person.FirstName = ds9.Tables[0].Rows[i]["firstName"].ToString();
                        person.person_Id = Convert.ToInt32(ds9.Tables[0].Rows[i]["person_Id"]);


                        lock (persons)
                            persons.Add(person);
                    });
                }

                cmbx__FirstName.DataSource = persons.OrderBy(x=>x.FirstName).ToList();
                cmbx__FirstName.DisplayMember = "firstName";
                cmbx__FirstName.ValueMember = "person_Id";
          

                //---------------------Elective Subjects FROM Subject Table for Subject Allocation
            
                List<SqlParameter> lstPara1 = new List<SqlParameter>();
                lstPara1.Add(new SqlParameter { ParameterName = "@Sem_Id", SqlDbType = SqlDbType.Int, Value = cmbxSem__Name.SelectedValue });
                lstPara1.Add(new SqlParameter { ParameterName = "@Dept_Id", SqlDbType = SqlDbType.Int, Value = cmbxDept__Name.SelectedValue });
                query = "spElective_subCode_WRT_Dept_Sem";
                DataSet ds11 = clsSQLWrapper.runProcedureUser(query, lstPara1);

                List<Model.clsSubject> Subjects = new List<Model.clsSubject>();
                if (ds11 != null && ds11.Tables[0].Rows.Count > 0)
                {

                    Parallel.For(0, ds11.Tables[0].Rows.Count, i =>
                    {
                        Model.clsSubject subject = new Model.clsSubject();
                        subject.sub_name = ds11.Tables[0].Rows[i]["sub_name"].ToString();
                        subject.sub_code = ds11.Tables[0].Rows[i]["sub_code"].ToString();

                        lock (Subjects)
                            Subjects.Add(subject);
                    });
                }

                cmbxElecSub.DataSource = Subjects.OrderBy(x => x.sub_name).ToList(); ;
                cmbxElecSub.DisplayMember = "sub_name";
                cmbxElecSub.ValueMember = "sub_code";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag = 1;
            prevBuildingName = cmbxBuildingName.SelectedValue.ToString();
            if (clsSQLWrapper.s_blnHasConnection())
            {
                if (rbtnStud.Checked)
                {
                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@Building_Name", SqlDbType = SqlDbType.VarChar, Value = cmbxBuildingName.SelectedValue });

                    string query = "sp_RoomNoHostel_WRT_BuildingName";
                    DataSet ds4 = clsSQLWrapper.runProcedureUser(query, lstPara);


                    List<Model.clsHostel> Hostels = new List<Model.clsHostel>();
                    if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
                    {

                        Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                        {
                            Model.clsHostel Hostel = new Model.clsHostel();
                            Hostel.Room_No = Convert.ToInt32(ds4.Tables[0].Rows[i]["RoomNumber"]);

                            lock (Hostels)
                                Hostels.Add(Hostel);
                        });
                    }


                    cmbxRoomNo.DataSource = Hostels.OrderBy(x=>x.Room_No).ToList();
                    cmbxRoomNo.DisplayMember = "Room_No";
                    cmbxRoomNo.ValueMember = "Room_No";
                }
                else if (rbtnFac.Checked)
                {
                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@Building_Name", SqlDbType = SqlDbType.VarChar, Value = cmbxBuildingName.SelectedValue });

                    string query = "sp_RoomNoFaculty_WRT_BuildingName";
                    DataSet ds4 = clsSQLWrapper.runProcedureUser(query, lstPara);


                    List<Model.clsFaculty> faculties = new List<Model.clsFaculty>();
                    if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
                    {

                        Parallel.For(0, ds4.Tables[0].Rows.Count, i =>
                        {
                            Model.clsFaculty faculty = new Model.clsFaculty();
                            faculty.Room_No = Convert.ToInt32(ds4.Tables[0].Rows[i]["RoomNumber"]);

                            lock (faculties)
                                faculties.Add(faculty);
                        });
                    }


                    cmbxRoomNo.DataSource = faculties.OrderBy(x => x.Room_No).ToList();
                    cmbxRoomNo.DisplayMember = "Room_No";
                    cmbxRoomNo.ValueMember = "Room_No";
                }

            } 
        }

        private void cmbx__FirstName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbxFirstName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNonElective_Click(object sender, EventArgs e)
        {
            //Dept and Sem value while clicking Non-Elective Add button 
            currDept = cmbxDept__Name.SelectedValue.ToString();
            currSem = cmbxSem__Name.SelectedValue.ToString();
            if(currDept==prevDept && currSem==prevSem)
            {
                List<SqlParameter> lstPara = new List<SqlParameter>();
                lstPara.Add(new SqlParameter { ParameterName = "@Dept_Id", SqlDbType = SqlDbType.Int, Value = cmbxDept__Name.SelectedValue });
                lstPara.Add(new SqlParameter { ParameterName = "@Sem_Id", SqlDbType = SqlDbType.Int, Value = cmbxSem__Name.SelectedValue });

                string query = "sp_Non_Elective_subCode_WRT_Dept_Sem";
                DataSet dsData = clsSQLWrapper.runProcedureUser(query, lstPara);
                int checkIfExist = 1;
                foreach (DataRow dr in dsData.Tables[0].Rows)
                {
                    string toInsert_Sub_code = (string)dr[0];
                    string query2 = "Insert_non_Elective_Subject";
                    List<SqlParameter> lstSPara = new List<SqlParameter>();
                    lstSPara.Add(new SqlParameter { ParameterName = "@person_ID", SqlDbType = SqlDbType.Int, Value = cmbx__FirstName.SelectedValue });
                    lstSPara.Add(new SqlParameter { ParameterName = "@sub_code", SqlDbType = SqlDbType.VarChar, Value = toInsert_Sub_code });

                    //Checks If Elective subject already alloted to the person
                    if (checkIfExist == 1)
                        checkIfExist = clsSQLWrapper.runProcedure(query2, lstSPara);
                    else
                        break;
                }
                if (checkIfExist == 0)
                {
                    MessageBox.Show("Non-Elective Subjects already added");
                }
                else
                {
                    MessageBox.Show("Non-Elective Subjects succesfully added");
                }
            }
            else
            {
                MessageBox.Show("You have changed your Dept or Sem \nClick Next to refresh and Try Again");
            }


        }

        private void cmbxDept__Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            funcDisplay_person_Sub();
        }
        public void funcDisplay_person_Sub()
        {
            //Dept and Sem value while clicking Show button 
            currDept = cmbxDept__Name.SelectedValue.ToString();
            currSem = cmbxSem__Name.SelectedValue.ToString();
            if (currDept == prevDept && currSem == prevSem)
            {
                int intSelectedDept = Convert.ToInt32(cmbxDept__Name.SelectedValue);
                int intSelectedSem = Convert.ToInt32(cmbxSem__Name.SelectedValue);
                string QueryForPersonSubject;

                QueryForPersonSubject = "sp_Select_Person_Sub";

                List<SqlParameter> lstPara = new List<SqlParameter>();
                lstPara.Add(new SqlParameter { ParameterName = "@Dept_Id", SqlDbType = SqlDbType.Int, Value = intSelectedDept });
                lstPara.Add(new SqlParameter { ParameterName = "@Sem_Id", SqlDbType = SqlDbType.Int, Value = intSelectedSem });
                lstPara.Add(new SqlParameter { ParameterName = "@Person_Id", SqlDbType = SqlDbType.Int, Value = cmbx__FirstName.SelectedValue });

                DataSet dsData2 = clsSQLWrapper.runProcedureUser(QueryForPersonSubject, lstPara);

                List<Model.clsSubject> subject = new List<Model.clsSubject>();
                Parallel.For(0, dsData2.Tables[0].Rows.Count, i =>
                {
                    Model.clsPerson person1 = new Model.clsPerson();
                    Model.clsDepartment dept1 = new Model.clsDepartment();
                    Model.clsSubject sub = new Model.clsSubject();
                    Model.clsSemester semester = new Model.clsSemester();
                    Model.clsStudySub subStudy = new Model.clsStudySub();

                    dept1.deptName = dsData2.Tables[0].Rows[i]["deptName"].ToString();
                    sub.sub_dept_name = dept1.deptName;
                    sub.sub_code = dsData2.Tables[0].Rows[i]["sub_code"].ToString();
                    sub.sub_name = dsData2.Tables[0].Rows[i]["sub_name"].ToString();

                    sub.isElective = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isElective"]);
                    semester.sem_Name = dsData2.Tables[0].Rows[i]["sem_Name"].ToString();
                    sub.isCommonForAll = Convert.ToBoolean(dsData2.Tables[0].Rows[i]["isCommonForAll"]);
                    sub.sub_sem_name = semester.sem_Name;


                    lock (subject)
                        subject.Add(sub);
                });

                dataGridView2.DataSource = subject;
            }
            else
            {
                MessageBox.Show("You have changed your Dept or Sem \nClick Next to refresh and Try Again");
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMobile.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtMobile.Text = txtMobile.Text.Remove(txtMobile.Text.Length - 1);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();

            //---------------------FirstName FROM Person Table
            string query = "Select * from Person " +
                "where type='Student' " +
                "and exists(select id from Hostel where Hostel.id=Person.person_Id);";
            DataSet ds6 = clsSQLWrapper.runUserQuery(query);
            List<Model.clsPerson> persons = new List<Model.clsPerson>();
            if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds6.Tables[0].Rows.Count, i =>
                {
                    Model.clsPerson person = new Model.clsPerson();
                    person.FirstName = ds6.Tables[0].Rows[i]["firstName"].ToString();
                    person.person_Id = Convert.ToInt32(ds6.Tables[0].Rows[i]["person_Id"]);

                    lock (persons)
                        persons.Add(person);
                });
            }

            cmbxDeAll_FirstName.DataSource = persons.OrderBy(x => x.FirstName).ToList();
            cmbxDeAll_FirstName.DisplayMember = "firstName";
            cmbxDeAll_FirstName.ValueMember = "person_Id";

        }

        private void rbtnFaculty2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            //---------------------FirstName FROM Person Table
            string query = "Select * from Person " +
                "where type='Faculty' " +
                "and exists(select id from FacultyRoom where FacultyRoom.id=Person.person_Id);";


            DataSet ds6 = clsSQLWrapper.runUserQuery(query);
            List<Model.clsPerson> persons = new List<Model.clsPerson>();
            if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
            {

                Parallel.For(0, ds6.Tables[0].Rows.Count, i =>
                {
                    Model.clsPerson person = new Model.clsPerson();
                    person.FirstName = ds6.Tables[0].Rows[i]["firstName"].ToString();
                    person.person_Id = Convert.ToInt32(ds6.Tables[0].Rows[i]["person_Id"]);
                    lock (persons)
                        persons.Add(person);
                });
            }

            cmbxDeAll_FirstName.DataSource = persons.OrderBy(x => x.FirstName).ToList();
            cmbxDeAll_FirstName.DisplayMember = "firstName";
            cmbxDeAll_FirstName.ValueMember = "person_Id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flagShowRoom = 1;
            if (rbtnStudent2.Checked)
                funcDisplayHostelRoom();
            else if (rbtnFaculty2.Checked)
                funcDisplayFacultylRoom();
            else
            {
                MessageBox.Show("Select \"Student\" or \"Faculty\"");
            }
        }

        private void btn_Deallocate_Click(object sender, EventArgs e)
        {

            if (rbtnStudent2.Checked || rbtnFaculty2.Checked)
            {
                currPersonId = Convert.ToInt32(cmbxDeAll_FirstName.SelectedValue);
                if (currPersonId != prevPersonId)
                {
                    string query = "";

                    List<SqlParameter> lstPara = new List<SqlParameter>();
                    lstPara.Add(new SqlParameter { ParameterName = "@Person_Id", SqlDbType = SqlDbType.Int, Value = cmbxDeAll_FirstName.SelectedValue });
                    if (rbtnStudent2.Checked)
                    {
                        query = "sp_Deallocate_Hostel";
                    }
                    else if (rbtnFaculty2.Checked)
                    {
                        query = "sp_Deallocate_Faculty";
                    }
                    DataSet dsData2 = clsSQLWrapper.runProcedureUser(query, lstPara);
                    if (dsData2 != null)
                    {
                        MessageBox.Show("De-Allocation Successful");
                        prevPersonId = Convert.ToInt32(cmbxDeAll_FirstName.SelectedValue);
                    }
                }
                else
                {
                    MessageBox.Show("Person Already De_Allocated\nClick Faculty and then Student to refresh");
                }

            }
            else
            {
                MessageBox.Show("Select \"Student\" or \"Faculty\"");
            }

            }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
    }
}
