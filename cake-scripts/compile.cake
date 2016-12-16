using System;
using System.IO;

Task("Compile")
    .Description("Compiles debug and release modes")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("CompileRelease");

Task("CompileDebug")
    .Description("Compiles in debug mode")
    .Does(() => {
      Compile("Debug");
    });

Task("CompileRelease")
    .Description("Compiles in release mode")
    .Does(() => {
      Compile("Release");
    });

private string GetSolution(string rootPath) {
    Information("Starting to get Solution Files for " + rootPath);
    return System.IO.Directory.GetFiles(rootPath, "*.sln")
                    .Select(_ => _.Replace("./", " "))
                    .First();
}

private void Compile(string mode)
{
    var solution = GetSolution("./src");
    if (IsRunningOnWindows()) {
      MSBuild(solution, settings =>
          settings.SetConfiguration(mode)
          .SetVerbosity(Verbosity.Minimal)
          .UseToolVersion(MSBuildToolVersion.NET46)
          .WithTarget("Build"));
    } else {
      XBuild(solution, new XBuildSettings {
          Verbosity = Verbosity.Minimal,
          Configuration = mode
      });
    }
}