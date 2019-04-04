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
            var MajorFilter = RegistrationEntities.Students.Where(f => f.Major.Id == (NewStudent.MajorID)).ToList();

            if (MajorFilter.Count > 0)
            {
                RegistrationEntities.Students.Add(NewStudent);
                RegistrationEntities.SaveChanges();
            }

            else
            {
                MessageBox.Show("Major does not exist.", "Error", MessageBoxButtons.OK);
            }

            //var selectedMajor = majorsList.SelectedItem as Major;
            /*

            if (selectedMajor != null)
            {
                Student newStudent = new Student
                {
                    Name = studentNameEntry.Text,
                    Major = selectedMajor
                };
                RegistrationEntities.Students.Add(newStudent);
                RegistrationEntities.SaveChanges();
            }
            */
            updateStudentsList();

        }

        private void updateStudentsList()
        {
            /*
            foreach (var student in RegistrationEntities.Students)
            {
                studentsList.Text += $"{student.Name} {student.Major.Name} {student.Major.College}";
            }
            */
        }

        private void updateMajorsList()
        {
            /*
            foreach (var major in RegistrationEntities.Majors)
            {
                var temp = RegistrationEntities.Majors.ToList();
                majorsList.DataSource = temp;
                majorsList.DisplayMember = "ToStringy";

                //majorsList.Text += $"{major.Name}";
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Major newMajor = new Major
            {
                Name = majorNameEntry.Text,
                College = "CECS"
            };

            RegistrationEntities.Majors.Add(newMajor);
            RegistrationEntities.SaveChanges();
            updateMajorsList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sectionsForm = new Sections();
            sectionsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            var selectedMajor = majorsList.SelectedItem as Major;
            if (selectedMajor != null)
            {
                if (selectedMajor.Students.Count > 0)
                {
                    MessageBox.Show("You can't delete a major that has students!");
                }
                else
                {
                    RegistrationEntities.Majors.Remove(selectedMajor);
                    RegistrationEntities.SaveChanges();
                }

            }
            */
        }

        private void reloadMajor_Click(object sender, EventArgs e)
        {
            updateMajorsList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registrationDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.registrationDataSet.Student);
            // TODO: This line of code loads data into the 'registrationDataSet.Major' table. You can move, or remove it, as needed.
            this.majorTableAdapter.Fill(this.registrationDataSet.Major);

        }
    }
}
