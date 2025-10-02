# Planet Six

## Team Members

Megan Lincicum (github.com/mlincicum)

Alex Dill (github.com/antisignal)

Carly Wang (github.com/cwang225)

## Game Summary

The main premise of our game will be a tactics based game where the main character starts out as a low level soldier in a dark cult on a planet. There are 6 planets in total which made up a planetary alliance, but the planet the main character is on has defected from the planet alliance, and the cult works against the other 5 planets. He messes up on a mission and is given an “impossible” mission by the head commander as a punishment: collecting/capturing the five Manite crystals from the other planets and taking them back home so that his planet can summon their deity. 

Against all odds, MC is able to bring back the first crystal, so the head commander decides to keep sending MC to get all the crystals. Along this journey, MC will make and meet new companions that help him fight. He works his way up in the ranks and slowly becomes a highly celebrated soldier. He continues to succeed and returns the crystals to the cult, but he begins to have doubts about the cult and their goals.  

## Genres

Our game will be a turn-based strategy/tactical RPG game. 

## Inspiration

### Gameplay: Fire Emblem Series

https://www.nintendo.com/us/store/products/fire-emblem-three-houses-switch/?srsltid=AfmBOopnIw-sq7DpgL-30SHmb01lnq_-IGDxUPdQOQKrwuV8m9Q-I_Z1 
![alt text](https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fjpgames.de%2Fwp-content%2Fuploads%2F2019%2F07%2FFire-Emblem-Three-Houses_2019_07-12-19_008.jpg%3Fx18544&f=1&nofb=1&ipt=69fea049ce51765e16db3abf75c2ccd25dd5fb66a1740f3c291571e47fbe2f6b)
Fire Emblem is a series of turn-based tactical RPG games and will be the main inspiration for our game mechanics. In Fire Emblem, the game is typically split between a hub, where the player interacts with NPCs and progresses the story, and battles. The battles are turn-based, where the player and the enemy AI take turns moving and attacking with each of their units. It’s top-down and uses a square grid of tiles. The map includes terrain features that help or hinder the player, as well as pathways between different elevations. Our game will use this tactics gameplay as a base, with some differences like less actions for the units to take (i.e. no items), and all combat will be shown in the overworld rather than go into a separate battle scene.

### Gameplay: Undaunted 2200: Callisto

https://boardgamegeek.com/boardgame/401978/undaunted-2200-callisto 
![alt text](https://cf.geekdo-images.com/D4KzouXzI9nFzBq2nE3knQ__imagepage/img/siLAMPqMunI0lKrriA_TAy3Sktk=/fit-in/900x600/filters:no_upscale():strip_icc()/pic8301704.jpg)
Undaunted 2200: Callisto is a tactical war board game set on a sci-fi mining colony. The two main ways it will influence our design is through its territory control and use of elevation and terrain. Controlling territory is one of the most important aspects of the game, and it’s done well in relatively small, claustrophobic maps. These maps utilize different features like bridges, towers, and three levels of elevation which can give ranged units huge advantages to attacking. We want our game to also involve territory control, through sigils and other terrain features, and to utilize elevation in a similar way. Also, because our game will take place underground on alien planets and the enemies will be sci-fi soldiers, the claustrophobic maps and art/vibes can also be an inspiration.

It will also take inspiration from chess in that positional advantage matters a lot as does careful board control.

<img width="1613" height="983" alt="image" src="https://github.com/user-attachments/assets/f03af1f7-549f-4c51-b002-7d6fb46eb420" />


### Visual Art: Peak

We will be referencing Peak when designing our main character and player bodies / overall model shape + movement

https://store.steampowered.com/app/3527290/PEAK/
https://www.youtube.com/shorts/Gwo8GNtdT8k
![alt text](https://static.deltiasgaming.com/2025/06/MixCollage-27-Jun-2025-01-48-PM-9707.jpg)
![alt text](https://img.itch.zone/aW1hZ2UvMjA3MjY0NC8xMjE4OTg4My5naWY=/347x500/d%2BHy7t.gif)

### Sound: Omori

We will be referencing Omori for sound. Thinking of simpler background music that still fits the vibe.
https://www.omori-game.com/en
https://open.spotify.com/track/54shhL9vif2iwUXg0lNpQX?si=c38c116cf93f4d51

### Vibes: Cult of the Lamb

We are taking vibe inspirations from Cult of the Lamb because we want to capture the occult vibe and the mix of cute characters/graphics with dark story and themes. 

![alt text](https://helios-i.mashable.com/imagery/articles/02BfYn2jOsd2dELqTuCLLGk/hero-image.fill.size_1248x702.v1662612724.png)

## Gameplay
The player will control a cultist who is trying to collect 5 magic crystals stored on neighboring planets. They must control a small team of followers and successfully kill/knock out interplanetary alliance forces on 5 levels by seizing territory strategically using a range of abilities (e.g. sigils placed on the ground which can be activated and have AoE effects.) Other tools include melee and intra-team healing. There will be mana springs across the map which give the holder increased mana regeneration, adding to the territory-control aspect of the game. Mana from springs is distributed across player characters evenly, but mana is not pooled. There will be elevation differences on the map which can be exploited for strategic purposes. Levels are accessible from a hub world, which contains portals to each level. Once all five hub world levels are complete (in a ring around a center) the player is able to summon their god, which turns on them and brings the MC and their companions to a final level. Each member of the player’s team (including the MC) has a unique class giving unique abilities to each member.

Expected user interface and game-controls: the game can be played using either a controller or keyboard. Between battles, they can move around (WASD, joystick) in the hub world to speak to NPC companions. During the battle, the player can switch selection between units, look around the map, and direct units to take actions. The UI will show whose turn it is (player/enemy), unit stats, relevant terrain effects (when hovering/selecting a tile), and when selecting a unit, the list of available actions. There can also be toggleable UI to overlay the tile grid (see Fire Emblem screenshot) with extra information like the range of each enemy.

The camera perspective we decided on was a top-down camera view for in-battle scenarios, and a 3rd person camera for the hub world.


## Development Plan

### Project Checkpoint 1-2: Basic Mechanics and Scripting (Ch 5-9)

By Oct 1st (Checkpoint 1-2):
We’d like to see these things for the upcoming project check-in:

- ~~Add a note in your GDD about the camera perspective you’ll use (both in-battle and hub world).~~
- ~~Complete one planet/scene (grayboxed).~~
- ~~Implement one class for the main character.~~
- ~~Implement one type of enemy unit.~~
- ~~For level selection, use a simplified menu or hotkeys instead of a hub world.~~
- ~~Implement one sigil (very basic effect).~~
- Enemy AI can be extremely simple (even random actions are fine for now). (Player controls enemy for now)

## Additions
- Carly: Several basic Game UI scenes were created based off of fire emblem gameplay found online. Most UI controls are keyboard binded/graphic.
- Megan: Level Editor for quick & easy creation of the 5 levels during production, setup for object pooling

### Project Part 2: 3D Scenes and Models (Ch 3+4, 10)
By Oct 13:
- Player Model (Carly)
- Enemy Model (Carly)
- Level terrain (one level to start with) (Carly)
- NPC Model (Carly)
- 2D UI elements (healthbar, sigils, some magic effects) (Carly)
- Finished gameplay loop (rounds, turns, end level conditions) (Megan)
- Enemy AI (Megan)
- Integrate combat into the battle controller/state machine (Megan)

# Development

## Project Checkpoint 1-2:
### Basic Levels and Tactics (Megan)
For battle, levels are loaded in through LevelData which is created in the Level Editor scene using the editor Megan created. This holds the data for all the tiles, ramps, and their elevations for the level, as well as each unit and it's starting position. Each unit is loaded in by UnitFactory, which takes in the unit data from a scriptable object (name, health, mana, movement range) and sets up the gameobject for it. The tiles are held in the TileManager which also manages highlighting them to show things like movement and ability range. 

<img width="1550" height="530" alt="Screenshot 2025-10-01 221952" src="https://github.com/user-attachments/assets/33653be1-668d-4d77-9819-3a5b9059eaf3" />

The battle is controlled by BattleController, a state machine that will handle all of the game states. Right now, it starts with LoadBattleState to load in the level data and initialize the scene, then it goes to UnitSelectState where the player can scroll between or click units to select them. Once selected, the BattleController enters SelectAbilityState and the ability menu pops up for the unit, which for now is just Move or Attack. Once again scrolling or clicking within the menu will allow the player to select the ability to use.
<img width="809" height="442" alt="Screenshot 2025-10-01 221802" src="https://github.com/user-attachments/assets/38d4e193-6c28-4fd2-952c-1876352fcb0a" />

MoveSelectState allows the player select where to move within range and displays the paths that can be taken. Finally, MoveSequenceState animates the unit to the new position and returns back to the ability menu.  
<img width="425" height="240" alt="Screenshot 2025-10-01 221826" src="https://github.com/user-attachments/assets/ea114646-469f-447f-9001-0afb959c8d0a" />
<img width="400" height="220" alt="Screenshot 2025-10-01 221835" src="https://github.com/user-attachments/assets/5d651e81-32db-4ef5-b987-ef22fc46c4bc" />


### Camera, Combat, and Sigils (Alex)

### Level Selection (Carly)
Level selection is navigated by pressing 'X' and having the levelselection menu pop up. Each level can be selected and will be highlighted upon selection. A play button pops up when a level is selected.
![Uploading ezgif.com-animated-gif-maker.gif…]()

## Running Instructions
Run the CarlyLevelSelection scene. Hit 'X' to show level select. Click on any level and then 'Play level' to enter the test level.
Controls:
- Scrollwheel or left/right arrows to change selection (for selecting a unit or selecting an ability in the menu)
- Click on a unit to select it
- Click on an action to select it
- Hover over tile to move to and click to move
- E to select if using scrollwheel/keyboard
- Right click or Q to cancel
