using Npgsql;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Domain;
using System.Data;

namespace SchoolManagementSystem.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolDbContext _context;
        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetAddAsync(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                using (var command = new NpgsqlCommand("public.addstudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters with correct names and types
                    command.Parameters.AddWithValue("p_firstname", NpgsqlTypes.NpgsqlDbType.Varchar, student.FirstName);
                    command.Parameters.AddWithValue("p_lastname", NpgsqlTypes.NpgsqlDbType.Varchar, student.LastName);
                    command.Parameters.AddWithValue("p_dateofbirth", NpgsqlTypes.NpgsqlDbType.Date, student.DateOfBirth);
                    command.Parameters.AddWithValue("p_email", NpgsqlTypes.NpgsqlDbType.Varchar, student.Email);
                    command.Parameters.AddWithValue("p_classid", NpgsqlTypes.NpgsqlDbType.Integer, student.ClassId ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return student;
                }
            }
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var students = new List<Student>();

            await using (var connection = _context.CreateConnection())
            {
                await connection.OpenAsync();

                // Start a transaction to use the cursor
                await using (var transaction = await connection.BeginTransactionAsync())
                {
                    // Step 1: Call the stored procedure to open the cursor
                    string cursorName;
                    await using (var command = new NpgsqlCommand("public.getallstudents", connection, transaction))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add an output parameter for the cursor
                        command.Parameters.Add(new NpgsqlParameter
                        {
                            ParameterName = "ref_cursor",
                            NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Refcursor,
                            Direction = ParameterDirection.Output
                        });

                        // Execute the command to open the cursor
                        await command.ExecuteNonQueryAsync();

                        // Retrieve the cursor name
                        cursorName = (string)command.Parameters["ref_cursor"].Value;
                    }

                    // Step 2: Fetch the data using the cursor
                    await using (var fetchCommand = new NpgsqlCommand($"FETCH ALL IN \"{cursorName}\";", connection, transaction))
                    await using (var reader = await fetchCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                StudentId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Email = reader.GetString(4),
                                ClassId = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5)
                            });
                        }
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();
                }
            }

            return students;
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetDeleteAsync(Student student)
        {
            await using (var connection = _context.CreateConnection())
            {
                await connection.OpenAsync();

                // Use await using for command to ensure proper disposal
                await using (var command = new NpgsqlCommand("public.softdeletestudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_studentid", student.StudentId);

                    // Execute the stored procedure asynchronously
                    await command.ExecuteNonQueryAsync();

                    // Return the student object that was marked as deleted
                    return student;
                }
            }
        }


        public Task<Student> GetUpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
