@REM %1 - $(ProjectDir)

CheckFileHasModified\CheckFileHasModified.exe %1\Controllers\api\api.yaml
IF %ERRORLEVEL% EQU 0 GOTO EXIT

YamlToNSwag\YamlToNSwag.exe %1\Controllers\api\api.yaml %1\Controllers\api\es-api.nswag
IF %ERRORLEVEL% NEQ 0 GOTO EXIT

call nswag run %1\Controllers\api\es-api.nswag
IF %ERRORLEVEL% NEQ 0 GOTO EXIT

CheckFileHasModified\CheckFileHasModified.exe %1\Controllers\api\api.yaml -s

:EXIT
exit /b %ERRORLEVEL%