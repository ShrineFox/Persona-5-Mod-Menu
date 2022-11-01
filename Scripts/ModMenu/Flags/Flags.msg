[msg Flags]
[w][e]

[dlg Title_Flags]
Flags[w][e]

[sel Options_Flags]
Toggle by ID[ref 0 2][e]
Toggle by Category[ref 1 3][e]
Randomize Flags[ref 2 4][e]
Print Enabled Flags[ref 3 5][e] // Vanilla
Print Disabled Flags[ref 4 6][e] // Vanilla

[dlg GENERIC_HELP_2]
Choose an individual bitflag[n]or a range of flags[n]to turn on/off.[e]

[dlg GENERIC_HELP_3]
Choose flags to turn on/off[n]from a list of categories.[e]

[dlg GENERIC_HELP_4]
Randomly toggle a specified[n]percentage of all flags.[e]

[dlg GENERIC_HELP_5]
Print a list of enabled flags[n]to the TTY log.[e]

[dlg GENERIC_HELP_6]
Print a list of disabled flags[n]to the TTY log.[e] 

[dlg Message_RandomizeFlags]
Enter the percent chance out of
[n]100 that each flag may
[n]randomly be toggled.[w][e]

[dlg Message_RandomizeComplete]
Flags have been [clr 1][f 2 4 0][clr 0]% randomized.
[n]have fun![w][e]

[dlg Title_ToggleFlagsByID]
Toggle Flags by ID[w][e]

[sel Options_ToggleFlagsByID]
Set Individual Flag[ref 0 11][e]
Set Start Range[ref 1 12][e]
Set End Range[ref 2 13][e]
Enable All Flags in Range[ref 3 14][e]
Disable All Flags in Range[ref 4 15][e]
Flip All Flags in Range[ref 5 16][e]

[dlg GENERIC_HELP_11]
Choose an individual bitflag[n]by ID and turn it[n]on or off.[e]

[dlg GENERIC_HELP_12]
Choose the first flag to toggle[n]as part of a range.[e]

[dlg GENERIC_HELP_13]
Choose the last flag to toggle[n]as part of a range.[e]

[dlg GENERIC_HELP_14]
Turn on all flags in the[n]selected range.[e]

[dlg GENERIC_HELP_15]
Turn off all flags in the[n]selected range.[e]

[dlg GENERIC_HELP_16]
Give all flags in the[n]selected range their[n]opposite value.[e]

[dlg Message_ConfirmEnableRange]
Are you sure you want to set
[n]Flags [clr 1][f 2 4 0][clr 0] through [clr 1][f 2 4 1][clr 0]
[n]to [clr 13]On[clr 0]?[w][e]

[dlg Message_ConfirmDisableRange]
Are you sure you want to set
[n]Flags [clr 1][f 2 4 0][clr 0] through [clr 1][f 2 4 1][clr 0]
[n]to [clr 9]Off[clr 0]?[w][e]

[dlg Message_ConfirmFlipRange]
Are you sure you want to set
[n] Flags[clr 1][f 2 4 0][clr 0] through [clr 1][f 2 4 1][clr 0]
[n]to [clr 17]their opposite value[clr 0]?[w][e]

[dlg Message_ToggleRangeComplete]
The selected range has been
[n]successfully toggled.[w][e]