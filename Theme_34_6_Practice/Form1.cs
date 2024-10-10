
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
                //Валидация данных перед добавлением
                if (!ValidateInput())
                {
                    MessageBox.Show("Введите корректные данные");
                    return;
                }
                string firstName = NameTB.Text;
                string lastName = LastNameTB.Text;
                int age = Convert.ToInt32(AgeTB.Text);

                var newStudent = new Student(firstName, lastName, age);

                await operations.AddAsync(newStudent);
                MessageBox.Show("Студент успешно добавлен");

                ClearInputFields();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void HandleException(Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}");
        }
        private void ClearInputFields()
        {
            NameTB.Text = string.Empty;
            LastNameTB.Text = string.Empty;
            AgeTB.Text = string.Empty;
            NameSurnameTb.Text = string.Empty;

            // Снятие выделения в ListBox
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
                // Очистка ListBox перед отображением новых данных
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
                // Очистка ListBox перед отображением новых данных
                ShowLB.Items.Clear();

                string searchText = NameSurnameTb.Text;
                var isSearchByName = NameRB.Checked;

                var searchTextLower = searchText.ToLower(); // Преобразование введенного текста к нижнему регистру

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
                    MessageBox.Show("Пожалуйста, выберите студента для редактирования.");
                    return;
                }

                var studentData = selectedStudentString.Split(' ');
                var firstName = studentData[0];
                var lastName = studentData[1];

                var selectedStudent = await operations.ReadAsync(firstName, lastName);

                if (selectedStudent == null)
                {
                    MessageBox.Show("Ошибка при получении данных студента.");
                    return;
                }

                // Обновление данных студента на основе введенных значений в текстовых полях
                selectedStudent.FirstName = NameTB.Text.Trim();
                selectedStudent.LastName = LastNameTB.Text.Trim();

                if (string.IsNullOrEmpty(selectedStudent.FirstName) || string.IsNullOrEmpty(selectedStudent.LastName))
                {
                    MessageBox.Show("Пожалуйста, введите корректное имя и фамилию.");
                    return;
                }

                if (int.TryParse(AgeTB.Text, out int newAge))
                {
                    selectedStudent.Age = newAge;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректный возраст.");
                    return;
                }

                // Обновление данных студента в базе данных
                await operations.UpdateAsync(selectedStudent);

                // Логирование обновленных данных
                Console.WriteLine($"Обновленные данные: {selectedStudent.FirstName}, {selectedStudent.LastName}, {selectedStudent.Age}");

                // Обновление данных студента в ListBox
                ShowLB.Items[ShowLB.SelectedIndex] = $"{selectedStudent.FirstName} {selectedStudent.LastName} {selectedStudent.Age}";

                MessageBox.Show("Данные студента успешно обновлены.");
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
                var selectedStudentName = ShowLB.Items[selectedStudentIndex].ToString(); // Получение имени и фамилии студента из ListBox
                var nameParts = selectedStudentName.Split(' '); // Разделение имени и фамилии по пробелу

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
                        MessageBox.Show($"Студент {firstName}{lastName} не найден.");
                    }
                }
                else
                {
                    MessageBox.Show($"Ошибка при получении имени и фамилии студента. Полученное значение: {selectedStudentName}");
                }
            }
        }
        private async void RemoveBt_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение выделенного студента из ListBox
                var selectedStudentIndex = ShowLB.SelectedIndex;

                if (selectedStudentIndex == -1)
                {
                    MessageBox.Show("Пожалуйста, выберите студента для удаления.");
                    return;
                }

                var firstName = NameTB.Text.Trim();
                var lastName = LastNameTB.Text.Trim();

                await operations.DeleteAsync(firstName, lastName);

                // Удаление студента из ListBox
                ShowLB.Items.RemoveAt(selectedStudentIndex);

                MessageBox.Show("Студент успешно удален.");
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
                MessageBox.Show($"Резервная копия базы данных успешно сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных в CSV файл: {ex.Message}");
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