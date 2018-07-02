set PAKPACK="path to PAKPack.exe"
set COMPILER="path to AtlusScriptCompiler.exe"
set BUILD_PATH=.\build
set INPUT_PATH=%BUILD_PATH%\input
set OUTPUT_PATH=%BUILD_PATH%\output

if not exist %BUILD_PATH% mkdir %BUILD_PATH%
if not exist %INPUT_PATH% mkdir %INPUT_PATH%
if not exist %OUTPUT_PATH% mkdir %OUTPUT_PATH%
if not exist %OUTPUT_PATH%\camp\shared mkdir %OUTPUT_PATH%\camp\shared
if not exist %OUTPUT_PATH%\field mkdir %OUTPUT_PATH%\field
if not exist %OUTPUT_PATH%\script\field mkdir %OUTPUT_PATH%\script\field

copy .\camp\shared\sharedUI.spd "%OUTPUT_PATH%\camp\shared\sharedUI.spd"
%COMPILER% .\field\field.bf.flow     -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\field\field.bf"
%COMPILER% .\dungeon\dungeon.bf.flow -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\field\dungeon.bf"
%COMPILER% .\mementos\at_dng.bf.flow -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\field\at_dng.bf"
%COMPILER% .\introduction\fscr0150_002_100.bf.flow -Compile -OutFormat V3BE -Library P5 -Encoding P5 -Out "%OUTPUT_PATH%\script\field\fscr0150_002_100.bf"

%PAKPACK% replace "%INPUT_PATH%\fldPack.pac"   etc/field.bf   "%OUTPUT_PATH%\field\field.bf"   "%OUTPUT_PATH%\field\fldPack.pac"
%PAKPACK% replace "%INPUT_PATH%\dngPack.pac"   etc/dungeon.bf "%OUTPUT_PATH%\field\dungeon.bf" "%OUTPUT_PATH%\field\dngPack.pac"
%PAKPACK% replace "%INPUT_PATH%\atDngPack.pac" etc/at_dng.bf  "%OUTPUT_PATH%\field\at_dng.bf"  "%OUTPUT_PATH%\field\atDngPack.pac"

del "%OUTPUT_PATH%\field\field.bf"
del "%OUTPUT_PATH%\field\dungeon.bf"
del "%OUTPUT_PATH%\field\at_dng.bf"
