namespace empAI.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string EmployeeFirstName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public DateTime EmployeeDateOfBirth { get; set; }

        public int Age { get; set; }
        public string location { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Organization { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }
}
