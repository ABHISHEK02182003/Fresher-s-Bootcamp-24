def search_element(arr, target):
    for index, element in enumerate(arr):
        if element == target:
            return display_result_on_console(target, index)
    return display_result_on_console(target, -1)

def display_result_on_console(target, k):
    if k != -1:
        print(f"Element {target} found at index {k}")
    else:
        print(f"Element {target} not found in the array")

def main():
    sample_array = [1, 3, 5, 7, 9, 11]
    sample_target_element = 7
    search_element(sample_array, sample_target_element)

if __name__ == "__main__":
    main()

