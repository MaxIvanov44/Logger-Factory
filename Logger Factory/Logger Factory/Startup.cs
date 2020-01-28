using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Logger_Factory
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder.AddDebug();
            //    builder.AddConsole();
            //    builder.AddFilter("System", LogLevel.Debug)
            //            .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            //});
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.AddFilter("System", LogLevel.Debug)
                        .SetMinimumLevel(LogLevel.Debug);   // Определение MinimumLevel

            });
            ILogger logger = loggerFactory.CreateLogger<Startup>();
            app.Run(async (context) =>
            {
                logger.LogInformation("Requested Path: {0}", context.Request.Path);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
