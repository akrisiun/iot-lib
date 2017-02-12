d:
cd %~dp0


@set msbuild="%ProgramFiles(x86)%\MSBuild\15.0\Bin\MSBuild.exe"
@if not exist %msbuild% @set msbuild="%ProgramFiles(x86)%\msbuild\14.0\Bin\MSBuild.exe"

%msbuild% /v:m UniversalBrowser1.sln /property:Configuration=Debug  /property:Platform=x64 

@PAUSE