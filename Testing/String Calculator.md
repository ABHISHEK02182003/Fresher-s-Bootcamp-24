
# String Calculator

A brief description of what this project does and who it's for

TEST SPECIFICATION : 

1. Given a string -> int 
	- "" or "1" or "1,2"

2. Handle Empty strings 
	"" -> 0

3. Method should be able to handle new lines : 
	("1\n2, 3") -> 6

4. Invalid inputs must be handled : 
        ("1,\n") -> throw an exception

5. Support different delimiters : 
        "//;\n1;2" -> 3, Here the default delimiter is ';'.

6. Calling the method with a negative number should throw an exception : 
        "-1,2" -> Throw an exception.

7. Multiple negative numbers in the method, Show all of them in the Exception Message : 
        "-1, -2, -3, 4" -> Throw exception with (-1, -2, -3)

8. Handle Unknown amount of numbers - 
        "1,1,1,1........1" <= 2^(64) - 1

9. Numbers bigger than 1000 should be ignored : 
        "2, 1001" -> 2

10. Delimiters can be of any length with the following format : 
        "//[***]\n1***2***3" -> 6

11. Allow multiple Delimiters : 
        "//[*][%]\n1*2%3" -> 6.


