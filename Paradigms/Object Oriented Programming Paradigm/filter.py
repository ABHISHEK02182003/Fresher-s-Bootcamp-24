class StringListFilterController:
    def __init__(self, sample_input_array):
        self.strings = sample_input_array

    def filter_strings(self, strings, checking_criteria):
        return [string for string in strings if checking_criteria(string)]

class PredicateGenerator:
    def __init__(self, char):
        self.start_char = char

    def create_starting_char_checker(self):
        def check_starting_char(string):
            return string[0].lower() == self.start_char.lower()
        return check_starting_char

class ConsoleDisplayController:
    _results = []
    def set_results(cls, results_array): 
        for result in results_array:
            cls._results.append(result)
    def display_results(cls): 
        for result in cls._results:
            print(result)
        print("")


def main():
    sample_input_array = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Abhinav", "Ishan Madan"]

    filter_instance = StringListFilterController(sample_input_array)

    predicate_instance = PredicateGenerator('A')

    checking_criteria = predicate_instance.create_starting_char_checker()

    ConsoleDisplayController_instance = ConsoleDisplayController()

    ConsoleDisplayController_instance.set_results(filter_instance.filter_strings(filter_instance.strings, checking_criteria))

    ConsoleDisplayController_instance.display_results()

if __name__ == "__main__":
    main()
    
