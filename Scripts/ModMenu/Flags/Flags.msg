﻿[dlg Title_Flags]
Flags[w][e]

[sel Options_Flags]
Toggle by ID[f 4 26 0 2][e]
Toggle by Category[f 4 26 1 3][e]
Randomize Flags[f 4 26 2 4][e]
Print Enabled Flags[f 4 26 3 5][e] // Vanilla
Print Disabled Flags[f 4 26 4 6][e] // Vanilla

[dlg GENERIC_HELP_2]
[s]Choose an individual bitflag[n]or a range of flags[n]to turn on/off.[e]

[dlg GENERIC_HELP_3]
[s]Choose flags to turn on/off[n]from a list of categories.[e]

[dlg GENERIC_HELP_4]
[s]Randomly toggle a specified[n]percentage of all flags.[e]

[dlg GENERIC_HELP_5]
[s]Print a list of enabled flags[n]to the TTY log.[e]

[dlg GENERIC_HELP_6]
[s]Print a list of disabled flags[n]to the TTY log.[e] 

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
Set Individual Flag[f 4 26 0 11][e]
Set Start Range[f 4 26 1 12][e]
Set End Range[f 4 26 2 13][e]
Enable All Flags in Range[f 4 26 3 14][e]
Disable All Flags in Range[f 4 26 4 15][e]
Flip All Flags in Range[f 4 26 5 16][e]

[dlg GENERIC_HELP_11]
[s]Choose an individual bitflag[n]by ID and turn it[n]on or off.[e]

[dlg GENERIC_HELP_12]
[s]Choose the first flag to toggle[n]as part of a range.[e]

[dlg GENERIC_HELP_13]
[s]Choose the last flag to toggle[n]as part of a range.[e]

[dlg GENERIC_HELP_14]
[s]Turn on all flags in the[n]selected range.[e]

[dlg GENERIC_HELP_15]
[s]Turn off all flags in the[n]selected range.[e]

[dlg GENERIC_HELP_16]
[s]Give all flags in the[n]selected range their[n]opposite value.[e]

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