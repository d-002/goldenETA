# GoldenETA

Stats and utilities for golden strawberry runs in Celeste.

Estimate the time it will take to complete a run.

# CURRENT MOD PROGRESS: 0%

## Todo:
- create room paths files
- detect time it takes to complete each room (ignore when going back to a previous room)
- handle skipping rooms: copy the consistency for skipped rooms when going to a new room in the path, skipping others
- choose current path among rooms paths
- support custom templates for rooms paths
- support error handling in templates, make sure to support empty template list
- store attempts data for path: create a file with the name of the path, with total runs time, total time overall, number of attempts, number of successful attempts
- settings:
    - hotkeys: toggle menu, toggle practice / runs, reset consistency for current room, for current path, delete all stats for the current path
    - number of lines in menu
- popup when changing between practice and runs, or when toggling logging on and off
- handle exiting the game while logging is running
- menu to display stats
- if too many rooms, only show the first, last, and around current
- calculate estimated remaining time
- display consistency overall and this session in menu
- when no runs have been made in a room in the path, do not estimate anything (and add a message)
- confirm dialogue when resetting consistency, or path stats

Enhancements:
- Toggle for whether to restart the chapter when starting runs

## Logic:
### Estimated remaining time:
To complete a path, one must complete all the rooms.
If a room has a consistency of $p$ and a duration of $t$, then it takes on average $\frac{t}{p}$ time to complete it.
The total time is the product of the average completion time for each room.

### Logging
Calculate the amount of time spent in a room IN RUNS. Start and stop: usually transitions, but:
- Just started a run: the start is the time when starting the run
- Just started the path: be careful about not counting the previous room as completed because of a screen transition, as a golden will bring the player back to the first room
- Just ended the path: the end is the current time, trigger a room end
- Just ended a run (exited runs mode): discard the last room

### Consistency handling
Practice should make one better at specific sections.
When practicing, can press a hotkey to reset the consistency for a room