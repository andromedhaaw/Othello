
# Othello Game (C#)

This is a console-based implementation of the classic **Othello** (also known as **Reversi**) game. It is written in **C#** and follows an interface-based design for flexibility and maintainability.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Game Rules](#game-rules)
- [Project Structure](#project-structure)
- [License](#license)

## Introduction

Othello is a strategy board game played by two players, where the goal is to have more of your pieces on the board than your opponent by the end of the game. Players take turns placing pieces on the board, with the objective of "flipping" the opponent's pieces to your color by surrounding them. 

This project demonstrates how to implement an Othello game in C# using object-oriented principles and interfaces.

## Features

- **Console Interface**: Play the game via a simple text-based interface in the console.
- **Game Logic**: The game enforces the rules of Othello, including valid moves, flipping of pieces, and scoring.
- **Turn-based Gameplay**: The game alternates between two players (Black and White).
- **Input Validation**: Players can enter their moves in a specific format, e.g., `A1`, `B2`, etc.
- **Endgame Detection**: The game will declare a winner once no more moves are possible.

## Installation

To play the game, you need the following:

1. **.NET SDK**: Make sure you have the .NET SDK installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download).

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/andromedhaaw/Othello.git
   cd othello-game
   ```

3. **Build the Project**:
   If you're using Visual Studio or VSCode, simply open the project folder. Alternatively, you can use the following command to build the project using the .NET CLI:
   ```bash
   dotnet build
   ```

4. **Run the Game**:
   After building the project, you can run the game with the following command:
   ```bash
   dotnet run
   ```

## Usage

Once you run the game, the console will prompt you to enter your move in a format such as `A1`, `B2`, etc. Valid moves will be indicated with a `*`. The game will alternate turns between Black and White players.

- **Enter your move**: For example, `A1`, `C5`, etc.
- **Quit the game**: Type `QUIT` at any time to exit the game.

### Example Gameplay:

```
Welcome to Othello/Reversi!
Instructions:
- Enter your move in format like A1, C5, etc.
- Black (O) plays first
- Valid moves are shown with a * symbol
- Type 'quit' to exit game

Press any key to start...
Enter your move (e.g., A1, B2), or 'quit': A1
Player O's turn.
...
```

## Game Rules

1. **Objective**: The goal is to have more pieces of your color on the board than your opponent by the end of the game.
2. **Starting Pieces**: The game begins with two Black pieces and two White pieces in the center of the board arranged in a 2x2 square.
3. **Valid Move**: A move is valid if it sandwiches one or more of your opponent's pieces between your piece and another piece of your color, in any direction (horizontal, vertical, or diagonal).
4. **Flipping Pieces**: When a valid move is made, all opponent's pieces that are surrounded by your pieces are flipped to your color.
5. **No Valid Moves**: If a player has no valid moves, their turn is skipped.
6. **End of the Game**: The game ends when neither player has a valid move left. The player with the most pieces of their color on the board wins.

```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

F
