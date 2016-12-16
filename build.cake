#load "./cake-scripts/compile.cake"
#load "./cake-scripts/paket.cake"
#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");

Task("Default")
    .Description("Default Task!")
    .IsDependentOn("PaketInstall")
    .IsDependentOn("Compile");
    // .IsDependentOn("Xunit2");


Task("Xunit2")
  .Description("Run xUnit tests")
  .Does(() => {
    XUnit2("./src/Sample.Test/bin/Debug/Sample.Test.dll");
  });

RunTarget(target);
