
#define AssemblyName "Navisworks.IronPythonReader"
#define AppName "RNM IronPythonReader"
#define AppAlias "IronPython Reader"
#define Version "2026"
#define AppVersion "1.0.1"
#define AppPublisher "RNMTools"

; --- Paths ---
#define ScriptRoot SourcePath
#define ProjectFolder "Navisworks.IronPythonReader.26"
#define ProjectRoot ScriptRoot + "..\\" + ProjectFolder

#define BinRelease ProjectRoot + "\\bin\\Release"
#define RibbonPath ProjectRoot + "\\Ribbon\\IronPythonReader.xaml"
#define PackageContents ProjectRoot + "\\PackageContents.xml"
#define ResourcesPath ProjectRoot + "\\Resources"

#define Navisworks2026 "\\Autodesk\\ApplicationPlugins\\" + AssemblyName + ".bundle\\Contents\\2026"

; --- Debug ---
#pragma message "ScriptRoot: {#ScriptRoot}"
#pragma message "ProjectRoot: {#ProjectRoot}"
#pragma message "BinRelease: {#BinRelease}"
#pragma message "RibbonPath: {#RibbonPath}"
#pragma message "PackageContents: {#PackageContents}"
#pragma message "ResourcesPath: {#ResourcesPath}"

[Setup]
AppId={{93CD3F1E-2854-4FD4-9CDD-A29968587182}}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName=C:\ProgramData\{#AppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
OutputDir=.\Installer
OutputBaseFilename={#AppAlias}_{#Version}_{#AppVersion}_Installer
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupLogging=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; --- DLLs ---
Source: "{#BinRelease}\*.dll"; \
  DestDir: "{userappdata}{#Navisworks2026}"; \
  Flags: ignoreversion recursesubdirs

; --- Ribbon ---
Source: "{#RibbonPath}"; \
  DestDir: "{userappdata}{#Navisworks2026}\es-ES\"; \
  Flags: ignoreversion

Source: "{#RibbonPath}"; \
  DestDir: "{userappdata}{#Navisworks2026}\en-US\"; \
  Flags: ignoreversion

; --- PackageContents ---
Source: "{#PackageContents}"; \
  DestDir: "{userappdata}\Autodesk\ApplicationPlugins\{#AssemblyName}.bundle\"; \
  Flags: ignoreversion

; --- Resources ---
Source: "{#ResourcesPath}\*"; \
  DestDir: "{userappdata}{#Navisworks2026}\Images\"; \
  Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppAlias}.exe"

