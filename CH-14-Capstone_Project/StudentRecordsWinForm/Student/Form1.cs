using Student.Services;
using Student.Forms;

namespace Student
{
    public partial class MainForm : Form
    {
        private readonly IStudentService _studentService;

        public MainForm()
        {
            InitializeComponent();
            _studentService = new StudentService();
            LoadStudentsToGrid();
        }

        private void LoadStudentsToGrid()
        {
            dataGridViewStudents.DataSource = _studentService.GetAllStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddStudentForm(_studentService))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStudentsToGrid();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedStudent = (StudentModel.Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
                using (var updateForm = new AddStudentForm(_studentService, selectedStudent))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadStudentsToGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedStudent = (StudentModel.Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedStudent.Name}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(selectedStudent.Name);
                    LoadStudentsToGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var searchForm = new SearchForm(_studentService))
            {
                searchForm.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
