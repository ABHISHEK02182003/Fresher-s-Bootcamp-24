class Filter:
    def __init__(self, sample_input_array):
        self.strings = sample_input_array

    def filter_strings(self, strings, checking_criteria):
        return [string for string in strings if checking_criteria(string)]

class Predicate:
    def __init__(self, start_char):
        self.char = start_char

    def create_starting_char_checker(self):
        def check_starting_char(string):
            return string[0].lower() == self.char.lower()
        return check_starting_char

class DisplayResultOnConsole:
    def __init__(self, array_of_results):
        self.results = array_of_results

    def display_results(self):
        for result in self.results:
            print(result)
        print("")

def main():
    sample_input_array = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Ishan Madan", "Arravelly Keerthi "]

    # Example usage
    filter_instance = Filter(sample_input_array)

    # Create a predicate with the starting character 'A'
    predicate_instance = Predicate('A')

    # Use the predicate to create a checking criteria
    checking_criteria = predicate_instance.create_starting_char_checker()

    # Filter the strings based on the checking criteria
    filtered_strings = filter_instance.filter_strings(filter_instance.strings, checking_criteria)

    # Display the results on the console
    display_instance = DisplayResultOnConsole(filtered_strings)
    display_instance.display_results()

if __name__ == "__main__":
    main()
