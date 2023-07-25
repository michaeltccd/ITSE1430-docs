/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using Microsoft.Extensions.Configuration;

namespace MovieLibrary.WinHost;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");
        Configuration = builder.Build();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());        
    }

    public static IConfiguration Configuration { get; private set; }
}
