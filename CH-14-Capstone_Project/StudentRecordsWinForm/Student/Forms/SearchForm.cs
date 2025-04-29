using Student.Services;

namespace Student.Forms
{
    public partial class SearchForm : Form
    {
        private readonly IStudentService _studentService;

        public SearchForm(IStudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dataGridViewResults.DataSource = null;
                return;
            }

            var results = _studentService.SearchStudents(txtSearch.Text);
            dataGridViewResults.DataSource = results;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 