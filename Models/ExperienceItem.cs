namespace AmadouDialloPortfolio.Models
{
    public class ExperienceItem
    {
        public string Company { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public List<string> Achievements { get; set; } = new();
    }
}