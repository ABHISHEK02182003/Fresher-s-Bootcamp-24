def filter_strings(strings, checking_criteria):
    return [string for string in strings if checking_criteria(string)]

def display_result_on_console(array_of_results):
    for elements in array_of_results:
        print(elements)

def create_starting_char_checker(char):
    def check_starting_char(string):
        return string[0].lower() == char.lower()
    return check_starting_char

def create_ending_char_checker(char):
    def check_ending_char(string):
        return string[-1].lower() == char.lower()
    return check_ending_char

if __name__ == "_main_":
    sample_array_of_strings = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Ishan Madan", "Arravelly Keerthi "]

    for char in ['a', 'd', 's', 'i']:
        starting_char_check = create_starting_char_checker(char)
        display_result_on_console(filter_strings(sample_array_of_strings, starting_char_check))

    for char in ['a', 'd', 's', 'i']:
        ending_char_check = create_ending_char_checker(char)
        display_result_on_console(filter_strings(sample_array_of_strings, ending_char_check))
