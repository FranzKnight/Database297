using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeRegistration
{
    public partial class Form1 : Form
    {

        RegistrationEntities RegistrationEntities;
        public Form1()
        {
            InitializeComponent();
            RegistrationEntities = new RegistrationEntities();

        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            Student NewStudent = new Student
            {
                Name = studentNameEntry.Text,
                //MajorID = int.Parse(majorIDEntry.Text)
                MajorID = Convert.ToInt32(majorIDEntry.Text)
            };
            
            RegistrationEntities.Students.Add(NewStudent);
            RegistrationEntities.SaveChanges();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            Student DeleteRecord = new Student();
            string DeleteName = studentNameEntry.Text;

            DeleteRecord = (from stud in RegistrationEntities.Students
                            where stud.Name == DeleteName
                            select stud).FirstOrDefault();

            RegistrationEntities.Students.Remove(DeleteRecord);
            RegistrationEntities.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Major newMajor = new Major
            {
                Name = majorNameEntry.Text,
                College = collegeNameEntry.Text
            };

            RegistrationEntities.Majors.Add(newMajor);
            RegistrationEntities.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Major DeleteRecord = new Major();
            
            string DeleteName = majorNameEntry.Text;

            DeleteRecord = (from maj in RegistrationEntities.Majors
                            where maj.Name == DeleteName
                            select maj).FirstOrDefault();

            RegistrationEntities.Majors.Remove(DeleteRecord);
            RegistrationEntities.SaveChanges();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registrationDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.registrationDataSet.Student);
            // TODO: This line of code loads data into the 'registrationDataSet.Major' table. You can move, or remove it, as needed.
            this.majorTableAdapter.Fill(this.registrationDataSet.Major);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = studentBindingSource;
            dataGridView2.Update();
            dataGridView2.Refresh();
            dataGridView1.DataSource = majorBindingSource;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var newForm1 = new EnrollmentForm();
            newForm1.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var newForm2 = new CourseForm();
            newForm2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var newForm3 = new SectionForm();
            newForm3.Show();
        }
    }
}
