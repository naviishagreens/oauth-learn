setlocal
@echo off
cd %~dp0
cd..

dotnet clean
dotnet build