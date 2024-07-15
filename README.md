# ATTENTION PC/SWITCH USERS
**The latest update is not complete**, but a preview release for PC can be found [here](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases/tag/1.9). Thank you for your patience.  
This repository has been restructured to support building for P5 PS3, as well as P5R on consoles and PC. These changes make it easier to maintain the mod on all platforms while keeping changes in sync.  
You can expect a full release as soon as bugs have been sufficiently fixed ([track progress here](https://trello.com/c/On4NnqmQ/54-persona-5r-mod-menu-update).)

# Persona 5 (Royal) Mod Menu
**Custom scripts for P5 & P5R that replace the square button function with a fully featured trainer**
![Image of the menu ingame](https://cdn.discordapp.com/attachments/428021649246388224/447597680018063372/unknown.png)
## Notable Features
- Add Personas, add skills to any party member's currently equipped Persona, delete all Personas currently in the protagonist's stock
- Add points to your stats (Knowledge, Guts, Charm etc.)
- Add a specified quantity of any item, armor, weapon etc.
- Change your rank with any confidant and unlock their abilities instantly
- Change the protagonist's/team's name at any time
- Clip through walls and explore hidden areas
- Load encounters, music, fields, events, animations, effects and models from filename IDs
- Manipulate the camera (reposition, lock, unlock, rotate, zoom, change FOV)
- Toggle the HUD, navigator character, party members, romance flags and more
- Instantly change the current date and weather
- Add Personas and change you or your party members' Skills

## Installing the Mod
### PS3, PS4 & Switch
1. Read about [how to add Mod Support to your target platform](https://docs.shrinefox.com/).
2. Get the latest [Aemulus .zip](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases) for your version of the game.
3. Extract to the ``Packages`` folder of [Aemulus Package Manager](https://github.com/TekkaGB/AemulusModManager/releases).
4. Click ``Build`` to merge this mod with other mods of your choice.

### PC
1. Read about [how to add Mod Support](https://docs.shrinefox.com/getting-started/persona-5-royal-pc-mod-support) to the PC version using ReloadedII.
2. Get the latest [Reloaded .zip](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases). 
3. Extract to the ``Mods`` folder of [Reloaded II](https://github.com/Reloaded-Project/Reloaded-II).
4. Enable the mod and launch the game via Reloaded II.

## Editing the Menu
If you'd like to make changes to the script and build your own version of the mod, follow these steps.  
1. Download ``ModMenuBuilder.zip`` from the [latest release](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases).
2. Extract it and run ``ModMenuBuilder.exe``.
3. Download and extract ``AtlusScriptCompiler``. Add the path to the ``.exe`` in the ModMenuBuilder.
4. Set the directory where you want the Mod Menu output to be built. i.e. ``Steam\steamapps\common\P5R\Reloaded\Mods\p5rpc.misc.modmenu\P5REssentials\CPK\EN.CPK``
5. Click Build and it will compile the scripts to the output folder.  
![Image of ModMenuBuilder program](https://i.imgur.com/mMTTcI3.png)  
See [the project's Wiki](https://github.com/ShrineFox/Persona-5-Mod-Menu/wiki) to better understand the Builder's usage, features and settings.  
See [this tutorial](https://docs.shrinefox.com/flowscript/intro-to-scripting) for getting started editing flowscript.

## Building From Source
Follow these instructions if you would like to edit the builder program itself.  
1. Clone this repository using [Git](https://git-scm.com/downloads) or [GitHub Desktop](https://desktop.github.com/).
2. Run the solution (``.sln``) file with Visual Studio.
3. Also clone [AtlusFileSystemLibrary](https://github.com/tge-was-taken/AtlusFileSystemLibrary), [SimpleCommandLine](https://github.com/tge-was-taken/SimpleCommandLine), and [ShrineFox.IO](https://github.com/ShrineFox/ShrineFox.IO) to the same location, as they are referenced by the project.
4. Open ``ModMenuBuilder.sln`` in [Visual Studio](https://visualstudio.microsoft.com/).
5. Modify any of the ``.flow`` or ``.msg`` files in the project, or the builder code itself.
6. Click ``Start`` to run the program.
7. Provide the paths to ``AtlusScriptCompiler.exe`` and your output folder (this varies by platform, see Mod Support guides linked earlier).
8. Check "Reindex Messages" to recompile scripts with fixed description text. This can take awhile, so it's recommended to disable while testing.
9. Click the ``Build`` button to output the final, compiled scripts to your destination.  

## Contributing to the Repository
2. Create your own fork of the project.
3. Make any changes you want to the builder code or source scripts.
4. Commit the changes to your fork.
5. Open a pull request on this repository by comparing it to your fork.
6. Your changes will be reviewed and merged once approved.
You don't need to use Visual Studio if you're only editing the ``.flow`` and ``.msg`` files.  
If you already used the prebuilt ModMenuBuilder to edit scripts, copy and paste your ``Scripts`` folder into the cloned solution folder, and overwrite the contents.

## FAQ
### Why Create a Builder?
Previously, a simple ``build.bat`` batch script was used to facilitate repacking and compiling the Mod Menu from ``.flow``/``.msg``. A separate repository was made for Royal when it released on PS4, but since Royal has different flowscript functions (some new, some missing from vanilla), different bitflag values, and different input files, keeping changes to both repositories in sync was a nightmare.  
Not to mention, between different scripts and different versions of the game, message IDs will no longer match, causing description text to become misaligned-- which must be corrected by an external program.  
By integrating all this functionality into a single program that lives in the same repository, I was able to easily support future Mod Menu development on all platforms from a single codebase.

### Does it bring Royal features to P5 (PS3)?
No, incompatible features are simply removed when building for PS3. If you want to add Royal features to the PS3 version, check out the [Persona 5 EX mod](https://gamebanana.com/wips/57221) by DeathChaos25.

### What features are specific to Royal?
At present, the Royal version is more or less identical to the PS3 version. But planned special features for Royal include:
- Support for managing new Confidants, Party Members, Items, Skills, Personas, Bosses etc.
- Setting the player level (this was previously not possible through flowscript on PS3)
- Use of the Theives Tool menu in palaces/mementos (replaces the Auto-Recover function from PS3)
- More?
You can already load Royal-specific fields/events/battles and toggle Royal-specific flags by filename.

### Where can I get help?
If you have questions about editing flowscript, you can check out [this guide](https://docs.shrinefox.com/flowscript/intro-to-scripting).  
Create a thread on [my troubleshooting forum](https://shrinefox.com/forum) if you have any further questions about script mods.  
If you encounter a bug using the menu or builder, [Open an Issue](https://github.com/ShrineFox/Persona-5-Mod-Menu/issues) on this repository and describe what's going on.

### How can I support the project?
If you find this project enjoyable or helpful, please consider sending me a tip on [Ko-Fi](https://ko-fi.com/shrinefox)!
