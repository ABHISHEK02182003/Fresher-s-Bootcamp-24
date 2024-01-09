from typing import List, Callable

def filter_elements(arr: List[int], criteria: Callable[[int], bool]) -> List[int]:
    result = [ele for ele in arr if criteria(ele)]
    return result

def main():
    print("Hello World")

if __name__ == "__main__":
    main()

