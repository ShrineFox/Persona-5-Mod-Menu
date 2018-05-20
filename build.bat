set PAKPACK="path to PAKPack.exe"
set COMPILER="path to AtlusScriptCompiler.exe"
set BUILD_PATH=.\build
set INPUT_PATH=%BUILD_PATH%\input
set OUTPUT_PATH=%BUILD_PATH%\output

if not exist %BUILD_PATH% mkdir %BUILD_PATH%
if not exist %INPUT_PATH% mkdir %INPUT_PATH%
if not exist %OUTPUT_PATH% mkdir %OUTPUT_PATH%

%COMPILER% .\field\field.bf.flow     -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\field.bf"
%COMPILER% .\dungeon\dungeon.bf.flow -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\dungeon.bf"
%COMPILER% .\mementos\at_dng.bf.flow -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\at_dng.bf"

%PAKPACK% replace "%INPUT_PATH%\fldPack.pac"   etc/field.bf   "%OUTPUT_PATH%\field.bf"   "%OUTPUT_PATH%\fldPack.pac"
%PAKPACK% replace "%INPUT_PATH%\dngPack.pac"   etc/dungeon.bf "%OUTPUT_PATH%\dungeon.bf" "%OUTPUT_PATH%\dngPack.pac"
%PAKPACK% replace "%INPUT_PATH%\atDngPack.pac" etc/at_dng.bf  "%OUTPUT_PATH%\at_dng.bf"  "%OUTPUT_PATH%\atDngPack.pac"

del "%OUTPUT_PATH%\field.bf"
del "%OUTPUT_PATH%\dungeon.bf"
del "%OUTPUT_PATH%\at_dng.bf"
