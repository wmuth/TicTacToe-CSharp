# TicTacToe-CSharp
Basic tictactoe game built in C# using Windows Forms

## How to play the game
1. Download my .exe bin or download the code and compile it yourself.
2. Select wether you want to play against another person or a bot.
3. Select who goes first, you, your friend or the bot.
4. Each player takes turns selecting tiles until one gets 3 in a row or all tiles are taken.
5. The game will then exclaim who won and ask if you want to restart the game.
6. The restart button immediately restarts the program.
7. The game tells you who's turn it is.
8. The game keeps score in a file in the C:\ProgramData\ folder called TicTacToe.txt, this means scores are kept between game restarts and can be reset by pressing the reset scores button.

## Winner logic
The first image below is a visualisation of the logic to determine the winner in tictactoe using a couple loops. This way we don't have to repeat ourselves too much and we can keep things relatively tidy code-wise. We have 3 discrete loops, one for columns, one for rows and one for the diagonals. The math for each slot in each loop is written in comments in the code as well as illustrated in the iamge.

## Bot
The game has a bot built in. It's rather basic but works surprisingly well to keep you entertained for a couple minutes. It has 3 different actions it can take which it prioritizes in this order;
1. Get TicTacToe, win the game
2. Stop player from getting TicTacToe
3. Pick an empty slot

For now the bot does 1 and 2 in the same function. This is a function I've built that basically does winner logic except instead of detecting if there are 3 of the same in a row, it detects if there are 2 in a row and an empty slot next to them. If it detects this the function returns that point which the bot will then take and click. This makes it so that it is sometimes inconsistent and will stop you from winning rather than just immediately win itself.

For 3 it just picks a random empty spot.

## Images 
![winnerLogic](/images/winnerLogic.png)
![Image1](/images/1.png)
![Image2](/images/2.png)
![Image3](/images/3.png)
![Image4](/images/4.png)
![Image5](/images/5.png)
![Image6](/images/6.png)
