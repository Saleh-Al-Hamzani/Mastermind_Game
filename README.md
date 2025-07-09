# 🎯 Mastermind Game (Console App in C#)

This project is a console-based implementation of the classic **Mastermind** game in **C#**. The player must guess a secret 4-digit code consisting of digits from **0 to 8**, with no repeating digits. The game provides feedback after each guess, helping the player get closer to the correct code.

---

## 📌 Features

- Random secret code generation with unique digits from 0 to 8
- Command-line customization:
  - `-c <code>`: set a custom secret code
  - `-t <number>`: set the maximum number of attempts
- Input validation and error handling
- Feedback system:
  - **Well-placed pieces** (correct digit and position)
  - **Misplaced pieces** (correct digit but wrong position)
- Exit anytime with `Ctrl + Z`

---

## 🕹️ How to Play

1. Run the game from the command line:
   ```bash
   dotnet run
