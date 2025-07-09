# MASTERMIND GAME - COMPLETE DOCUMENTATION

=== GAME OVERVIEW ===
* Code-breaking game where players guess a 4-digit secret code
* Digits range from 0-8 with no duplicates
* Default: 10 attempts (configurable)
* Provides feedback after each guess

=== HOW TO PLAY ===
1. Launch the game (see "Running the Game" section)
2. Enter your 4-digit guess when prompted:
   - Must contain unique digits (0-8)
   - Example valid guess: 1234
   - Example invalid guess: 1123 (duplicate 1s)
3. Receive feedback:
   - ✔ Well-placed pieces: Correct digit in correct position
   - ↻ Misplaced pieces: Correct digit in wrong position
4. Continue guessing until:
   - You guess the code (win)
   - Run out of attempts (lose)
   - Exit with Ctrl+Z

=== COMMAND LINE OPTIONS ===
| Option | Description                  | Example Usage        |
|--------|------------------------------|----------------------|
| -c     | Set custom secret code       | -c 1357              |
| -t     | Set maximum attempts        | -t 15                |

=== RUNNING THE GAME ===
1. BASIC USAGE (random code, 10 attempts):
   > dotnet run

2. CUSTOM CODE (5 attempts):
   > dotnet run -- -c 2468 -t 5

3. EXTENDED ATTEMPTS (20 attempts):
   > dotnet run -- -t 20

=== GAME FEATURES ===
• Input validation ensures proper guesses
• Clear feedback after each attempt
• Configurable difficulty (via attempts)
• Option to set specific codes for testing
• Clean exit with Ctrl+Z

=== TIPS & STRATEGY ===
1. Start with a broad initial guess (e.g., 0123)
2. Use feedback to eliminate possibilities:
   - Well-placed digits stay in position
   - Misplaced digits need new positions
   - Unmentioned digits can be discarded
3. Track which digits you've tried
4. Remember all digits are unique

=== TROUBLESHOOTING ===
• "Invalid input" error:
  - Ensure exactly 4 digits
  - No duplicates
  - All digits 0-8

• "Invalid secret code" error:
  - Only occurs when using -c option
  - Verify code meets same requirements as guesses

• Game not running:
  - Verify .NET SDK is installed
  - Ensure you're in correct directory

=== VERSION INFO ===
Mastermind v1.0
C# .NET implementation