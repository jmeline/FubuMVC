
Task("PaketInstall")
.Description("Paket Install...")
.IsDependentOn("BootstrapPaket")
.Does(() =>
{
    string program = ".paket/paket.exe";
    string error = "Paket install failed";
    if (IsRunningOnWindows())
    {
        StartApp(program, "install", error);
    }
    else
    {
        StartApp("mono", program + " install", error);
    }
});

Task("BootstrapPaket")
.Description("Bootstrap Paket...")
.WithCriteria(!FileExists(".paket/paket.exe"))
.Does(() =>
{
    string program = ".paket/paket.bootstrapper.exe";
    string error = "Paket bootstrap failed";
    if (IsRunningOnWindows())
    {
        StartApp(program, "", error);
    }
    else
    {
        StartApp("mono", program, error);
    }
});

private void StartApp(string program, string arguments, string error) {
    int result = StartProcess(program, new ProcessSettings { Arguments = string.Join(" ", arguments) } );

    if (result == 1) {
        Error(error);
    }
}