### Git clone + build

```
git clone https://github.com/akrisiun/iot-lib.git iot-lib
iot-lib

cd win10
nuget.exe restore project.json -NonInteractive -Source https://api.nuget.org/v3/index.json
call msbuild
```

### Deploy, install AppX

standalone SDK download : Windows Kits\10\StandaloneSDK\Installers
https://dev.windows.com/en-us/downloads/windows-10-sdk

Powershell:
```
cd win10\bin\
Set-ExecutionPolicy Unrestricted
Show-WindowsDeveloperLicenseRegistration
./Add-AppDevPackage.ps1
```

