def search_element(arr, target):
    for index, element in enumerate(arr):
        if element == target:
            return index 
    return -1  

my_array = [1, 3, 5, 7, 9, 11]
target_element = 7

result = search_element(my_array, target_element)

if result != -1:
    print(f"Element {target_element} found at index {result}")
else:
    print(f"Element {target_element} not found in the array")
