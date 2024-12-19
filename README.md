# 3902_Mario_Code_That_Toad

Main Branch: Always Working
Sprint Main Branch: Always Working
Sprint Dev Branch: Where we all merge
Create feature branches for individual work

Meeting Information:
Backlog Refinement + Sprint Planning:	Every monday after class (In person)
Stand Up: Wednesday + Friday		Right after class
Retrospective: Sunday Nights (Discord Voice Channel)

If missing a meeting just put it in the chat before the meeting some time. 

Priority System: 
(1) Get it done as soon as possible (Get it done early)
(2) (~2nd week) - Start Early
(3) Easy - less priority
(4) Additional features, would be cool, things to think about

Goals:
Merge and try to finish it by Sunday 2-3 pm the week before. 
Sunday Night: Retrospective + Group code review.


ALL

Ben Lampe - Orange

Ekum Kaur - Blue

Joshua Han - Yellow

Tina Wang - Purple

Bladen Siu - Green


# Sprint 2 - Game Objects and Sprites Navigation Guide
After building the solution, there will be several sprites on the screen...

<br/>

1.) **Mario** - The Mario sprite has several features that can be tested. <br/><br/>
    Horizontal and vertical movement: press **A** to move left, press **D** to move right, press **W** to jump <br/>
    Crouch: press **S** <br/>
    Switch Power States: press **F** for Fire Flower state, press 8 for Super Mario state, press **E** to damage Mario, press **G** to return to normal state <br/>
    Throw Fireballs: press **Z** for Fire Flower Mario to throw fireball projectiles <br/><br/>
    **NOTES:** Mario is only able to crouch in its Fire Flower or Super Mario state. Using keyboard commands to implement the switching 
    between Mario power states is a temporary implementation that will be changed after handling collision. Fireball projectiles can be
    thrown ONLY in the Fire Flower state. Attempting to move damaged Mario WILL cause the program to crash since, in the backlog,
    mario.cs will be updated to not allow any more inputs if mario is dead.
    
<br/>
    
2.) **Enemies** - The enemy sprite exhibits random movement and can be switched. <br/><br/>
    Switch Enemy - press **O** or **P** <br/><br/>
    **NOTES:** Can currently switch between a Goomba enemy and a Koopa enemy (see bottom of the screen) as those are the enemies present
    in the first level of the game. The Bowser sprite displays the mechanics of random movement in all directions of the screen, while
    the Goomba and Koopa sprite show back and forth horizontal movement.

<br/>

3.) **Items** - The item sprite is animated and can be switched. <br/><br/>
    Switch Item - press **U** or **I** <br/><br/>
    **NOTES:** The item is currrently displayed in the mid-upper portion of the screen. Items include the power-ups Mario can 
    obtain such as mushrooms, fire flower, and super star which should be collectable after handling collision as a backlog task in 
    the next sprint. A coin item can also be displayed which will also demonstrate collecting mechanics after handling collision interactions with Mario.

<br/>

4.) **Blocks** - The block sprite displayed can be switched. <br/><br/>
    Switch Block - press **Y** or **T** <br/><br/>
    **NOTES:** The block is currently displayed in the left portion of the screen. These blocks present various textures to be used in the first
    level of the game such as for floors and platforms. These blocks will later be able to interact with the player via collision.

<br/>

**Other Controls** <br/>

Reset Display - press **R** <br/>
Quit Program - press **Q**

<br/><br/>
# Sprint 3 - Level Loading and Segmentation and Collision Handling Navigation Guide
After building the solution, there will be several visible game features...

<br/>

1.) **Level and Camera** - World 1-1 level design from the original Super Mario Bros has been implemented. <br/><br/>
    Move the player (refer to item 2. for reference) horizontally and vertically to explore the map. <br/>
    The camera implementation follows the player based on its horizontal position while fixing the vertical position based on
    the starting coordinates of the player in the world. <br/><br/>
    **NOTES:** The camera has not been clamped at the ends of the level - the player can see past the first or last block in 
    the level. However, a clamp feature will be implemented as a backlog item in the next sprint to greater replicate the original game. <br/><br/>
    Unlike the original game, the player can move backwards in the level. This feature may be replaced in future sprints to only allow 
    the player to move right/forward. <br/><br/>
    Other non-collidable game objects have not been implemented in this sprint. For example, the clouds and castle are not present. When polishing
    the level in the next sprint, these objects will be added. <br/><br/>
    Refer to Levels folder, XML folder, Content/Levels folder, and Camera.cs for further details. <br/><br/>

2.) **Player (Mario)** - The player has several features that can be tested. These features have largely stayed the same since Sprint 2. <br/><br/>
    Horizontal and vertical movement: press **A** to move left, press **D** to move right, press **W** to jump <br/>
    Crouch: press **S** <br/>
    Throw Fireballs: press **Z** for Fire Flower Mario to throw fireball projectiles <br/><br/>
    **NOTES:** Mario is only able to crouch in its Fire Flower or Super Mario state. Fireball projectiles can be
    thrown ONLY in the Fire Flower state. <br/><br/>
    The main difference in movement this sprint is the use of physics such as gravity, velocity, etc. to influence 
    the player's position. As noted in the comments of the Mario class code, these updates in physics will be moved to another class
    dedicated to handling physics as a backlog item for the next sprint. <br/><br/>
    The player is currently handled as a single entity, and the solution does not support multiplayer. However, an IPlayer interface
    is a backlog item for the next sprint so that the multiplayer feature can be supported in future sprints. <br/><br/>
    As of now, the player can move in the dead Mario state since the Game Over screen has not been implemented. In the next sprint,
    this feature will be removed so that the player will not be allowed to move after death, and instead, a Game Over screen will appear.
    Additionally, the player currently has only one life, but the lives will be changed to three lives like the original game once 
    level resetting is implemented in a future sprint. <br/><br/>
    Refer to Player folder, MarioStates folder, and Commands folder for further details. <br/><br/>
    
3.) **Enemies** - There are several enemies throughout the level, consisting of Goombas and a Koopa. <br/><br/>
    The player can interact and collide with enemies. When the player hits an enemy, depending on the player's power state, the player may
    revert to its regular state or die. <br/>
    Enemies move in a left-right motion and will not fall off the map. <br/><br/>
    **NOTES:** Currently, the player dies whenever interacting with an enemy, no matter what state the player is in. In the next sprint, if the player 
    is in its Fire Flower or Super Power state, collision with an enemy will result in the player becoming its
    regular form again (no powers). If the player is in its regular form, collision with an enemy will result in death, and the player
    loses a life (currently only one life). <br/><br/>
    Enemy death animations are not implemented, but this feature is a backlog item that will be implemented next sprint.
    As a result, the player is currently unable to stomp the enemies but can kill them. <br/><br/>
    Koopas do not drop a shell upon their deaths, and this is a feature that will be implemented in a future sprint. <br/><br/>
    Refer to Enemies folder, Content/Enemies folder, and Content/Collision folder for further details. <br/><br/>

4.) **Items** - Items appear at the beginning of the level to the left of the player, consisting of a Fire Flower, Mushroom, and Super Star. <br/><br/>
    The player can interact and collide with items. When the player hits an item, the player gains a power-up. <br/>
    **Fire Flower** - The player becomes Fire Mario and can shoot fireballs using the **Z** key <br/>
    **Mushroom** - The player becomes Super Mario and, in the future, will be able break blocks (**NOT** implemented this sprint) <br/>
    **Super Star** - The player becomes Invincible Mario and, in the future, will not take damage from enemies for a certain period of time (**NOT** implemented this sprint) <br/><br/>
    **NOTES:** Item movement/animation are not implemented, but this feature is a backlog item that will be implemented next sprint. As a result, the 
    player still theoretically gains the power-up as they have changed states, but the functionality cannot be performed except for Fire Mario. <br/><br/>
    Player animation after obtaining an item (like gradually getting bigger) has not been implemted from the original game. <br/><br/>
    Item distribution throughout the level has not been implemented but will be available and polished in the next sprint. <br/><br/>
    Refer to Items folder, Content/Items folder, and Content/Collision folder for further details. <br/><br/>

5.) **Blocks** - Blocks appear a multitude of times in the level such as the ground and platforms in the air. <br/><br/>
    The player can interact and collide with blocks. When the player hits a block, the player is bounced off a certain direction based on the type of collision. <br/>
    **Brick Block** - This block type can be seen floating in the air in some parts of the level. In the future, only Super Mario will be able to 
    break these blocks <br/>
    **Ground Block** - This block type makes up the ground of the level and constantly collides with the player <br/>
    **Solid Block** -  This block type makes up the ramps of the level. The player can move upwards using these ramps. <br/>
    **Question Block** -  This block type floats in the air of the level, and, in the future, the player can collide upwards with
    these blocks to receive power-up items or coins (**NOT** implemented this sprint) <br/>
    **Empty Block** - This block type is invisible to the player but can still be collided with <br/>
    **Pipes** - Similar to solid blocks, the player can jump on top of these blocks to raise the player's elevation. These blocks
    come in varying sizes. <br/><br/>
    **NOTES:** When the player interacts with any block, there is a collision response. <br/><br/>
    Brick blocks can be be broken, but the breaking animation is not implemented but will be included in a future sprint. <br/><br/>
    Question blocks are unable to provide items but will be able to in a future sprint. <br/><br/>
    Refer to Blocks folder, Content/Blocks folder, and Content/Collision folder for further details. <br/><br/>


# Sprint 4 - Completed First Level Navigation Guide
After building the solution, there will be several visible game features...

<br/>

1.) **Menu Screens** - There are multiple menu screens that can be interacted with. <br/><br/>
    The first screen that will appear is the **Main Menu**. Use the arrow keys to navigate options. </br>
    **NOTE:** Only single player has been implemented currently. Multiplayer is a possible Sprint 5 </br>
    feature which is why it has been reflected in the menu options. <br/>
    When playing the level, there will be a **Game Screen**. This screen displays what is being tracked of <br/>
    the player such as lives, remaining time, and number of coins collected. </br>
    After the player loses all three available lives, a **Game Over** screen will appear. The user will then <br/>
    be returned to the Main Menu. <br/><br/>

2.) **Player (Mario)** - The player has several features that can be tested. These features have largely stayed the same since Sprints 2 and 3. <br/><br/>
    Horizontal and vertical movement: press **A** to move left, press **D** to move right, press **W** to jump <br/>
    Crouch: press **S** <br/>
    Throw Fireballs: press **Z** for Fire Flower Mario to throw fireball projectiles <br/><br/>
    **NOTES:** Mario is only able to crouch in its Fire Flower or Super Mario state. Fireball projectiles can be
    thrown ONLY in the Fire Flower state. <br/><br/>
    The main difference in movement this sprint is the support for multiplayer. An IPlayer interface has been <br/>
    implemented and will allow multiple other player classes to implement it for potential Sprint 5 use. In addition, <br/>
    the invincible or star appearence is now supported for color changes during player animations. <br/><br/>

3.) **Level (Including Subworld) and Camera** - World 1-1 level design from the original Super Mario Bros has been implemented. <br/><br/>
    Move the player (refer to item 2. for reference) horizontally and vertically to explore the map. <br/>
    The camera implementation follows the player based on its horizontal position while fixing the vertical position based on
    the starting coordinates of the player in the world. <br/>
    Subworld has also been implemented this sprint. By pressing the crouch button on the (insert number) pipe in the level, <br/>
    the player will be teleported to the subworld which can be explored as well. <br/>
    A game object manager now handles the building of these levels. <br/>
    **NOTE:** Colliding with the flagpole will not do anything or have score animation. We plan on having more levels in the next sprint, so we will take of transitions there.
    <br/>
    Also, Mario can walk off the screen currently (past camera clamps), but we plan on implementing invisible blocks in the next sprint to account for this.
    <br/><br/>

3.) **Enemies** - There are several enemies throughout the level, consisting of Goombas and a Koopa. <br/><br/>
    The player can interact and collide with enemies. When the player hits an enemy, depending on the player's power state, the player may
    The player can interact and collide with enemies. When the player hits an enemy, depending on the player's power state, the player may
    revert to its regular state or die. <br/>
    revert to its regular state or die. <br/>
    Enemies move in a left-right motion and will not fall off the map. <br/><br/>
    Enemies move in a left-right motion and will not fall off the map. <br/><br/>
    **NOTES:** Currently, the player dies whenever interacting with an enemy, no matter what state the player is in. In the next sprint, if the player
    **NOTES:** Enemies have a death animation but its still in a primitive state and needs work. <br/><br/>
   

4.) **Items** - Items appear at the beginning of the level to the left of the player, consisting of a Fire Flower, Mushroom, and Super Star. <br/><br/>
    The player can interact and collide with items. When the player hits an item, the player gains a power-up. <br/>
    **Fire Flower** - The player becomes Fire Mario and can shoot fireballs using the **Z** key <br/>
    **Mushroom** - The player becomes Super Mario and can break blocks <br/>
    **Super Star** - The player becomes Invincible Mario and, in the future, will not take damage from enemies for a certain period of time <br/>
    **Coins** - The player can collect coins throughout the level which will be used to calculate a score at the end of the level <br/><br/>
    **NOTES:** animation are not implemented, but this feature is a backlog item that will be implemented next sprint. <br/><br/>
    Player animation after obtaining an item (like gradually getting bigger) is a feature from the original game that has not been implemented. <br/>
    This feature may be implemented as a Sprint 5 item where the original game is replicated as closely as possible. <br/>

5.) **Blocks** - Blocks appear a multitude of times in the level such as the ground and platforms in the air. <br/><br/>
    The player can interact and collide with blocks. When the player hits a block, the player is bounced off a certain direction based on the type of collision. <br/>
    **Brick Block** - This block type can be seen floating in the air in some parts of the level. In the future, only Super Mario will be able to 
    break these blocks <br/>
    **Ground Block** - This block type makes up the ground of the level and constantly collides with the player <br/>
    **Solid Block** -  This block type makes up the ramps of the level. The player can move upwards using these ramps. <br/>
    **Question Block** -  This block type floats in the air of the level, and, the player can collide upwards with
    these blocks to receive power-up items or coins <br/>
    **Empty Block** - This block type is invisible to the player but can still be collided with <br/>
    **Pipes** - Similar to solid blocks, the player can jump on top of these blocks to raise the player's elevation. These blocks
    come in varying sizes. <br/><br/>
    **NOTES:** When the player interacts with any block, there is a collision response. <br/><br/>
    Brick blocks can be be broken, but that is with any state of mario. Only small mario should "bump" it which will be added the next sprint. <br/><br/>
    Question blocks only offer mushrooms but will offer a variety of items next sprint. <br/><br/>


# Sprint 5 - Bonus Features and Backlog Navigation Guide
After building the solution, there will be multiple visible game features...

<br/>

1.) **Screens** - There are multiple screens that can be interacted with. <br/><br/>
    **Menu Screen** - The first screen that will appear is the **Main Menu**. Use the arrow keys to navigate options. </br>
    **Score Screen** - This is the main UI that is shown while playing the game. It shows the player's score, kills, lives, time, and coins.<br/>
    **End Game Screen** - This screen is shown when the player dies and has no more lives left. The player can press **SPACE** to go back to the menu screen.<br/>
    **NOTE:** Only single player has been implemented currently. Multiplayer is a possible Sprint 5 </br>
    feature which is why it has been reflected in the menu options. <br/>
    When playing the level, there will be a **Game Screen**. This screen displays what is being tracked of <br/>
    the player such as lives, remaining time, and number of coins collected. </br>
    After the player loses all three available lives, a **Game Over** screen will appear. The user will then <br/>
    be returned to the Main Menu. <br/><br/>

2.) **Player (Mario)** - The player has several features that can be tested. These features have largely stayed the same since prior Sprints. 
    The biggest change is the addition of multiplayer (up to two players)<br/><br/>
    Player 1 (Mario) Controls:
    Horizontal and vertical movement: press **A** to move left, press **D** to move right, press **W** to jump <br/>
    Crouch: press **S** <br/>
    Throw Fireballs: press **Z** for Fire Flower Mario to throw fireball projectiles <br/><br/>
    Player 2 (Toad) Controls:
    Horizontal and vertical movement: press **J** to move left, press **L** to move right, press **I** to jump <br/>
    Crouch: press **K** <br/><br/>
    **NOTES:** Players are only able to crouch in their Fire Flower, Super, and Doctor states. Fireball projectiles can be
    thrown ONLY in the Fire Flower state. <br/><br/>
    The camera only follows Player 1 (Mario). Player 2 (Toad) may move as they please, including going off the screen and 
    combing back on. Players do not have x-acceleration like in the original Super Mario Bros. Player score and lives are
    shared but power-up states are not. Flagpole animation will only play for Player 1 (Mario), so Player 1 must make it
    to the end of the level to progress. <br/><br/>

3.) **Level (Including Subworld) and Camera** - World 1-1, 8-4, and Shop level design added. <br/><br/>
    Move the player (refer to item 2. for reference) horizontally and vertically to explore the map. <br/>
    The camera implementation follows the player based on its horizontal position while fixing the vertical position based on
    the starting coordinates of the player in the world. <br/>
    Subworld has also been implemented this sprint. By pressing the crouch button on the 4th pipe in the level, <br/>
    the player will be teleported to the subworld which can be explored as well. <br/>
    A game object manager now handles the building of these levels. <br/>
    Level 8-4 adds new enemies and new terrain hazards to the game. Bowser is also added and will need team work to defeat him.<br/>
    Shop level adds shop blocks that lets the player to buy items using coins to prepare for the next level.<br/>
    **NOTE:** 
    <br/><br/>

3.) **Enemies** - There are several enemies throught the level. Consist of Goombas, a Koopa, and a Ghost. <br/><br/>
    The player can interact and collide with enemies. The player will die unless it jumps on top of an enemy, in which case,<br/>
    the enemy will die. <br/>
    **Goomba Death** When a goomba dies, it enters its death state and floats up. <br/>
    **Koopa Death** When a koopa dies, it enters its shell state, speeds forward, and then enters a death state and floats up. <br/>
    **Ghost** The new enemy this sprint is Ghost, and it cannot die. It chases mario who it has a personal vendetta against.<br/>
    When Mario enters the screen, the ghost enters its alert state and runs at Mario. It can only move left and right but if <br/>
    close enough, it will enter its attack state. Outside of this alert state, the ghost will wander randomly and wait for Mario. 
    **Lava Enemy** A Level 8-4 enemy that spews fire balls upwards. The player is damaged when hitting these projectiles.
    **Bowser** A Level 8-4 enemy. A final boss the player must defear or navigate around to reach the end of the level<br/><br/>


4.) **Items** - Items appear from Question and Shop blocks. <br/><br/>
    The player can interact and collide with items. When the player hits an item, the player gains a power-up. <br/>
    **Fire Flower** - The player becomes Fiery and can shoot fireballs using the **Z** key <br/>
    **Mushroom** - The player becomes Super and can break blocks. There is an animation from going to normal to super. It also jumps up and down,
    similar to fireball.<br/>
    **Super Star** - The player becomes Invincible and will not take damage from enemies for a certain period of time <br/>
    **Coins** - The player can collect coins throughout the level which will be used to calculate a score at the end of the level <br/>
    **One Up** - The player gains one more life. Moves like **Mushroom**.<br/>
    **Stethoscope** - The player becomes a Doctor. Whenever the player kills an enemy, they gain a life.<br/><br/>
    **NOTES:** 

5.) **Blocks** - Blocks appear a multitude of times in the level such as the ground and platforms in the air. <br/><br/>
    The player can interact and collide with blocks. When the player hits a block, the player is bounced off a certain direction based on the type of collision. <br/>
    **Brick Block** - This block type can be seen floating in the air in some parts of the level. Only Super Mario will be able to break these blocks.
    Some of the blocks also contain coins that can be collected to use in the Shop.<br/>
    **Ground Block** - This block type makes up the ground of the level and constantly collides with the player <br/>
    **Solid Block** -  This block type makes up the ramps of the level. The player can move upwards using these ramps. <br/>
    **Question Block** -  This block type floats in the air of the level, and, the player can collide upwards with
    these blocks to receive power-ups or coins based on probability.<br/>
    **Empty Block** - This block type is both visible invisible to the player, where one is sued to portray used Question and Shop blocks and can still be collided with <br/>
    **Pipes** - Similar to solid blocks, the player can jump on top of these blocks to raise the player's elevation. These blocks
    come in varying sizes. <br/>
    **Shop Block** - Similar to the question block, this block contains an item that is predetermined and costs a certain amount of coins.
    This block is available after completing each level. The cost is shown below the block, and when hit, it either produces an item or nothing happens.<br/>
    **Flag Pole** - This block is at the end of the level, where the player needs to jump onto the pole to complete the level. The player also gains points based on
    where they land on the pole.<br/>
    **Lava Block** - This block fills the holes in the later levels. If the player falls into the lava, they die just as they would if they fell off the map.<br/>
    **Bridge** - This block it used as the final battle ground between the player and Bowser. It functions similarly to the solid/ground blocks and is used as a platform 
    to hold the player and Bowser above a pool of lava.<br/>
    **Castle Brick** - Similar to the ground blocks, this block is used as the floor for the castle levels and is unbreakable.<br/><br/>
    **NOTES:** When the player interacts with any block, there is a collision response. <br/><br/>



