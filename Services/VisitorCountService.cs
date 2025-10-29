using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace AmadouDialloPortfolio.Services
{
    public class VisitorCountService
    {
        private readonly string _filePath;
        private readonly ILogger<VisitorCountService> _logger;
        private readonly object _lock = new object(); // For thread-safe file access

        public VisitorCountService(IWebHostEnvironment webHostEnvironment, ILogger<VisitorCountService> logger)
        {
            _filePath = Path.Combine(webHostEnvironment.ContentRootPath, "visitor_counts.json");
            _logger = logger;
            InitializeFile();
        }

        private void InitializeFile()
        {
            if (!File.Exists(_filePath))
            {
                try
                {
                    var initialData = new VisitorData { TotalVisits = 0, PageVisits = new Dictionary<string, int>(), ResumeDownloads = 0 };
                    File.WriteAllText(_filePath, JsonSerializer.Serialize(initialData));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error initializing visitor_counts.json file.");
                }
            }
        }

        public VisitorData GetVisitorData()
        {
            lock (_lock)
            {
                try
                {
                    var json = File.ReadAllText(_filePath);
                    var data = JsonSerializer.Deserialize<VisitorData>(json) ?? new VisitorData();
                    _logger.LogInformation("Retrieved visitor data: TotalVisits={TotalVisits}, PageVisits={PageVisits}, ResumeDownloads={ResumeDownloads}", data.TotalVisits, string.Join(", ", data.PageVisits.Select(kv => $"{kv.Key}:{kv.Value}")), data.ResumeDownloads);
                    return data;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error reading visitor data from file.");
                    return new VisitorData();
                }
            }
        }

        public void IncrementTotalVisits()
        {
            lock (_lock)
            {
                var data = GetVisitorData();
                data.TotalVisits++;
                _logger.LogInformation("Incrementing total visits to: {TotalVisits}", data.TotalVisits);
                SaveVisitorData(data);
            }
        }

        public void IncrementPageVisit(string pageName)
        {
            lock (_lock)
            {
                var data = GetVisitorData();
                if (data.PageVisits.ContainsKey(pageName))
                {
                    data.PageVisits[pageName]++;
                }
                else
                {
                    data.PageVisits[pageName] = 1;
                }
                _logger.LogInformation("Incrementing page '{PageName}' visits to: {PageVisits}", pageName, data.PageVisits[pageName]);
                SaveVisitorData(data);
            }
        }

        public void IncrementResumeDownloads()
        {
            lock (_lock)
            {
                var data = GetVisitorData();
                data.ResumeDownloads++;
                _logger.LogInformation("Incrementing resume downloads to: {ResumeDownloads}", data.ResumeDownloads);
                SaveVisitorData(data);
            }
        }

        private void SaveVisitorData(VisitorData data)
        {
            lock (_lock)
            {
                try
                {
                    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(_filePath, json);
                    _logger.LogInformation("Saved visitor data: {JsonData}", json);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving visitor data to file.");
                }
            }
        }
    }

    public class VisitorData
    {
        public long TotalVisits { get; set; }
        public Dictionary<string, int> PageVisits { get; set; } = new Dictionary<string, int>();
        public int ResumeDownloads { get; set; }
    }
}
