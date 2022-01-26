
setlocal
@echo off
cd %~dp0

if not defined configuration (
    set configuration=Release
)

if not defined build (
    set build=true
)

REM build naviisha.common
setlocal
    if %build%==true (
        cd.. 
        cd naviisha.common
        dotnet build -c %configuration%
    )
endlocal

@REM build authorization server
setlocal
    cd..
    cd AuthorizationServer

    if %build%==true (
        dotnet build -c %configuration%
    )

    dotnet publish -c %configuration%
    cd bin/%configuration%/publish
    start dotnet AuthorizationServer.dll
endlocal


@REM build student api
setlocal
    cd..
    cd studentapi

    if %build%==true (
        dotnet build -c %configuration%
    )

    dotnet publish -c %configuration%
    cd bin/%configuration%/publish
    start dotnet studentapi.dll
endlocal


@REM build teacherapi api
setlocal
    cd..
    cd teacherapi

    if %build%==true (
        dotnet build -c %configuration%
    )

    dotnet publish -c %configuration%
    cd bin/%configuration%/publish
    start dotnet teacherapi.dll
endlocal
