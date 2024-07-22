var validWords = [];
var letters = [];
var discoveredWords = [];
var totalScore = 0;
var pangram = "";
var centerLetter = "";
var cursorTimer; 

// Function to start the blinking cursor
function startCursorBlink() {
    let cursor = document.getElementById('cursor');
    cursorTimer = setInterval(() => {
        cursor.style.visibility = cursor.style.visibility === 'hidden' ? 'visible' : 'hidden';
    }, 500); 
}

// Function to stop the blinking cursor
function stopCursorBlink() {
    clearInterval(cursorTimer);
    document.getElementById('cursor').style.visibility = 'visible';
}

// Function to initialize the game
function initGame() {
    fetchWordsAndLetters()
        .then(data => {
            letters = data.letters;
            validWords = data.possible_words;
            pangram = data.pangram;
            maxscore = data.maxscore;
            initializeLetters();
            initializeScore();
            startCursorBlink(); // Start the cursor blink after initializing the game
        })
        .catch(error => {
            console.error("Error fetching game data:", error); 
            // Handle the error appropriately (e.g., display an error message)
        });
}

// Function to fetch words and letters from the API
async function fetchWordsAndLetters() {
    const url = 'https://uxxjtb4jz0.execute-api.us-east-1.amazonaws.com/default/FindValidWords';
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        throw error; 
    }
}


function initializeScore() {
    document.getElementById("max-score").innerHTML = maxscore;
}

// Function to initialize the hexagon grid with letters
function initializeLetters() {
    const hexGrid = document.getElementById('hex-grid');
    hexGrid.innerHTML = ''; // Clear any existing letters

    letters.forEach((letter, index) => {
        const hex = document.createElement('li');
        hex.classList.add('hex');

        if (index === 3) { // Center letter
            hex.id = "center-letter";
            centerLetter = letter;
        }

        const hexInner = document.createElement('div');
        hexInner.classList.add('hex-inner');
        hexInner.textContent = letter;
        hex.appendChild(hexInner);

        hex.addEventListener('click', () => addLetterToInput(letter));
        hexGrid.appendChild(hex);
    });
}


// Function to shuffle letters in the grid
function shuffleLetters() {
    letters.shuffle(); 

    // Ensure the center letter remains in the center
    const centerIndex = letters.indexOf(centerLetter);
    if (centerIndex !== 3) {
        [letters[centerIndex], letters[3]] = [letters[3], letters[centerIndex]];
    }

    initializeLetters();
}

// Function to add a letter to the input field
function addLetterToInput(letter) {
    const inputWord = document.getElementById("current-word");
    inputWord.textContent += letter.toLowerCase();
    validateInput(inputWord.textContent)
}


// Function to delete the last letter from the input field
function deleteLetter() {
    const inputWord = document.getElementById("current-word");
    inputWord.textContent = inputWord.textContent.slice(0, -1);
    validateInput(inputWord.textContent)

}

function validateInput(input){
    if (checkIncorrectLetters(input)){
        document.getElementById("current-word").style.color = 'grey';
    }else{
        document.getElementById("current-word").style.color = 'black';
    }
}
function handleKeyboardInput(event) {
  const letter = event.key.toLowerCase();

  // Check for letters specifically (excluding Backspace)
  if (/[a-z]/.test(letter) && event.key !== "Backspace") { 
      addLetterToInput(letter); 
  } else if (event.key === "Enter") {
      submitWord();
  } else if (event.key === "Backspace" && document.getElementById("current-word").textContent.length > 0) { 
      deleteLetter();
  }
}t

// Function to display a notification message
function showNotification(messageId, points = 0) {
    const notification = document.getElementById(messageId);
    if (points > 0) {
        notification.querySelector('.points').textContent = `+${points}`;
    }
    notification.style.display = 'block';
    setTimeout(() => {
        notification.style.display = 'none';
    }, 2000);
}
// Function to submit a word
function submitWord() {
    const inputWordElement = document.getElementById("current-word");
    const inputWord = inputWordElement.textContent.toLowerCase();

    if (inputWord.length < 4) {
        showNotification("too-short");

    } else if (discoveredWords.includes(inputWord)) {
        showNotification("already-found");

    } else if (!inputWord.includes(centerLetter)) {
        showNotification("miss-center");

    } else if (validWords.includes(inputWord)) {
        const isPangram = checkPangram(inputWord);
        const score = calculateWordScore(inputWord, isPangram);
        addToTotalScore(score);

        showDiscoveredWord(inputWord);
        updateScoreDisplay();

        if (isPangram) {
            showNotification("pangram", score);
        } else {
            const wordLength = inputWord.length;
            if (wordLength >= 7) {
                showNotification("amazing", score);
            } else if (wordLength >= 5) {
                showNotification("great", score);
            } else {
                showNotification("good", score);
            }
        }

    } else {
        showNotification("invalid-word");
    }
    clearInput();
}

// Function to check if a word is a pangram
function checkPangram(word) {
    return letters.every(letter => word.includes(letter));
}

// Function to calculate the score of a word
function calculateWordScore(word, isPangram) {
    const wordLength = word.length;
    let score = wordLength; 
    if (isPangram) {
        score += 7; 
    }
    return score;
}

// Function to add a score to the total score
function addToTotalScore(score) {
    totalScore += score;
    updateScoreDisplay();
}
// Function to update the score display
function updateScoreDisplay() {
    document.getElementById("num-found").textContent = discoveredWords.length;
    document.getElementById("score").textContent = totalScore;
}

// Function to show a discovered word in the list
function showDiscoveredWord(word) {
    discoveredWords.push(word);
    discoveredWords.sort();

    const discoveredWordsElement = document.getElementById("discovered-words");
    discoveredWordsElement.innerHTML = ''; // Clear previous list

    discoveredWords.forEach(word => {
        const wordElement = document.createElement('span');
        wordElement.classList.add('dwords');
        wordElement.textContent = word;
        discoveredWordsElement.appendChild(wordElement);
    });
}

// Function to clear the input field
function clearInput() {
    document.getElementById("current-word").textContent = "";
}

// Shuffle function for arrays (Fisher-Yates Shuffle Algorithm)
Array.prototype.shuffle = function () {
    for (let i = this.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [this[i], this[j]] = [this[j], this[i]];
    }
    return this;
};

// Function to check if the word contains incorrect letters
function checkIncorrectLetters(input) {
    for (let i = 0; i < input.length; i++) {
      if (!letters.includes(input[i])) {
        return true;
      }
    }
    return false;
}

// Attach event listeners when the DOM is fully loaded
document.addEventListener('DOMContentLoaded', () => {
    initGame(); 
});