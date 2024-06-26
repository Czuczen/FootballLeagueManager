﻿using FootballLeagueManager.Configuration.Secrets;
using FootballLeagueManager.Consts;
using FootballLeagueManager.Logging;
using FootballLeagueManager.Models.ViewModels.AppManagement;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FootballLeagueManager.Controllers;

public class AppManagementController : Controller
{
    private readonly IConfiguration _configuration;

    public AppManagementController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Uruchamiane z linka - http://localhost:5135/AppManagement/Logs?accessKey=key
    /// </summary>
    /// <param name="accessKey"></param>
    /// <returns></returns>
    public IActionResult Logs(string accessKey)
    {
        var ret = new LogsViewModel();

        if (accessKey == SecretsProvider.GetAccessKey(AccessNames.Logs))
        {
            var logFilePath = _configuration.GetSection("Logging:FileLogging").Get<FileLoggerConfiguration>().LogFilePath;
            var logDirectory = Path.GetDirectoryName(logFilePath);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(logFilePath);
            var fileExtension = Path.GetExtension(logFilePath);
            var logFiles = Directory.GetFiles(logDirectory, $"{fileNameWithoutExtension}*{fileExtension}")
                .OrderByDescending(System.IO.File.GetLastWriteTime).Reverse();

            foreach (var logFile in logFiles)
            {
                using var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var sr = new StreamReader(fs, Encoding.Default);
                var buffer = new char[(int)sr.BaseStream.Length];
                sr.Read(buffer, 0, (int)sr.BaseStream.Length);

                var rawLogs = new string(buffer);
                var stringSeparators = new[] { "\r\n" };
                var lines = rawLogs.Split(stringSeparators, StringSplitOptions.None);

                var log = new List<string>();
                foreach (var line in lines)
                {
                    var isNewLog = false;

                    if (line.StartsWith("TRACE"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.TraceLogs.Add(log);
                    }

                    if (line.StartsWith("DEBUG"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.DebugLogs.Add(log);
                    }

                    if (line.StartsWith("INFORMATION"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.InfoLogs.Add(log);
                    }

                    if (line.StartsWith("WARN"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.WarnLogs.Add(log);
                    }

                    if (line.StartsWith("ERROR"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.ErrorLogs.Add(log);
                    }

                    if (line.StartsWith("CRITICAL"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.CriticalLogs.Add(log);
                    }

                    if (line.StartsWith("NONE"))
                    {
                        isNewLog = true;

                        log = new List<string> { line };
                        ret.NoneLogs.Add(log);
                    }

                    if (!isNewLog)
                        log.Add(line);
                }
            }

            ret.TraceLogs.Reverse();
            ret.DebugLogs.Reverse();
            ret.InfoLogs.Reverse();
            ret.WarnLogs.Reverse();
            ret.ErrorLogs.Reverse();
            ret.CriticalLogs.Reverse();
            ret.NoneLogs.Reverse();
        }
        else
            return Unauthorized("Nieprawidłowy klucz dostępu");

        return View(ret);
    }
}
