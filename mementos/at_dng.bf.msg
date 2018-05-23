[msg DUMMY_MSG]
[s]dummy at_dng[n][w][e]

[sel YESNO_SEL]
[s]Yes[e]
[s]No[e]

[msg MSG_ALERT_UP [モルガナ]]
[s][bup 0 3 0 0 0]dummy at_dng[n][w][e]

[msg MSG_ALERT_DOWN [モルガナ]]
[s][bup 0 3 0 0 0]dummy at_dng[n][w][e]

[msg MAP_SEARCH0 [モルガナ]]
[s][vp 1 0 0 8273 0 0]Analyzing the field...[n][f 1 6 -1][e]

[msg MAP_SEARCH1 [モルガナ]]
[s][vp 1 0 0 8274 0 0]Let's see here...[n]What's it like?[n][f 1 6 -1][e]

[msg MAP_SEARCH2 [モルガナ]]
[s][vp 1 0 0 8275 0 0]Starting the search![n][f 1 6 -1][e]

[msg MAP_SYSTEM]
[s]Futaba's Mementos Scan ability has[n]identified everything on this floor.[n][w][e]

[sel START_CHECK_SEL]
[s]Head to most recent safe room[e]
[s]Infiltrate as is[e]
[s]Don't go in yet[e]

[msg START_CHECK_MES [Morgana]]
[s][bup 0 3 0 -1 0]So, where do you want[n]to start exploring from?[n][w][e]

[msg START_CHECK_MES_NEXT [Morgana]]
[s][bup 0 3 0 -1 0]Make sure you choose your[n]starting location carefully.[n][w][e]

[sel DUNGEON_EXIT_SEL]
[s]*Special[e]
[s]Return to the real world[e]
[s]Don't leave yet[e]

[sel DUNGEON_EXIT_154_SEL]
[s]Go to the city[e]
[s]Return to the real world[e]
[s]Don't leave yet[e]

[sel DUNGEON_EXIT_155_SEL]
[s]Go to the city[e]
[s]Return to the real world[e]
[s]Don't leave yet[e]

[msg D01_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Kamoshida's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D02_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Madarame's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D03_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Kaneshiro's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D04_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Futaba's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D05_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Okumura's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D06_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Niijima's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D07_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real world[n]from Shido's Palace. Thank[n]you for your hard work.[n][w][e]

[msg D08_EXIT_MES [Metaverse Navigator]]
[s]Now returning to the real[n]world from Mementos. Thank[n]you for your hard work.[n][w][e]

[msg DUNGEON_ROUTE_COMP_PC03_ [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We've secured our route[n]to the Treasure... Do you[n]want to get out of here?[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC02 [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We're already goin' back?[n]We haven't done nothing...[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC03 [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What's wrong, Joker? We[n]haven't done anything yet.[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC04 [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Huh? You want to go home already?[n]But we haven't done anything.[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC05 [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What seems to be the matter? We[n]have yet to explore at all today.[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC06 [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What's wrong? You want to go[n]back despite our not yet having [n]done anything in here?[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC07 [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Huh? We're going home, Joker?[n]It feels like we haven't even[n]done anything today.[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC08 [Haru]]
[s][bup 0 7 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Joker, what's the matter?[n]We haven't managed to do a[n]single thing so far today.[n][w][e]

[msg DUNGEON_EXIT_NOT_01_PC09 [Akechi]]
[s][bup 0 9 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Hm? You wish to return? But we[n]have yet to accomplish anything[n]meaningful in our time here.[n][w][e]

[msg DUNGEON_EXIT_01_PC02_mes [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What's up? You wanna[n]head back and regroup?[n][w][e]

[msg DUNGEON_EXIT_01_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Hm? Are we retreating, Joker?[n][w][e]

[msg DUNGEON_EXIT_01_PC04_mes [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What's wrong? Do you want[n]to pull out of here?[n][w][e]

[msg DUNGEON_EXIT_01_PC05_mes [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Shall we regroup, Joker?[n][w][e]

[msg DUNGEON_EXIT_01_PC06_mes [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Hm? You want to head back?[n][w][e]

[msg DUNGEON_EXIT_01_PC07_mes [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]It might be a good idea[n]to go home and regroup.[n][w][e]

[msg DUNGEON_EXIT_01_PC08_mes [Haru]]
[s][bup 0 7 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Is it time for us to retreat?[n][w][e]

[msg DUNGEON_EXIT_01_PC09_mes [Akechi]]
[s][bup 0 9 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Oh? Are we retreating?[n][w][e]

[msg D_EXIT_OK_01_PC02_mes [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Mkay, let's get goin'.[n][w][e]

[msg D_EXIT_OK_01_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Mm, let's head back for today.[n][w][e]

[msg D_EXIT_OK_01_PC04_mes [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]OK, let's go.[n][w][e]

[msg D_EXIT_OK_01_PC05_mes [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Hm, very well. Let us head back.[n][w][e]

[msg D_EXIT_OK_01_PC06_mes [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]OK, we can call it a day.[n][w][e]

[msg D_EXIT_OK_01_PC07_mes [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Aw yeah, let's go home![n][w][e]

[msg D_EXIT_OK_01_PC08_mes [Haru]]
[s][bup 0 7 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Very well. Let's head home.[n][w][e]

[msg D_EXIT_OK_01_PC09_mes [Akechi]]
[s][bup 0 9 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]That is a good idea. In that[n]case, let us get out of here.[n][w][e]

[sel DUNGEON_EXIT_151_EX_SEL]
[s]*Special[e]
[s]Activate the [clr 6]Metaverse Nav[clr 27][e]
[s]Don't activate the nav[e]

[msg DUNGEON_EXIT_D01_EX_mes [Ryuji]]
[s][bup 0 2 0 -1 0]If we use that nav thing around[n]here, I'm thinkin' it'll get[n]us back to the real world.[n][w][e]

[msg D_EXIT_OK_D01_EX_mes [Ryuji]]
[s][bup 0 2 0 -1 0]Sweet, it worked![n][w][e]

[msg D_EXIT_NG_D01_EX_mes [Ryuji]]
[s][bup 0 2 0 -1 0]What're you doin'?[n]Let's get outta here![n][w][e]

[msg D_EXIT_CANCEL_PC02_mes [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Mkay. I can keep goin'[n]if that's what you want.[n][w][e]

[msg D_EXIT_CANCEL_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Right. Well then, let's[n]continue our exploration.[n][w][e]

[msg D_EXIT_CANCEL_PC04_mes [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]OK, let's look around in[n]here a little bit longer then.[n][w][e]

[msg D_EXIT_CANCEL_PC05_mes [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]I agree. I expect there[n]are still places yet unseen.[n][w][e]

[msg D_EXIT_CANCEL_PC06_mes [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Hm, yes. I think we can[n]still keep going for now.[n][w][e]

[msg D_EXIT_CANCEL_PC07_mes [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Gotcha. Let's hang in[n]there a bit longer.[n][w][e]

[msg D_EXIT_CANCEL_PC08_mes [Haru]]
[s][bup 0 7 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Mm-hm. Well, let's get[n]back to our exploration.[n][w][e]

[msg D_EXIT_CANCEL_PC09_mes [Akechi]]
[s][bup 0 9 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Very well, let us push[n]onward a bit further.[n][w][e]

[msg ALERT_MAX_EXIT_mes00 [Morgana]]
[s][bup 0 3 4 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0][vp 8 2 1 1039 -1 0]Ngh, this is bad! The security[n]level in here is too high![n][w][e]
[s][bup 0 3 2 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Our lives will be in danger if[n]we keep exploring any longer.[n][w][e]
[s]We need to retreat, Joker![n][w][e]

[msg ALERT_MAX_EXIT_mes01 [Ryuji]]
[s][bup 0 2 104 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0][vp 8 2 1 7044 -1 0]J-Just hold a sec. We could[n]prolly go a little--[n][w][e]

[msg ALERT_MAX_EXIT_mes02 [Morgana]]
[s][bup 0 3 3 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0][vp 8 2 1 1082 -1 0]The number of Shadows is[n]rapidly increasing! We need[n]to leave! Hurry![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC02 [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Dude, what!? We already[n]sent the calling card![n][w][e]
[s]All that hard work's gonna be[n]for nothing if we don't steal[n]the Treasure today![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC03 [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]What? Have you not been[n]listening to anything I say!?[n][w][e]
[s]If we don't take the Treasure[n]today, everything we've done[n]up to now will go to waste![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC04 [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Nope! Not happening![n]Absolutely, definitely not![n][w][e]
[s]All our preparation will go[n]right out the window if we[n]don't take the Treasure today![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC05 [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]You want to head back...? Haha,[n]it is rare to hear you joke in[n]such a manner during a mission.[n][w][e]
[s]Let us return to the[n]task at hand, Joker.[n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC06 [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Come now, no complaining.[n]Are you not our leader?[n][w][e]
[s]We must take the Treasure[n]today, no matter the cost![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC07 [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Kk, let's go home...[n][w][e]
[s]Uh... That was a joke.[n]No going home now.[n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC08 [Haru]]
[s][bup 0 7 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]I thought we can't pull out once[n]we send the calling card...[n][w][e]
[s]Don't worry, Joker. You[n]have all of our support![n][w][e]

[msg D_EXIT_NG_ACTIVE_01_PC09 [Akechi]]
[s][bup 0 9 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]You wish to leave after coming[n]this far? How unlike you.[n][w][e]
[s]We should try to do this today[n]though. I will lend you my aid.[n][w][e]

[msg SAFEROOM_EXIT_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]You really want to head[n]back, Joker?[n][w][e]

[msg SAFEROOM_EXIT_PC07_mes [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We really heading home, Joker?[n][w][e]

[msg D01_04_e166_015_mes01 [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Mkay, all we gotta do now is[n]steal the Treasure that shows up,[n]yeah? It's finally time.[n][w][e]

[msg D01_04_e166_015_mes02 [Ann]]
[s][bup 0 4 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]But we need to send the calling[n]card first. When should we do it?[n][w][e]

[msg D01_04_e166_015_mes03 [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Just hold on. Let's retreat for[n]now, then we can talk more about[n]that stuff back at the hideout.[n][w][e]
[s]Oh, and well done today![n][w][e]

[msg D02_MISSION_POINT_PC03_m [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We should leave and try to[n]disengage the courtyard security.[n][w][e]

[msg D02_04_e210_240_mes01 [Ryuji]]
[s][bup 0 2 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Well, I'm still kinda worried...[n]but we gotta do this.[n][w][e]

[msg D02_04_e210_240_mes02 [Yusuke]]
[s][bup 0 5 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]I cannot even begin to fathom[n]what Madarame's Treasure may be...[n][w][e]

[msg D02_04_e210_240_mes03 [Ann]]
[s][bup 0 4 101 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Either way, we'll steal it[n]for sure. Oh, and you all[n]did great today![n][w][e]

[msg D03_FIRST_END_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]You're right. All we can do[n]right now is retreat.[n][w][e]

[msg D06_FIRST_END_PC06_mes [Makoto]]
[s][bup 0 6 100 0 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We'll need to regroup back[n]in the real world for now.[n][w][e]

[msg D07_FIRST_END_PC03_mes [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]All right, Joker. Let's retreat![n][w][e]

[msg D01_EXIT_NG_EV01_mes01 [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]Where are you going, Joker?[n][w][e]
[s]Haven't we checked those cells[n]enough? Let's look further[n]inside the castle next.[n][w][e]

[msg D01_EXIT_NG_EV01_mes02 [Morgana]]
[s][bup 0 3 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]We'll have to pass through the[n]entrance hall to get there...[n]but wasn't the door locked?[n][w][e]
[s]It'll be impossible unless we[n]can find another route to the[n]first floor of that hall.[n][w][e]

[msg D07_DUNGEON_EXIT_SC_mes0 [Ryuji]]
[s][bup 0 2 0 -1 0][f 4 10 -1 0 0][f 4 25 1 -1 0 0]C'mon, we came all this way.[n]Let's at least try checkin'[n]around a little more first.[n][w][e]

[sel RARE_TBOX_YES_NO]
[s]Open the chest[e]
[s]Ignore it for now[e]

[msg RARE_TBOX_MSG_M [Morgana]]
[s][bup 0 3 2 0 0][f 4 10 -1 0 0][vp 8 2 0 1167 -1 0]Huh, it's locked...[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_M [Morgana]]
[s][bup 0 3 5 0 0][f 4 10 -1 0 0]It's too bad we don't have[n]a [f 2 5 3 -1 0] right now.[n]Let's make some later.[n][w][e]

[msg RARE_TBOX_MSG_KEY_CONF_M [Morgana]]
[s][bup 0 3 0 0 0][f 4 10 -1 0 0]It needs a [f 2 5 3 -1 0]...[n]We have [f 2 4 1] of those.[n]Want to open it?[n][w][e]

[msg RARE_TBOX_MSG_F [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0][vp 8 2 0 9114 -1 0]Eh? This treasure chest has[n]a nice hefty lock on it.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_F [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0]But your [f 2 5 3 -1 0] count's[n]down at zero. Maybe next time[n]remember to bring some in.[n][w][e]

[msg RARE_TBOX_MSG_CONF_F [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0]Looks like you actually have a[n][f 2 5 3 -1 0]! [f 2 4 1], to be[n]exact. Let's open this baby up![n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_1ST [Morgana]]
[s][bup 0 3 11 0 0][f 4 10 -1 0 0]In order to open these treasure[n]chests, you need a special[n]tool called a [f 2 5 3 -1 0].[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_1ST2 [Futaba]]
[s][bup 0 8 104 0 0][f 4 10 -1 0 0]A thief who can't make a [f 2 5 3 -1 0][n]by himself? That's surprising.[n][w][e]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0]Have Morgana teach you how[n]once you get home.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_2ND [Morgana]]
[s][bup 0 3 0 0 0][f 4 10 -1 0 0]I've mentioned this before, but I[n]wouldn't mind teaching you how to[n]make a [f 2 5 3 -1 0] sometime.[n][w][e]
[s]Well, I guess that can wait[n]until we get home.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_2ND2 [Futaba]]
[s][bup 0 8 100 0 0][f 4 10 -1 0 0]Wait, you still don't know how[n]to make a [f 2 5 3 -1 0]...?[n][w][e]
[s]Get Morgana to teach you[n]once you get home.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_ADD [Morgana]]
[s][vp 8 2 0 1169 -1 0][bup 0 3 3 0 0][f 4 10 -1 0 0]...Though I guess your desk[n]is probably too damn messy[n]for that right now.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_ADD2 [Futaba]]
[s][bup 0 8 103 0 0][f 4 10 -1 0 0][vp 8 2 0 9197 -1 0]...Although that desk in your[n]room might be too messy for you[n]to make anything on right now...[n][w][e]

[msg TBOX_MSG_DIRTYMAIL1ST_M [Morgana]]
[s][bup 0 3 5 0 0][f 4 10 -1 0 0][vp 8 2 0 1029 -1 0]Hey... That stuff is disgusting.[n]You should get it cleaned[n]somewhere... Anywhere...[n][w][e]
[s]Wait, wasn't there a coin[n]laundry near Leblanc?[n][w][e]

[msg TBOX_MSG_DIRTYMAIL1ST_F [Futaba]]
[s][bup 0 8 105 0 0][f 4 10 -1 0 0][vp 8 2 0 9029 -1 0]Ughhh... That gear is gross.[n]You should wash it somewhere![n][w][e]
[s]IIRC, there's a coin[n]laundry near Leblanc.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_SER [Morgana]]
[s][bup 0 3 0 0 0][f 4 10 -1 0 0]Well, I guess this is your first[n]time. Here, you can have this one.[n]It's my prized possession.[n][w][e]
[s]But next time you'll be[n]responsible for this, all right?[n][w][e]

[sel RARE_TBOX_NO_KEY_SERVICE]
[s]What do you mean?[e]
[s]I want more![e]

[msg RARE_TBOX_MSG_NO_KEY_SER2 [Morgana]]
[s][bup 0 3 0 0 0][f 4 10 -1 0 0]You'll make your own. I can[n]teach you how back in your room.[n][w][e]

[msg RARE_TBOX_MSG_NO_KEY_SER3 [Morgana]]
[s][bup 0 3 0 0 0][f 4 10 -1 0 0]Maybe, but a thief like you should[n]be able to make his own tools. I[n]can teach you how in your room.[n][w][e]

[msg RARE_TBOX_MSG_AQKEYPICK_ [Morgana]]
[s][bup 0 3 8 0 0][f 4 10 -1 0 0][vp 8 2 0 1171 -1 0]You have the [f 2 5 3 -1 0][n]with you, right? Let's take this![n][w][e]

[msg RARE_TBOX_MSG_AQKEYPICK_2 [Futaba]]
[s][bup 0 8 104 0 0][f 4 10 -1 0 0][vp 8 2 0 9040 -1 0]That's the legendary infiltration[n]tool, the [f 2 5 3 -1 0]![n][w][e]
[s][bup 0 8 101 0 0][f 4 10 -1 0 0]Wanna use it to open this!?[n][w][e]

[msg MSG_AUTO_RECOVER_CONF]
[s]Would you like to perform[n]an Auto-Recover?[n][e]

[msg MSG_AUTO_RECOVER_FULL]
[s]Everyone is already at max HP.[n][w][e]

[msg MSG_AUTO_RECOVER_NO_USER]
[s]Nobody in your party can[n]use a healing skill.[n][w][e]

[msg SOBJ_RECOVER0 [Futaba]]
[s][vp 1 0 0 8259 0 0]I'll do this at the [n]speed of light![n][f 1 6 -1][e]

[msg SOBJ_RECOVER1 [Futaba]]
[s][vp 1 0 0 8260 0 0]Gimme a sec.[n][f 1 6 -1][e]

[msg SOBJ_RECOVER2 [Futaba]]
[s][vp 1 0 0 8272 0 0]This is where I shine![n][f 1 6 -1][e]

[msg SCHOBJ_SYSTEM]
[s]All search objects in the[n]Palace have been replenished.[n][w][e]

