def permute(s):

    def permute_helper(s, l, r):
        if l == r:
            permutations.append(''.join(s))
        else:
            for i in range(l, r + 1):

                s[l], s[i] = s[i], s[l]

                permute_helper(s, l + 1, r)

                s[l], s[i] = s[i], s[l]

    s = list(s)
    n = len(s)
    permutations = []

    permute_helper(s, 0, n - 1)
    return permutations


input_string = input("Enter a string: ")
result = permute(input_string)
print("All permutations of", input_string, "are:", result)
