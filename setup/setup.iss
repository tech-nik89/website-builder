#define ApplicationVersion GetStringFileInfo("..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe", "FileVersion")

[Setup]
AppName=Website Builder
AppVersion={#ApplicationVersion}
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
Source: "..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe"; DestDir: "{app}"; Components: core
Source: "..\src\WebsiteBuilder.UI\bin\Release\WebsiteBuilder.exe.config"; DestDir: "{app}"; Components: core
Source: "..\src\WebsiteBuilder.UI\bin\Release\*.dll"; DestDir: "{app}"; Components: core
Source: "..\src\WebsiteBuilder.UI\bin\Release\Plugins\*.dll"; DestDir: "{app}\Plugins"; Components: core
Source: "..\src\WebsiteBuilder.UI\bin\Release\Resources\IconPacks\Default.zip"; DestDir: "{app}\Resources\IconPacks"; DestName: "Default.zip"; Components: core
Source: "..\LICENSE"; DestDir: "{app}"; DestName: "license.txt"; Components: core
Source: "..\themes\*.wbtx"; DestDir: "{app}\SampleThemes"; Components: themes

[Icons]
Name: "{group}\Website Builder"; Filename: "{app}\WebsiteBuilder.exe"; WorkingDir: "{app}"; MinVersion: 0,6.0sp2

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"; LicenseFile: "..\LICENSE"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"; LicenseFile: "..\LICENSE"

[Components]
Name: "core"; Description: "Core application"; Types: compact full
Name: "themes"; Description: "Sample Themes"; Types: full

[Code]
// ##### .NET Framework detection  ##### //
// Code snipped copied from http://www.kynosarges.de/DotNetVersion.html which is public domain (31.05.2017).
// "I’m placing this small bit of code in the public domain, so you may embed it in your own projects, modify and redistribute it as you see fit."

function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1'          .NET Framework 1.1
//    'v2.0'          .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//    'v4.5.1'        .NET Framework 4.5.1
//    'v4.5.2'        .NET Framework 4.5.2
//    'v4.6'          .NET Framework 4.6
//    'v4.6.1'        .NET Framework 4.6.1
//    'v4.6.2'        .NET Framework 4.6.2
//    'v4.7'          .NET Framework 4.7
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key, versionKey: string;
    install, release, serviceCount, versionRelease: cardinal;
    success: boolean;
begin
    versionKey := version;
    versionRelease := 0;

    // .NET 1.1 and 2.0 embed release number in version key
    if version = 'v1.1' then begin
        versionKey := 'v1.1.4322';
    end else if version = 'v2.0' then begin
        versionKey := 'v2.0.50727';
    end

    // .NET 4.5 and newer install as update to .NET 4.0 Full
    else if Pos('v4.', version) = 1 then begin
        versionKey := 'v4\Full';
        case version of
          'v4.5':   versionRelease := 378389;
          'v4.5.1': versionRelease := 378675; // 378758 on Windows 8 and older
          'v4.5.2': versionRelease := 379893;
          'v4.6':   versionRelease := 393295; // 393297 on Windows 8.1 and older
          'v4.6.1': versionRelease := 394254; // 394271 before Win10 November Update
          'v4.6.2': versionRelease := 394802; // 394806 before Win10 Anniversary Update
          'v4.7':   versionRelease := 460798; // 460805 before Win10 Creators Update
        end;
    end;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + versionKey;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0 and newer use value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 and newer use additional value Release
    if versionRelease > 0 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= versionRelease);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;


function InitializeSetup(): Boolean;
begin
    if not IsDotNetDetected('v4.5.2', 0) then begin
        MsgBox('This application requires Microsoft .NET Framework 4.5.2.'#13#13
            'Please use Windows Update to install this version,'#13
            'and then re-run the setup program.', mbInformation, MB_OK);
        result := false;
    end else
        result := true;
end;