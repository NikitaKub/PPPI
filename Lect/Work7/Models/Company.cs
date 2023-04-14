namespace PPPI.Models
{
    public class Company
    {
        public string Name { get; set; } = "";
        public string OfficialName { get; set; } = "";
        public string Owner { get; set; } = "";

        public override string ToString()
        {
            return $"Name = {Name}, Official name = {OfficialName}, Owner = {Owner}";
        }
    }
}
