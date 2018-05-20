# Persona 5 Mod Menu
**Custom scripts for Persona 5 that replace the square button function with a fully featured trainer**
![Image of the menu ingame](https://cdn.discordapp.com/attachments/428021649246388224/447597680018063372/unknown.png)
## Notable Features
- Add Personas, add skills to any party member's currently equipped Persona, delete all Personas currently in the protagonist's stock
- Add points to your stats (Knowledge, Guts, Charm etc.)
- Add a specified quantity of any item, armor, weapon etc.
- Change your rank with any confidant and unlock their abilities instantly
- Change the protagonist's/team's name at any time
- Clip through walls and explore hidden areas
- Load encounters, music, fields, events, animations, and models from filename IDs
- Manipulate the camera (reposition, lock, unlock, rotate, change FOV)
- Toggle the HUD, navigator character, party members, romance flags and more
- Instantly change the current date and weather
- Add Personas and change you or your party members' Skills
## Usage
Once you've added [mod.cpk support](https://shrinefox.github.io/guides/p5/mod-cpk) to your copy of Persona 5 (PS3), you can use the [Mod Compendium](https://shrinefox.github.io/guides/p5/mod-compendium) to run the [latest compiled Release](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases) in-game.
## Compiling
Using TGE's [AtlusScriptCompiler](https://github.com/TGEnigma/AtlusScriptToolchain), you can edit the **.flow** and **.msg** scripts in this repository and recompile them into **.bf** format.
For example, move the Utility.flow, Utility.msg and Math.flow files to the same folder as the script you're compiling and run:
> "M:\Tools\AtlusScriptCompiler.exe" "M:\ModMenu\field\field.bf.flow" -Compile -OutFormat V3BE -Library P5 -Encoding P5

This will output a new field.bf file, which will include the mod menu and other referenced scripts.

There are 3 different scripts that must be recompiled:
- **field.bf** (for the field) found in **fldPack.pac**
- **dungeon.bf** (for palaces) found in **dngPack.pac**
- **at_dng.bf** (for mementos) found in **atDngPack.pac**

Each of the PAC files can be located in ps3.cpk\field. To easily repack all scripts at once, make a batch file like the following using [TGE's PAKTools](https://github.com/TGEnigma/AtlusFileSystemLibrary/releases):
> PAKPack.exe replace INPUTPATH\fldPack.pac etc/field.bf INPUTPATH\field.bf.flow.bf OUTPUTPATH\fldPack.pac

> PAKPack.exe replace INPUTPATH\dngPack.pac etc/dungeon.bf INPUTPATH\dungeon.bf.flow.bf OUTPUTPATH\dngPack.pac

> PAKPack.exe replace INPUTPATH\atDngPack.pac etc/at_dng.bf INPUTPATH\at_dng.bf.flow.bf OUTPUTPATH\at_DngPack.pac
