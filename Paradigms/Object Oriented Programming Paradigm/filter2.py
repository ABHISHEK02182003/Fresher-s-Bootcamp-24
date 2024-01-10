class StrategyManager:
    _char_checked = ""

    def set_char(self, char):
        self._char_checked = char

    def check_starting_char(self, string):
        return string[0].lower() == self._char_checked.lower()

class StringListFilterController:
    def __init__(self, sample_input_array):
        self.strings = sample_input_array
        self.strategy_instance = StrategyManager()

    def set_strategy_char(self, char):
        self.strategy_instance.set_char(char)

    def filter_strings(self):
        return [string for string in self.strings if self.strategy_instance.check_starting_char(string)]

class ConsoleDisplayController:
    _results = []

    def set_results(self, results_array):
        for result in results_array:
            self._results.append(result)

    def display_results(self):
        for result in self._results:
            print(result)
        print("")

def main():
    sample_input_array = ["Abhishek", "Sameer Trivedi", "Sankhanil Nayek", "Abhinav", "Ishan Madan"]

    filter_instance = StringListFilterController(sample_input_array)
    filter_instance.set_strategy_char('A')

    console_display_instance = ConsoleDisplayController()

    console_display_instance.set_results(filter_instance.filter_strings())

    console_display_instance.display_results()

if __name__ == "__main__":
    main()
