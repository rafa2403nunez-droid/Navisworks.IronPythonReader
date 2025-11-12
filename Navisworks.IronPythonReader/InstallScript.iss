; ================================
; RNM IronPython Reader Installer
; ================================

#define AssemblyName "Navisworks.IronPythonReader"
#define AppName "RNM IronPythonReader"
#define AppAlias "IronPython Reader"
#define AppVersion "0.0.0"
#define AppPublisher "RNMTools"

#define ScriptRoot SourcePath
#define ProjectRoot ScriptRoot + "..\\" + AssemblyName
#define BinRelease ProjectRoot + "\\bin\\Release"
#define RibbonPath ProjectRoot + "\\Ribbon\\IronPythonReader.xaml"
#define PackageContents ProjectRoot + "\\PackageContents.xml"
#define ResourcesPath ProjectRoot + "\\Resources"

#define Navisworks2024 "\\Autodesk\\ApplicationPlugins\\" + AssemblyName + ".bundle\\Contents\\2024\\"

#pragma message "📁 ScriptRoot: {#ScriptRoot}"
#pragma message "📁 ProjectRoot: {#ProjectRoot}"
#pragma message "📁 BinRelease: {#BinRelease}"
#pragma message "📁 RibbonPath: {#RibbonPath}"
#pragma message "📁 PackageContents: {#PackageContents}"
#pragma message "📁 ResourcesPath: {#ResourcesPath}"

[Setup]
AppId={{93CD3F1E-2854-4FD4-9CDD-A29968587182}}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName=C:\ProgramData\{#AppName}
DisableDirPage=yes
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
OutputDir=.\Installer
OutputBaseFilename={#AppAlias}_Installer
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupLogging=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; --- Ensamblados principales (tus DLLs) ---
Source: "{#BinRelease}\*.dll"; DestDir: "{userappdata}{#Navisworks2024}"; Flags: ignoreversion recursesubdirs

Source: "{#RibbonPath}"; DestDir: "{userappdata}{#Navisworks2024}\es-ES\"; Flags: ignoreversion
Source: "{#PackageContents}"; DestDir: "{userappdata}\Autodesk\ApplicationPlugins\{#AssemblyName}.bundle\"; Flags: ignoreversion
Source: "{#ResourcesPath}\*"; DestDir: "{userappdata}{#Navisworks2024}\Images\"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppAlias}.exe"

[Run]
; Filename: "{app}\{#AppAlias}.exe"; Description: "Run {#AppName}"; Flags: nowait postinstall skipifsilent
