import random


def evaluate_guess(hidden_word, guess):
    bulls = 0
    cows = 0
    for i in range(len(hidden_word)):
        if guess[i] == hidden_word[i]:
            bulls += 1
        elif guess[i] in hidden_word:
            cows += 1
    return bulls, cows


def play_game(hidden_word):
    attempts = 0
    max_attempts = 5
    print("Welcome to the Cow and Bull Game!")
    print("Guess the 5-letter word.")
    print("Type 'exit' at any prompt to quit the game.")

    while attempts < max_attempts:
        guess = input("Enter your guess: ").lower()

        if guess == 'exit':
            print(f"The hidden word was: {hidden_word}")
            print("Game ended.")
            break

        if len(guess) != len(hidden_word):
            print(f"Please enter a {len(hidden_word)}-letter word.")
            continue

        bulls, cows = evaluate_guess(hidden_word, guess)
        print(f"You have {bulls} Bulls and {cows} Cows.")

        attempts += 1
        if bulls == len(hidden_word):
            print(f"Congratulations! You guessed the word '{hidden_word}' in {attempts} attempts!")
            break

    if attempts == max_attempts:
        print(f"Sorry, you've run out of attempts. The hidden word was: {hidden_word}")

    return attempts


def main():
    total_score = 0
    play_again = True

    while play_again:

        hidden_word = input("Enter the hidden word (5 letters): ").lower()

        if len(hidden_word) != 5 or not hidden_word.isalpha():
            print("Please enter a valid 5-letter word.")
            continue

        attempts = play_game(hidden_word)
        total_score += (6 - attempts) if attempts < 6 else 0
        print(f"Your score: {total_score}")

        replay = input("Do you want to play again? (yes/no): ").lower()
        if replay != 'yes':
            play_again = False

    print(f"Thanks for playing! Your final score is: {total_score}")


if __name__ == "__main__":
    main()
