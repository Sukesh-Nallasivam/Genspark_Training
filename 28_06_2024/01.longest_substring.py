def longest_substring_without_repeating_characters(s):
  start = 0
  max_length = 0
  seen = set()

  for i in range(len(s)):
    while s[i] in seen:
      seen.remove(s[start])
      start += 1
    seen.add(s[i])
    max_length = max(max_length, i - start + 1)

  return max_length

string = input("Enter a string: ")
longest_length = longest_substring_without_repeating_characters(string)
print(f"The length of the longest substring without repeating characters is: {longest_length}")