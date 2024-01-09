def filter_strings(strings, checking_criteria):
    return [string for string in strings if checking_criteria(string)]

def display_result_on_console(array_of_results):
    for elements in array_of_results:
        print(elements)

def check_starting_char_if_a(string):
    return string[0] == "A"

def check_ending_char_if_i(string):
    return string[-1] == "i"

if __name__ == "__main__":
    sample_array_of_strings = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Ishan Madan", "Arravelly Keerthi"]
    display_result_on_console(filter_strings(sample_array_of_strings, check_starting_char_if_a))
    display_result_on_console(filter_strings(sample_array_of_strings, check_ending_char_if_i))
