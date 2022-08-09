namespace Tabwindowsform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnShow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.cmbxCity = new System.Windows.Forms.ComboBox();
            this.cmbxDeptName = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.rbtnAdministrator = new System.Windows.Forms.RadioButton();
            this.rbtnFaculty = new System.Windows.Forms.RadioButton();
            this.rbtnStudent = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAddSub = new System.Windows.Forms.Button();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtncommonNO = new System.Windows.Forms.RadioButton();
            this.rbtncommonYES = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnelectiveNO = new System.Windows.Forms.RadioButton();
            this.rbtnelectiveYES = new System.Windows.Forms.RadioButton();
            this.txtsubname = new System.Windows.Forms.TextBox();
            this.textSubcode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbxRoomNo = new System.Windows.Forms.ComboBox();
            this.cmbxBuildingName = new System.Windows.Forms.ComboBox();
            this.btnAdd_Allocation_Click = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rbtnStud = new System.Windows.Forms.RadioButton();
            this.rbtnFac = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Sub_Details_Sem_wise = new System.Windows.Forms.Button();
            this.clsPersonBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.clsPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clsPersonBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Controls.Add(this.tabPage1);
            this.btnShow.Controls.Add(this.tabPage2);
            this.btnShow.Controls.Add(this.tabPage3);
            this.btnShow.Controls.Add(this.tabPage4);
            this.btnShow.Controls.Add(this.tabPage5);
            this.btnShow.Location = new System.Drawing.Point(0, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.SelectedIndex = 0;
            this.btnShow.Size = new System.Drawing.Size(608, 407);
            this.btnShow.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddPerson);
            this.tabPage1.Controls.Add(this.cmbxCity);
            this.tabPage1.Controls.Add(this.cmbxDeptName);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.txtMobile);
            this.tabPage1.Controls.Add(this.rbtnAdministrator);
            this.tabPage1.Controls.Add(this.rbtnFaculty);
            this.tabPage1.Controls.Add(this.rbtnStudent);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(249, 332);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 23);
            this.btnAddPerson.TabIndex = 17;
            this.btnAddPerson.Text = "ADD";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // cmbxCity
            // 
            this.cmbxCity.FormattingEnabled = true;
            this.cmbxCity.Location = new System.Drawing.Point(182, 279);
            this.cmbxCity.Name = "cmbxCity";
            this.cmbxCity.Size = new System.Drawing.Size(227, 21);
            this.cmbxCity.TabIndex = 16;
            // 
            // cmbxDeptName
            // 
            this.cmbxDeptName.FormattingEnabled = true;
            this.cmbxDeptName.Location = new System.Drawing.Point(182, 244);
            this.cmbxDeptName.Name = "cmbxDeptName";
            this.cmbxDeptName.Size = new System.Drawing.Size(227, 21);
            this.cmbxDeptName.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(182, 207);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(227, 20);
            this.txtAddress.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 171);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(50, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(249, 172);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(160, 20);
            this.txtMobile.TabIndex = 12;
            // 
            // rbtnAdministrator
            // 
            this.rbtnAdministrator.AutoSize = true;
            this.rbtnAdministrator.Location = new System.Drawing.Point(324, 129);
            this.rbtnAdministrator.Name = "rbtnAdministrator";
            this.rbtnAdministrator.Size = new System.Drawing.Size(85, 17);
            this.rbtnAdministrator.TabIndex = 11;
            this.rbtnAdministrator.TabStop = true;
            this.rbtnAdministrator.Text = "Administrator";
            this.rbtnAdministrator.UseVisualStyleBackColor = true;
            // 
            // rbtnFaculty
            // 
            this.rbtnFaculty.AutoSize = true;
            this.rbtnFaculty.Location = new System.Drawing.Point(250, 129);
            this.rbtnFaculty.Name = "rbtnFaculty";
            this.rbtnFaculty.Size = new System.Drawing.Size(59, 17);
            this.rbtnFaculty.TabIndex = 10;
            this.rbtnFaculty.TabStop = true;
            this.rbtnFaculty.Text = "Faculty";
            this.rbtnFaculty.UseVisualStyleBackColor = true;
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.AutoSize = true;
            this.rbtnStudent.Location = new System.Drawing.Point(182, 129);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(62, 17);
            this.rbtnStudent.TabIndex = 9;
            this.rbtnStudent.TabStop = true;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "City :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Dept_Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mobile :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(182, 87);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(227, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(182, 49);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(227, 20);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btnDisplay);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Show Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 257);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(233, 26);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnAddSub);
            this.tabPage3.Controls.Add(this.cmbSemester);
            this.tabPage3.Controls.Add(this.cmbDepartment);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.txtsubname);
            this.tabPage3.Controls.Add(this.textSubcode);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(600, 381);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Subject Add";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.Location = new System.Drawing.Point(275, 245);
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Size = new System.Drawing.Size(75, 23);
            this.btnAddSub.TabIndex = 14;
            this.btnAddSub.Text = "ADD";
            this.btnAddSub.UseVisualStyleBackColor = true;
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(202, 182);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(227, 21);
            this.cmbSemester.TabIndex = 13;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(202, 156);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(227, 21);
            this.cmbDepartment.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtncommonNO);
            this.groupBox2.Controls.Add(this.rbtncommonYES);
            this.groupBox2.Location = new System.Drawing.Point(202, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 27);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // rbtncommonNO
            // 
            this.rbtncommonNO.AutoSize = true;
            this.rbtncommonNO.Location = new System.Drawing.Point(97, 6);
            this.rbtncommonNO.Name = "rbtncommonNO";
            this.rbtncommonNO.Size = new System.Drawing.Size(39, 17);
            this.rbtncommonNO.TabIndex = 17;
            this.rbtncommonNO.TabStop = true;
            this.rbtncommonNO.Text = "No";
            this.rbtncommonNO.UseVisualStyleBackColor = true;
            this.rbtncommonNO.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // rbtncommonYES
            // 
            this.rbtncommonYES.AutoSize = true;
            this.rbtncommonYES.Location = new System.Drawing.Point(6, 10);
            this.rbtncommonYES.Name = "rbtncommonYES";
            this.rbtncommonYES.Size = new System.Drawing.Size(43, 17);
            this.rbtncommonYES.TabIndex = 16;
            this.rbtncommonYES.TabStop = true;
            this.rbtncommonYES.Text = "Yes";
            this.rbtncommonYES.UseVisualStyleBackColor = true;
            this.rbtncommonYES.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnelectiveNO);
            this.groupBox1.Controls.Add(this.rbtnelectiveYES);
            this.groupBox1.Location = new System.Drawing.Point(202, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 29);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rbtnelectiveNO
            // 
            this.rbtnelectiveNO.AutoSize = true;
            this.rbtnelectiveNO.Location = new System.Drawing.Point(97, 7);
            this.rbtnelectiveNO.Name = "rbtnelectiveNO";
            this.rbtnelectiveNO.Size = new System.Drawing.Size(39, 17);
            this.rbtnelectiveNO.TabIndex = 15;
            this.rbtnelectiveNO.TabStop = true;
            this.rbtnelectiveNO.Text = "No";
            this.rbtnelectiveNO.UseVisualStyleBackColor = true;
            // 
            // rbtnelectiveYES
            // 
            this.rbtnelectiveYES.AutoSize = true;
            this.rbtnelectiveYES.Location = new System.Drawing.Point(6, 7);
            this.rbtnelectiveYES.Name = "rbtnelectiveYES";
            this.rbtnelectiveYES.Size = new System.Drawing.Size(43, 17);
            this.rbtnelectiveYES.TabIndex = 14;
            this.rbtnelectiveYES.TabStop = true;
            this.rbtnelectiveYES.Text = "Yes";
            this.rbtnelectiveYES.UseVisualStyleBackColor = true;
            // 
            // txtsubname
            // 
            this.txtsubname.Location = new System.Drawing.Point(202, 58);
            this.txtsubname.Name = "txtsubname";
            this.txtsubname.Size = new System.Drawing.Size(227, 20);
            this.txtsubname.TabIndex = 7;
            // 
            // textSubcode
            // 
            this.textSubcode.Location = new System.Drawing.Point(202, 25);
            this.textSubcode.Name = "textSubcode";
            this.textSubcode.Size = new System.Drawing.Size(227, 20);
            this.textSubcode.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(96, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Semester";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Department";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(96, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Is common for all";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Is Elective";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Subject Name";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Subject Code";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rbtnFac);
            this.tabPage4.Controls.Add(this.rbtnStud);
            this.tabPage4.Controls.Add(this.cmbxRoomNo);
            this.tabPage4.Controls.Add(this.cmbxBuildingName);
            this.tabPage4.Controls.Add(this.btnAdd_Allocation_Click);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.txtName);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(600, 381);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Room Allocation";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmbxRoomNo
            // 
            this.cmbxRoomNo.FormattingEnabled = true;
            this.cmbxRoomNo.Location = new System.Drawing.Point(151, 210);
            this.cmbxRoomNo.Name = "cmbxRoomNo";
            this.cmbxRoomNo.Size = new System.Drawing.Size(188, 21);
            this.cmbxRoomNo.TabIndex = 11;
            // 
            // cmbxBuildingName
            // 
            this.cmbxBuildingName.FormattingEnabled = true;
            this.cmbxBuildingName.Location = new System.Drawing.Point(152, 169);
            this.cmbxBuildingName.Name = "cmbxBuildingName";
            this.cmbxBuildingName.Size = new System.Drawing.Size(187, 21);
            this.cmbxBuildingName.TabIndex = 10;
            // 
            // btnAdd_Allocation_Click
            // 
            this.btnAdd_Allocation_Click.Location = new System.Drawing.Point(197, 262);
            this.btnAdd_Allocation_Click.Name = "btnAdd_Allocation_Click";
            this.btnAdd_Allocation_Click.Size = new System.Drawing.Size(75, 23);
            this.btnAdd_Allocation_Click.TabIndex = 9;
            this.btnAdd_Allocation_Click.Text = "ADD";
            this.btnAdd_Allocation_Click.UseVisualStyleBackColor = true;
            this.btnAdd_Allocation_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 177);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Building Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Room No";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(152, 131);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(187, 20);
            this.txtName.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_Sub_Details_Sem_wise);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(600, 381);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Subject Details";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rbtnStud
            // 
            this.rbtnStud.AutoSize = true;
            this.rbtnStud.Location = new System.Drawing.Point(57, 71);
            this.rbtnStud.Name = "rbtnStud";
            this.rbtnStud.Size = new System.Drawing.Size(62, 17);
            this.rbtnStud.TabIndex = 16;
            this.rbtnStud.TabStop = true;
            this.rbtnStud.Text = "Student";
            this.rbtnStud.UseVisualStyleBackColor = true;
            this.rbtnStud.CheckedChanged += new System.EventHandler(this.rbtnStud_CheckedChanged);
            // 
            // rbtnFac
            // 
            this.rbtnFac.AutoSize = true;
            this.rbtnFac.Location = new System.Drawing.Point(254, 71);
            this.rbtnFac.Name = "rbtnFac";
            this.rbtnFac.Size = new System.Drawing.Size(59, 17);
            this.rbtnFac.TabIndex = 17;
            this.rbtnFac.TabStop = true;
            this.rbtnFac.Text = "Faculty";
            this.rbtnFac.UseVisualStyleBackColor = true;
            this.rbtnFac.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Department_wise";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_Sub_Details_Sem_wise
            // 
            this.btn_Sub_Details_Sem_wise.Location = new System.Drawing.Point(336, 16);
            this.btn_Sub_Details_Sem_wise.Name = "btn_Sub_Details_Sem_wise";
            this.btn_Sub_Details_Sem_wise.Size = new System.Drawing.Size(104, 35);
            this.btn_Sub_Details_Sem_wise.TabIndex = 1;
            this.btn_Sub_Details_Sem_wise.Text = "Semester_wise";
            this.btn_Sub_Details_Sem_wise.UseVisualStyleBackColor = true;
            // 
            // clsPersonBindingSource1
            // 
            this.clsPersonBindingSource1.DataSource = typeof(Tabwindowsform.Model.clsPerson);
            // 
            // clsPersonBindingSource
            // 
            this.clsPersonBindingSource.DataSource = typeof(Tabwindowsform.Model.clsPerson);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShow);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.btnShow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clsPersonBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsPersonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl btnShow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RadioButton rbtnAdministrator;
        private System.Windows.Forms.RadioButton rbtnFaculty;
        private System.Windows.Forms.RadioButton rbtnStudent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ComboBox cmbxCity;
        private System.Windows.Forms.ComboBox cmbxDeptName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtsubname;
        private System.Windows.Forms.TextBox textSubcode;
        private System.Windows.Forms.RadioButton rbtncommonNO;
        private System.Windows.Forms.RadioButton rbtncommonYES;
        private System.Windows.Forms.RadioButton rbtnelectiveNO;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnelectiveYES;
        private System.Windows.Forms.Button btnAddSub;
        private System.Windows.Forms.Button btnAdd_Allocation_Click;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.BindingSource clsPersonBindingSource;
        private System.Windows.Forms.BindingSource clsPersonBindingSource1;
        private System.Windows.Forms.ComboBox cmbxRoomNo;
        private System.Windows.Forms.ComboBox cmbxBuildingName;
        private System.Windows.Forms.RadioButton rbtnFac;
        private System.Windows.Forms.RadioButton rbtnStud;
        private System.Windows.Forms.Button btn_Sub_Details_Sem_wise;
        private System.Windows.Forms.Button button1;
    }
}

