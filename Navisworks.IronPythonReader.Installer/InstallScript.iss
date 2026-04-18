#define AssemblyName "Navisworks.IronPythonReader"
#define AppName "RNM IronPythonReader"
#define AppAlias "IronPython Reader"
#define AppVersion "1.0.2"
#define AppPublisher "RNMTools"

; --- Paths base ---
#define ScriptRoot SourcePath

; --- Projects ---
#define ProjectRoot24 ScriptRoot + "..\\Navisworks.IronPythonReader.24"
#define ProjectRoot25 ScriptRoot + "..\\Navisworks.IronPythonReader.25"
#define ProjectRoot26 ScriptRoot + "..\\Navisworks.IronPythonReader.26"

; --- Navisworks paths ---
#define Navisworks2024 "\\Autodesk\\ApplicationPlugins\\" + AssemblyName + ".bundle\\Contents\\2024"
#define Navisworks2025 "\\Autodesk\\ApplicationPlugins\\" + AssemblyName + ".bundle\\Contents\\2025"
#define Navisworks2026 "\\Autodesk\\ApplicationPlugins\\" + AssemblyName + ".bundle\\Contents\\2026"

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
OutputBaseFilename={#AppAlias}_Multi_{#AppVersion}_Installer
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupLogging=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]

; =========================
; ===== NAVISWORKS 2024 ===
; =========================
Source: "{#ProjectRoot24}\bin\Release\*.dll"; \
  DestDir: "{userappdata}{#Navisworks2024}"; \
  Flags: ignoreversion recursesubdirs

Source: "{#ProjectRoot24}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2024}\en-US\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot24}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2024}\es-ES\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot24}\Resources\*"; \
  DestDir: "{userappdata}{#Navisworks2024}\Images\"; \
  Flags: ignoreversion recursesubdirs


; =========================
; ===== NAVISWORKS 2025 ===
; =========================
Source: "{#ProjectRoot25}\bin\Release\*.dll"; \
  DestDir: "{userappdata}{#Navisworks2025}"; \
  Flags: ignoreversion recursesubdirs

Source: "{#ProjectRoot25}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2025}\en-US\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot25}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2025}\es-ES\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot25}\Resources\*"; \
  DestDir: "{userappdata}{#Navisworks2025}\Images\"; \
  Flags: ignoreversion recursesubdirs


; =========================
; ===== NAVISWORKS 2026 ===
; =========================
Source: "{#ProjectRoot26}\bin\Release\*.dll"; \
  DestDir: "{userappdata}{#Navisworks2026}"; \
  Flags: ignoreversion recursesubdirs

Source: "{#ProjectRoot26}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2026}\en-US\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot26}\Ribbon\IronPythonReader.xaml"; \
  DestDir: "{userappdata}{#Navisworks2026}\es-ES\"; \
  Flags: ignoreversion

Source: "{#ProjectRoot26}\Resources\*"; \
  DestDir: "{userappdata}{#Navisworks2026}\Images\"; \
  Flags: ignoreversion recursesubdirs


; =========================
; === PackageContents
; =========================
Source: "{#ProjectRoot26}\PackageContents.xml"; \
  DestDir: "{userappdata}\Autodesk\ApplicationPlugins\{#AssemblyName}.bundle\"; \
  Flags: ignoreversion


[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppAlias}.exe"