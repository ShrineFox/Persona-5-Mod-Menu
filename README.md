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

## Building the Mod Menu from Source
Follow these instructions if you would like to make edits to the menu, whether for your own purposes or to contribute to the project.
1. Clone this repository using [Git](https://git-scm.com/downloads) or [GitHub Desktop](https://desktop.github.com/).
2. Run the solution (``.sln``) file with Visual Studio.
3. Also clone [AtlusFileSystemLibrary](https://github.com/tge-was-taken/AtlusFileSystemLibrary), [SimpleCommandLine](https://github.com/tge-was-taken/SimpleCommandLine), and [ShrineFox.IO](https://github.com/ShrineFox/ShrineFox.IO) to the same location, as they are referenced by the project.
4. Open ``ModMenuBuilder.sln`` in [Visual Studio](https://visualstudio.microsoft.com/).
5. Modify any of the .flow or .msg files in the project, or the builder code itself.
6. Click ``Start`` to run the program.
7. Provide the paths to ``AtlusScriptCompiler.exe`` and your output folder (this varies by platform, see Mod Support guides linked earlier).
8. Check "Reindex Messages" to recompile scripts with fixed description text. This can take awhile, so it's disabled by default for easy testing.
9. Click the ``Build`` button to output the final, compiled scripts to your destination.

## Contributing to the Repository
2. Create your own fork of the project.
3. Make any changes you want to the builder code or source scripts.
4. Commit the changes to your fork.
5. Open a pull request on this repository by comparing it to your fork.
6. Your changes will be reviewed and merged once approved.

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
