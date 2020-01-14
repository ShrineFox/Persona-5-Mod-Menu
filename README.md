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
1. Download the latest build of TGE's [AtlusScriptCompiler](https://ci.appveyor.com/project/TGEnigma/atlusscripttoolchain/build/artifacts) ([source](https://github.com/TGEnigma/AtlusScriptToolchain)), which you can use to compile the **.flow** and **.msg** scripts in this repository and recompile them into **.bf** format.
2. Also download [TGE's PAKTools](https://github.com/TGEnigma/AtlusFileSystemLibrary/releases).
3. Edit the build.bat file with the paths to your AtlusScriptCompiler and PAKTool exe files. Name your edited copy build_local.bat. Place the PAK files from your copy of the game in the input folder.
4. Run build_local.bat.

When you run the bat, the scripts will be compiled into BF files and packed into new PAK files.

There are 3 different scripts that must be recompiled:
- **field.bf** (for the field) found in **fldPack.pac**
- **dungeon.bf** (for palaces) found in **dngPack.pac**
- **at_dng.bf** (for mementos) found in **atDngPack.pac**
Each of the PAC files can be located in ps3.cpk\field.

In order to be able to use the Mod Menu before unlocking the square button functionality,
- **fscr0150_002_100.bf** must go in the \script\field folder of the mod.

In order to use the Amicitia UI logo for the menu,
- **sharedUI.spd** must go in the \camp\shared folder of the mod.
