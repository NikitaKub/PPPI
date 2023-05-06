namespace PPPI.Models
{
    public class Department
    {
        public string Name { get; set; } = "";
        public string Duties { get; set; } = "";
        public string Superior { get; set; } = "";

        public override string ToString()
        {
            return $"Name Department = {Name}, Duties = {Duties}, Superior = {Superior}";
        }
    }
}
