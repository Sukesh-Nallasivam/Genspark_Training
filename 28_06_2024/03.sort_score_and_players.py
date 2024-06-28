players = [
    ("Avani", 120),
    ("Rahul", 95),
    ("Ananya", 150),
    ("Siddharth", 80),
    ("Priya", 110),
    ("Aryan", 130),
    ("Aditi", 100),
    ("Rohan", 75),
    ("Riya", 140),
    ("Akshay", 105),
    ("Shreya", 90),
    ("Aditya", 125),
    ("Neha", 115),
    ("Karan", 85),
    ("Ishaan", 135),
]


def sort_by_score(player):
  return player[1]

sorted_players = sorted(players, key=sort_by_score, reverse=True)


print("Top 10 Players:")
for i in range(10):
    name, score = sorted_players[i]
    print(f"{i+1}. {name}: {score}")