nuget pack ..\src\ElectronicInvoice.Produce\ElectronicInvoice.Produce.nuspec

for /f "delims=" %%a in ('dir /s /b *.nupkg') do set filename=%%~nxa

nuget push %filename%

del %filename%

Pause