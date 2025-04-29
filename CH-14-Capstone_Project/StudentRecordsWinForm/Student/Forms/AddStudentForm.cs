using StudentModel;
using Student.Services;
using System;
using System.Windows.Forms;

namespace Student.Forms
{
    public partial class AddStudentForm : Form
    {
        private readonly IStudentService _studentService;
        private readonly StudentModel.Student _studentToUpdate;

        public AddStudentForm(IStudentService studentService, StudentModel.Student studentToUpdate = null)
        {
            InitializeComponent();
            _studentService = studentService;
            _studentToUpdate = studentToUpdate;

            if (studentToUpdate != null)
            {
                Text = "Update Student";
                txtName.Text = studentToUpdate.Name;
                txtAge.Text = studentToUpdate.Age.ToString();
                txtGrade.Text = studentToUpdate.Grade.ToString();
                txtEmail.Text = studentToUpdate.Email;
                txtName.Enabled = false; // Don't allow name changes
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            var student = new StudentModel.Student
            {
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Grade = char.Parse(txtGrade.Text.ToUpper()),
                Email = txtEmail.Text
            };

            try
            {
                if (_studentToUpdate == null)
                {
                    _studentService.AddStudent(student);
                }
                else
                {
                    _studentService.UpdateStudent(student);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 0 || age > 120)
            {
                MessageBox.Show("Please enter a valid age between 0 and 120.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGrade.Text) || txtGrade.Text.Length != 1)
            {
                MessageBox.Show("Please enter a single grade character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 