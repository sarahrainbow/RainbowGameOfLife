# Sarah Rainbow's Game Of Life
A colourful version of the Game of Life.

## 1. How to install

### 1.1 For Mac

1. Download `RainbowGameOfLife.app.zip` located [here](https://github.com/sarahrainbow/RainbowGameOfLife/blob/master/Builds/Mac/RainbowGameOfLife.app.zip)
2. Run the file `RainbowGameOfLife.app`

### 1.2 For Windows

1. Download `RainbowGameOfLife_x86` located [here](https://github.com/sarahrainbow/RainbowGameOfLife/blob/master/Builds/Windows/x86/RainbowGameOfLife_x86.zip)
2. Run the enclosed file `SarahRainbowGameOfLife.exe`



## 2. How to play

1. Open the game
2. Click on the window to the right to create new “baby” cells
3. Hit  `Start` and watch the cells either evolve through the lifecycle



## 3. How it works

### 3. 1 Why cells live and why they die

#### A solid support network

Cells need a support network of two or three alive neighbour cells to survive.

#### Lonely

If a cell has a lonely surrounding of just one or no neighbouring living cells they will die.

#### Smothered

If the cell is smothered by having four or more alive neighbour cells, they will die.

### 3.2 Cell evolution

The cells move through the colours of the rainbow as they evolve through their lifecycle.

### ![babyRect](./Assets/Graphics/ReadMeImages/babyRect.png)  The baby

When you click on a dead cell, or it has two or three alive neighbours, your baby cell takes its first breath.

### ![childRect](./Assets/Graphics/ReadMeImages/childRect.png) The child

If your baby cell is lucky enough to have a solid support network to care for it, but not so many it is smothered, it will then evolve to become a bright-eyed, yellow child.

### ![teenRect](./Assets/Graphics/ReadMeImages/teenRect.png) The teen

Life is unfair and they know it. With a loving support network (but not too much) your child cell can develop into a moody, but alive, teenager.

### ![adultRect](./Assets/Graphics/ReadMeImages/adultRect.png) The adult

A fully fledged adult cell makes its way into the world. The adult cell has now survived three evolutions and has learnt a lot, hopefully it won't get lonely or smothered so it can reach the final stage in its evolution.

### ![oapRect](./Assets/Graphics/ReadMeImages/oapRect.png) The OAP

These cells have really got some stories to tell from their long lives on the board. Unlike in real life, some cells really can live forever if they have a solid support network and constantly nurturing surroundings.

### ![deadRect](./Assets/Graphics/ReadMeImages/deadRect.png) The dead

Without a solid support network, getting too lonely or smothered our cells will die :-(  This can happen at any stage in their evolution. On the plus side, you can turn a cell from dead to alive with just a click of the mouse!



### 4. Important files

You can view the main files of code by clicking on the links below:

[Cell.cs](https://github.com/sarahrainbow/RainbowGameOfLife/blob/master/Assets/Scripts/Cell.cs)

[Game.cs](https://github.com/sarahrainbow/RainbowGameOfLife/blob/master/Assets/Scripts/Game.cs)

[GameControls.cs](https://github.com/sarahrainbow/RainbowGameOfLife/blob/master/Assets/Scripts/GameControls.cs)
