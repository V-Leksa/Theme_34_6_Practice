
namespace Theme_34_6_Practice
{
    public partial class StudentF : Form
    {
        private readonly Operations operations;
        
        public StudentF()
        {
            InitializeComponent();
            operations = new Operations(CreateDbContext());
            this.Click += StudentF_Click;
        }
        private SchoolDbContext CreateDbContext()
        {
            return new SchoolDbContext();
        }
        private async void AddBt_Click(object sender, EventArgs e)
        {
            try
            {
                //��������� ������ ����� �����������
                if (!ValidateInput())
                {
                    MessageBox.Show("������� ���������� ������");
                    return;
                }
                string firstName = NameTB.Text;
                string lastName = LastNameTB.Text;
                int age = Convert.ToInt32(AgeTB.Text);

                var newStudent = new Student(firstName, lastName, age);

                await operations.AddAsync(newStudent);
                MessageBox.Show("������� ������� ��������");

                ClearInputFields();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void HandleException(Exception ex)
        {
            MessageBox.Show($"��������� ������: {ex.Message}");
        }
        private void ClearInputFields()
        {
            NameTB.Text = string.Empty;
            LastNameTB.Text = string.Empty;
            AgeTB.Text = string.Empty;
            NameSurnameTb.Text = string.Empty;

            // ������ ��������� � ListBox
            ShowLB.ClearSelected();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(LastNameTB.Text))
            {
                return false;
            }
            if (!int.TryParse(AgeTB.Text, out int age) || age <= 0)
            {
                return false;
            }

            return true;
        }
        private async void ShowBt_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� ListBox ����� ������������ ����� ������
                ShowLB.Items.Clear();

                var students = await operations.FindAsync(s => true);

                foreach (var student in students)
                {
                    ShowLB.Items.Add(student.Display());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private async void FindBt_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� ListBox ����� ������������ ����� ������
                ShowLB.Items.Clear();

                string searchText = NameSurnameTb.Text;
                var isSearchByName = NameRB.Checked;

                var searchTextLower = searchText.ToLower(); // �������������� ���������� ������ � ������� ��������

                var students = isSearchByName
                   ? await operations.FindAsync(s => s.FirstName.ToLower().Contains(searchText.ToLower()))
                   : await operations.FindAsync(s => s.LastName.ToLower().Contains(searchText.ToLower()));

                foreach (var student in students)
                {
                    ShowLB.Items.Add(student.Display());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private async void RedactionBt_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedStudentString = ShowLB.SelectedItem as string;

                if (selectedStudentString == null)
                {
                    MessageBox.Show("����������, �������� �������� ��� ��������������.");
                    return;
                }

                var studentData = selectedStudentString.Split(' ');
                var firstName = studentData[0];
                var lastName = studentData[1];

                var selectedStudent = await operations.ReadAsync(firstName, lastName);

                if (selectedStudent == null)
                {
                    MessageBox.Show("������ ��� ��������� ������ ��������.");
                    return;
                }

                // ���������� ������ �������� �� ������ ��������� �������� � ��������� �����
                selectedStudent.FirstName = NameTB.Text.Trim();
                selectedStudent.LastName = LastNameTB.Text.Trim();

                if (string.IsNullOrEmpty(selectedStudent.FirstName) || string.IsNullOrEmpty(selectedStudent.LastName))
                {
                    MessageBox.Show("����������, ������� ���������� ��� � �������.");
                    return;
                }

                if (int.TryParse(AgeTB.Text, out int newAge))
                {
                    selectedStudent.Age = newAge;
                }
                else
                {
                    MessageBox.Show("����������, ������� ���������� �������.");
                    return;
                }

                // ���������� ������ �������� � ���� ������
                await operations.UpdateAsync(selectedStudent);

                // ����������� ����������� ������
                Console.WriteLine($"����������� ������: {selectedStudent.FirstName}, {selectedStudent.LastName}, {selectedStudent.Age}");

                // ���������� ������ �������� � ListBox
                ShowLB.Items[ShowLB.SelectedIndex] = $"{selectedStudent.FirstName} {selectedStudent.LastName} {selectedStudent.Age}";

                MessageBox.Show("������ �������� ������� ���������.");
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }
        
        private async void ShowLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStudentIndex = ShowLB.SelectedIndex;
            if (selectedStudentIndex != -1)
            {
                var selectedStudentName = ShowLB.Items[selectedStudentIndex].ToString(); // ��������� ����� � ������� �������� �� ListBox
                var nameParts = selectedStudentName.Split(' '); // ���������� ����� � ������� �� �������

                if (nameParts.Length >= 2)
                {
                    var firstName = nameParts[0].Trim();
                    var lastName = nameParts[1].Trim();

                    var selectedStudent = await operations.ReadAsync(firstName,lastName);

                    if (selectedStudent != null)
                    {
                        NameTB.Text = selectedStudent.FirstName;
                        LastNameTB.Text = selectedStudent.LastName;
                        AgeTB.Text = selectedStudent.Age.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"������� {firstName}{lastName} �� ������.");
                    }
                }
                else
                {
                    MessageBox.Show($"������ ��� ��������� ����� � ������� ��������. ���������� ��������: {selectedStudentName}");
                }
            }
        }
        private async void RemoveBt_Click(object sender, EventArgs e)
        {
            try
            {
                // ��������� ����������� �������� �� ListBox
                var selectedStudentIndex = ShowLB.SelectedIndex;

                if (selectedStudentIndex == -1)
                {
                    MessageBox.Show("����������, �������� �������� ��� ��������.");
                    return;
                }

                var firstName = NameTB.Text.Trim();
                var lastName = LastNameTB.Text.Trim();

                await operations.DeleteAsync(firstName, lastName);

                // �������� �������� �� ListBox
                ShowLB.Items.RemoveAt(selectedStudentIndex);

                MessageBox.Show("������� ������� ������.");
                ClearInputFields();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private async void SaveBt_Click(object sender, EventArgs e)
        {
            try
            {
                BackupService backupService = new BackupService();
                var students = backupService.context.Students.ToList();
                await operations.SaveAsync(students); 
                MessageBox.Show($"��������� ����� ���� ������ ������� ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ������ � CSV ����: {ex.Message}");
            }
        }
        private void StudentF_Click(object sender, EventArgs e)
        {
            ShowLB.ClearSelected();
            NameTB.Text = string.Empty;
            LastNameTB.Text = string.Empty;
            AgeTB.Text = string.Empty;
            NameSurnameTb.Text = string.Empty;
        }
    }
}