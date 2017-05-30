#define ApplicationVersion GetStringFileInfo("..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe", "FileVersion")

[Setup]
AppName=Website Builder
AppVersion=1.0.0
AppCopyright=(c) 2017
AppId={{0927E8F2-4E71-4092-84BB-BB0322EA965D}
DefaultDirName={pf}\Website Builder
DefaultGroupName=Website Builder
AppPublisher=tech-nik89
AppPublisherURL=https://github.com/tech-nik89
AppSupportURL=https://github.com/tech-nik89/website-builder
AppUpdatesURL=https://github.com/tech-nik89/website-builder
UninstallDisplayName=Website Builder
VersionInfoVersion={#ApplicationVersion}
MinVersion=0,6.0sp2
OutputBaseFilename=WebsiteBuilderSetup_{#ApplicationVersion}
UninstallDisplayIcon={app}\WebsiteBuilder.exe

[Files]
Source: "..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe"; DestDir: "{app}"; Components: Core
Source: "..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe.config"; DestDir: "{app}"; Components: Core
Source: "..\src\WebsiteBuilder.UI\bin\Release\*.dll"; DestDir: "{app}"; Components: Core
Source: "..\src\WebsiteBuilder.UI\bin\Release\Plugins\*.dll"; DestDir: "{app}\Plugins"; Components: Core
Source: "..\themes\*.wbtx"; DestDir: "{app}\SampleThemes"; Components: Themes
Source: "..\LICENSE"; DestDir: "{app}"; DestName: "license.txt"; Components: core

[Icons]
Name: "{group}\Website Builder"; Filename: "{app}\WebsiteBuilder.exe"; WorkingDir: "{app}"; MinVersion: 0,6.0sp2

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"; LicenseFile: "D:\Projekte\wsb\trunk\LICENSE"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"; LicenseFile: "D:\Projekte\wsb\trunk\LICENSE"

[Components]
Name: "core"; Description: "Core application"; Types: compact full
Name: "themes"; Description: "Sample Themes"; Types: full
