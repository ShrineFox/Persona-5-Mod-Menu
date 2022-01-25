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
- Load encounters, music, fields, events, animations, and models from filename IDs
- Manipulate the camera (reposition, lock, unlock, rotate, change FOV)
- Toggle the HUD, navigator character, party members, romance flags and more
- Instantly change the current date and weather
- Add Personas and change you or your party members' Skills
## Generating the Mod
1. Get the latest [release .zip](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases) for your version of the game.
2. Extract to the ``Packages`` folder of [Aemulus Package Manager](https://github.com/TekkaGB/AemulusModManager/releases), or the ``Mods`` folder of the [Mod Compendium](https://github.com/tge-was-taken/Mod-Compendium).
Note: Aemulus does not support P5R yet.
3. Build a ``mod.cpk`` to include this mod with other mods of your choice.

You can also download a [release mod.cpk](https://github.com/ShrineFox/Persona-5-Mod-Menu/releases) if you don't need to use other mods and want to skip the mod manager step.
## Installing the Mod
These steps vary by platform.
### Persona 5 (PS3) on RPCS3
1. Install [RPCS3](https://rpcs3.net/).
2. Install Persona 5.
3. Download a ``patch.yml`` from my website's [PS3 Patch Generator](https://shrinefox.com/apps/PatchCreator).
Note: Either P5 EX or Mod Support will suffice for loading the mod.  
If you choose P5 EX, [follow the instructions here](https://gamebanana.com/wips/57221) carefully.
4. Place ``patch.yml`` in the RPCS3 ``patches`` folder.
5. Start RPCS3 and go to ``Manage > Game Patches`` and enable Mod Support (or P5EX+Mod SPRX).
6. Place your ``mod.cpk`` in the game's ``USRDIR`` folder (right click the game in RPCS3 and choose ``Open Install Folder``.)
7. Start the game! Pressing Square should bring up the menu.
### Persona 5 (PS3) on Rebug CFW
1. Install [Rebug CFW](https://www.psxhax.com/threads/rebug-4-86-1-lite-ps3-cfw-with-cobra-8-2-and-toolbox-2-03-04.7401/).
2. Download a ``patch.yml`` from my website's [PS3 Patch Generator](https://shrinefox.com/apps/PatchCreator).
Note: P5EX does not work on consoles, so you need the Mod Support patch.  
ALSO: you need to download the ``patch.yml`` in the "old format."
3. Patch your ``eboot.bin`` by following [these steps](https://shrinefox.com/guides/2019/06/12/persona-5-ps3-eboot-patching/).
4. Transfer your patched ``eboot.bin`` and ``mod.cpk`` to your game's USRDIR.
5. Start the game and press Square to use the menu!
### Persona 5 Royal on PS4 (HEN)
1. Follow [this guide](https://shrinefox.com/guides/2020/09/30/modding-persona-5-royal-on-ps4/) to run HEN on your PS4.
2. Install a FPKG of P5R.
3. Download a patched update from my [PS4 Update Creator](https://shrinefox.com/apps/UpdateCreator).
NOTE: If your P5R FPKG doesn't match mine, you'll have to [manually create your own](https://shrinefox.com/guides/2021/12/28/manually-patching-ps4-persona-games/) patched update ``.PKG``.
4. Install the update ``.PKG``.
5. Transfer your ``mod.cpk`` to ``/data/p5r`` on your PS4.
6. Start the game! If all went well, you should be able to use the menu by pressing Square.

## Building the Mod Menu from Source
1. Download and unzip the latest [Atlus-Script-Tools by TGE](https://github.com/tge-was-taken/Atlus-Script-Tools).
2. Open a new command prompt window.
3. Enter the path to ModMenuBuilder.exe. Running it will give you a rundown of its usage.  
Example: ``ModMenuBuilder.exe -c C:\Path\To\AtlusScriptCompiler.exe -g P5R``
4. Edit the ``.msg`` and ``.flow`` files to your liking in the ``.\Scripts`` folder.
5. When you run ``ModMenuBuilder.exe``, ``.\Assets`` and ``.\Scripts`` will be copied to a ``.\Temp`` folder and modified.
6. Output will go to a ``.\Output`` folder, unless a path is specified with ``-o``. Existing files will be overwritten.
### How It Works
- Depending on your selection of game (``P5``/``P5R``), import paths in the ``.flow`` files will be altered to reference ``Vanilla`` or ``Royal`` subfolders.
- Blocks of code in ``ModMenu.flow`` will be commented out depending on if they are between ``/* Royal Start */`` and ``/* Royal End */``, or ``/* Vanilla Start */`` and ``/* Vanilla End */`` lines (respective to the specified game).
- Similarly, lines in ``ModMenu.msg`` ending with ``// Royal`` or ``// Vanilla`` will be removed depending on game.
- Different message indexes will be used for menu item descriptions depending on game.
- If Royal is selected, bitflag values will be auto-converted for compatibility.
- ``.PAC`` files are automatically unpacked and repacked with changed files.

## Contributing to the Repository
1. Clone this repository using [Git](https://git-scm.com/downloads) or [GitHub Desktop](https://desktop.github.com/).
2. Run the solution (``.sln``) file with Visual Studio.
3. Also clone [AtlusFileSystemLibrary](https://github.com/tge-was-taken/AtlusFileSystemLibrary) and [SimpleCommandLine](https://github.com/tge-was-taken/SimpleCommandLine) by TGE since they are referenced.
4. Make any changes you want to the builder code or source scripts, create a fork, and make a pull request.
5. Preferably, make sure both P5 and P5R still compile.
6. Your changes will be reviewed and merged if appropriate!

## FAQ
### Why Create a Builder?
Previously, a simple ``build.bat`` batch script was used to facilitate repacking and compiling the Mod Menu from ``.flow``/``.msg``, along with a ``MsgReindex.exe`` that handled updating the message indexes. A [forked repository was created for Royal](https://github.com/Amicitia/Persona-5-Royal-Mod-Menu/), but since Royal has different flowscript functions (some new, some missing from vanilla), different bitflag values, and different input files, keeping changes to both repositories in sync was a nightmare.  
By integrating the functionality of the old ``build.bat`` and ``MsgReindex.exe`` into one program that lives in the same repository, I could add additional features that can build P5 (PS3) and P5R from the same source scripts, as detailed above. This way, all changes can be made to a single repository, so the two versions will never become out of sync.

### Since this works for both, does it bring Royal features to P5 (PS3)?
No, incompatible features are simply removed when building for PS3. If you want to add Royal features to the PS3 version, at least if you're using RPCS3, look into the [Persona 5 EX mod](https://gamebanana.com/wips/57221) by DeathChaos25.

### What features are specific to Royal?
At present, the Royal version is more or less identical to the PS3 version. But planned special features for Royal include:
- Support for managing new Confidants, Party Members, Items, Skills, Personas, Bosses etc.
- Setting the player level (this was previously not possible through flowscript on PS3)
- Use of the Theives Tool menu in palaces/mementos (replaces the Auto-Recover function from PS3)
- More?
You can already load Royal-specific fields/events/battles and toggle Royal-specific flags by filename.

### Where can I get help?
If you have questions about editing flowscript, you can check out these incomplete docs.  
Further questions can be asked at my forum. If you encounter a bug using the menu or builder, open an Issue.

### How can I support the project?
[Ko-Fi](https://ko-fi.com/shrinefox)!
