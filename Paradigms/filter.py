def filter_strings(strings, check_predicate):
    return [string for string in strings if check_predicate(string)]

def display_result_on_console(array_of_results):
    for elements in array_of_results:
        print(elements)

def check_starting_string_if_a(string):
    return string[0] == "A"

if __name__ == "__main__":
    sample_array_of_strings = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Abhinav Modi", "Arravelly Keerthi "]
    display_result_on_console(filter_strings(sample_array_of_strings, check_starting_string_if_a))
