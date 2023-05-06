namespace PPPI.Models
{
    public class Employee
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Duty { get; set; } = "";

        public override string ToString()
        {
            return $"Name = {Name}, Surname = {Surname}, Duty = {Duty}";
        }
    }
}
