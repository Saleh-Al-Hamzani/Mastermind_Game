### Mastermind Game Implementation - README

#### Overview
This C# implementation of the classic Mastermind game challenges players to guess a 4-digit secret code within a limited number of attempts. The code uses digits 0-8 with no duplicates.

#### Features
- Random code generation
- Detailed feedback system (correct positions + misplaced digits)
- Command-line customization
- Comprehensive input validation
- Attempt tracking
- Reveal secret code on game end

---

### How to Run the Game

#### Prerequisites
- .NET SDK (6.0 or newer)

#### Execution Steps:
1. Open a terminal and navigate to the directory containing the file.

2. Compile and run:
```bash
# Windows
dotnet run 
```

#### Command Line Options:
| Option | Description | Example |
|--------|-------------|---------|
| `-c` | Set custom secret code | `dotnet run -- -c 1234` |
| `-t` | Set max attempts | `dotnet run -- -t 15` |
| both | Set max attempts and Set custom secret code | `dotnet run -- -c 1234 -t 15` |
| (none) | Use random code (10 attempts) | `dotnet run` |

---

### How to Play
1. **Objective**: Guess the 4-digit secret code
2. **Rules**:
   - Digits 0-8 only
   - No duplicate digits
   - Limited attempts (default: 10)
3. **Feedback**:
   - **Well-placed pieces**: Correct digit in correct position
   -  **Misplaced pieces**: Correct digit in wrong position
4. **Win Condition**: Guess all 4 digits in correct positions

#### Game Controls:
- Enter guesses at the prompt
- Press `Ctrl+Z` (Windows) + Enter to exit

---

### Implementation Details

#### Class Structure
| Class | Responsibility |
|-------|---------------|
| `Program` | Entry point, CLI argument handling |
| `MastermindGame` | Core game loop and flow control |
| `GameSettings` | Attempt tracking and game state |
| `Code` | Code generation, validation, and feedback |

 

---

### Example Gameplay
```
dotnet run -- -c 1234 -t 15

Ctrl + Z then enter to exit the game
Can you break the code? Enter a valid guess. Must be 4 digits from 0-8:

Round 0
1253
Well-placed pieces: 2
Misplaced pieces: 1

Round 1
1354
Well-placed pieces: 2
Misplaced pieces: 1

Round 2
1234
Congratz! You did it!
```

---

### Exit Conditions
1. Successful code guess
2. Exhausted all attempts
3. User exit via `Ctrl+Z`
4. Invalid command-line arguments


---

### Design Principles
1. **Separation of Concerns**: Discrete classes for game logic, settings, and code handling
2. **Input Validation**: Robust checks at all entry points
3. **Immutable State**: Secret code remains unchanged after generation
4. **Feedback Clarity**: Precise position/misplacement reporting
5. **Customizability**: Flexible via command-line parameters

This implementation balances game authenticity with user-friendly features while maintaining clean, maintainable code structure.