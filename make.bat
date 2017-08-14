@echo off

set MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\amd64\MSBuild.exe"
set INNO_PATH="C:\Program Files (x86)\Inno Setup 5\Compil32.exe"

rem UPDATE VERSION INFO
echo Start Update Version Info
SubWCRev %cd% %cd%\src\SharedSources\SharedAssemblyInfo.templ %cd%\src\SharedSources\SharedAssemblyInfo.cs
echo End   Update Version Info

rem BUILD SOLUTION
echo Start Build Solution

call %MSBUILD_PATH% src/WebsiteStudio.sln /t:Clean /p:Configuration=Release
call %MSBUILD_PATH% src/WebsiteStudio.sln /t:Rebuild /p:Configuration=Release

echo End   Build Solution

rem BUILD SETUP
echo Start Build Setup

call %INNO_PATH% /cc "setup/setup.iss"

echo End   Build Setp