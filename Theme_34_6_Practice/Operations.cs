using CsvHelper;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Globalization;

namespace Theme_34_6_Practice
{
    public class Operations : ICRUDable<Student>
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public SchoolDbContext context;
        public Operations(SchoolDbContext dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Student>> FindAsync(Func<Student, bool> predicate)
        {
            using (var context = new SchoolDbContext())
            {
                return await Task.Run(() => context.Students.Where(predicate).ToList());
            }
        }

        public async Task<Student> ReadAsync(string firstName, string lastName)
        {
            using (var context = new SchoolDbContext())
            {
                var student = await context.Students.FirstOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName);

                if (student == null)
                {
                    throw new Exception("Студент не найден");
                }

                return student;
            }
        }

        public async Task UpdateAsync(Student entity)
        {
            using (var context = new SchoolDbContext())
            {
                var existingStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == entity.Id);

                if (existingStudent != null)
                {
                    existingStudent.FirstName = entity.FirstName;
                    existingStudent.LastName = entity.LastName;
                    existingStudent.Age = entity.Age;

                    await context.SaveChangesAsync(); // Сохранение изменений в базе данных
                }
                else
                {
                    throw new Exception("Студент не найден");
                }
            }
        }
        public async Task DeleteAsync(string firstName, string lastName)
        {
            var studentToDelete = await context.Students.FirstOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName);

            if (studentToDelete != null)
            {
                context.Students.Remove(studentToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Студент не найден");
            }
        }
        public async Task SaveAsync(List<Student> students)
        {
            var fileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            await using (StreamWriter writer = new StreamWriter(fileName))
            await using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(students);
            }

            await context.SaveChangesAsync();
        }
    }
}
