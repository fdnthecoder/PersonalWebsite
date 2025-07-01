using AmadouDialloPortfolio.Models;

namespace AmadouDialloPortfolio.Data
{
    public static class PortfolioData
    {
        public static List<ExperienceItem> GetExperience()
        {
            return new List<ExperienceItem>
            {
                new ExperienceItem
                {
                    Company = "Amazon.com, Inc",
                    Position = "Software Development Engineer",
                    Location = "Bellevue, WA",
                    Duration = "08/2022 – 08/2023",
                    Achievements = new List<string>
                    {
                        "Led cost-optimization initiative that eliminated $40K in annual AWS AppConfig expenses while improving service reliability",
                        "Designed and implemented data models in Java and Python enabling $6M+ yearly savings",
                        "Managed on-call operations for seven backend microservices",
                        "Mentored 3+ junior engineers on AWS best practices and microservices architecture",
                        "Delivered 10+ technical training sessions on AWS technologies and ML services"
                    }
                },
                new ExperienceItem
                {
                    Company = "Amazon.com, Inc",
                    Position = "Software Development Engineer Intern",
                    Location = "Bellevue, WA",
                    Duration = "06/2021 – 09/2021",
                    Achievements = new List<string>
                    {
                        "Collaborated with research scientists to develop ML model optimizing resource allocation",
                        "Built automated ML pipeline using AWS (SageMaker, AutoPilot, AppConfig, EventBridge)",
                        "Boosted model AUC from 0.75 to 0.94, improving performance by 20%",
                        "Designed modular JupyterNotebook templates cutting deployment time by 12+ hours/month"
                    }
                }
            };
        }

        public static List<ProjectItem> GetProjects()
        {
            return new List<ProjectItem>
            {
                new ProjectItem
                {
                    Name = "Continuous Training and Deployment Pipeline",
                    Description = "Engineered an automated ML pipeline using SageMaker, AppConfig, and EventBridge for seamless continuous training and deployment. Achieved 20% performance improvement through hyperparameter tuning.",
                    Technologies = new List<string> { "AWS SageMaker", "AppConfig", "EventBridge", "Python", "ML" },
                    Date = "09/2021",
                    Category = "Professional"
                },
                new ProjectItem
                {
                    Name = "Indra Agent-Based Modeling System",
                    Description = "Contributed to open source project for exploring natural phenomena modeling in Python. Maintained over 60K lines of code collaborating with 30+ contributors.",
                    Technologies = new List<string> { "Python", "GitHub", "Open Source" },
                    Date = "05/2021",
                    Category = "Open Source",
                    ProjectLink = "https://github.com/gcallah/IndraABM",
                    ProjectLinkText = "See Repo"

                },
                new ProjectItem
                {
                    Name = "Agent-Based Modeling for Epidemics",
                    Description = "Researched and developed a model evaluating effectiveness of social distancing and mask-wearing during epidemics. Implemented automated testing and CI/CD.",
                    Technologies = new List<string> { "Python", "NoseTest", "Travis CI", "Git" },
                    Date = "08/2020",
                    Category = "Academic",
                    ProjectLink = "https://photos.google.com/share/AF1QipOkpivUfPvxJ4GTQnuoDeJZZvUr1YmVbQUHCV0H9eXsORVk8Bpm3MgCrGDEjQYwIQ/photo/AF1QipO_d6Iy90tKLmExDvi77MVc-BKBotN8F1P9Md34?key=Y2ZNNUNaRUNZLVkyNWNvcGFTWnEyOEhJTmVEcVp3",
                    ProjectLinkText = "See Research Poster"
                },
                new ProjectItem
                {
                    Name = "Sources, Please",
                    Description = "Game promoting news literacy using Unity 3D. Won Games for Change 'News Literacy' Prize out of 1920 submissions.",
                    Technologies = new List<string> { "Unity 3D", "C#", "Adobe Photoshop" },
                    Date = "06/2018",
                    Category = "Award-Winning",
                    ProjectLink = "https://amadou1134.itch.io/sources-please",
                    ProjectLinkText = "Play Sources-Please"
                },
                new ProjectItem
                {
                    Name = "This Website",
                    Description = "Personal portfolio website built with .NET Core, showcasing my work, resume, and contact information. Built with Razor Pages and deployed using GitHub Actions and Render.",
                    Technologies = new List<string> { ".NET Core", "Razor Pages", "C#", "Render", "GitHub Actions", "Bootstrap", "HTML", "CSS", "JavaScript" },
                    Date = "05/2025",
                    Category = "Portfolio",
                    ProjectLink = "https://amadoudiallo.dev/",
                    ProjectLinkText = "See Website"
                }
            };
        }

        public static List<string> GetSkills()
        {
            return new List<string>
            {
                "Java Spring Boot", "Python", "C#", "TypeScript",
                "AWS (S3, Lambda, SageMaker, CDK, AppConfig)",
                "GitHub Actions", "Travis CI", "Infrastructure as Code",
                "Microservices", "REST APIs", "CI/CD",
                "Machine Learning", "Data Engineering",
                "Agile Methodologies", "Team Collaboration", ".NET Core", 
                "Bootstrap", "HTML", "CSS", "JavaScript"
            };
        }
    }
}