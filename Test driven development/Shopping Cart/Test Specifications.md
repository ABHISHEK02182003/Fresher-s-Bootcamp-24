Test Case Specifications Document:

### Test Case 1: Calculate total price for an empty shopping cart
- **Input:** ""
- **When:** The checkout receives an empty string representing an empty shopping cart.
- **Then:** The total price should be 0.

### Test Case 2: Calculate total price for a single item
- **Input:** "A"
- **When:** The checkout receives a string with a single item "A".
- **Then:** The total price should be 50.

### Test Case 3: Calculate total price for two different items
- **Input:** "AB"
- **When:** The checkout receives a string with two items "A" and "B".
- **Then:** The total price should be 50 + 30 = 80.

### Test Case 4: Calculate total price for multiple items in any order
- **Input:** "CDBA"
- **When:** The checkout receives a string with items "C", "D", "B", and "A" in any order.
- **Then:** The total price should be the sum of individual prices: 20 + 15 + 30 + 50 = 115.

### Test Case 5: Calculate total price with special offers
- **Input:** "AAA"
- **When:** The checkout receives a string with three items "A".
- **Then:** The total price should be the special offer price: 130.

### Test Case 6: Calculate total price with multiple special offers
- **Input:** "AAABB"
- **When:** The checkout receives a string with three items "A" and two items "B".
- **Then:** The total price should be the sum of special offer prices: (130) + (45) = 175.

### Test Case 7: Calculate total price with a mix of items and special offers
- **Input:** "AAABBD"
- **When:** The checkout receives a string with three items "A", two items "B", and one item "D".
- **Then:** The total price should be the sum of special offer prices and individual prices: (130) + (45) + (15) = 190.

### Test Case 8: Calculate total price for items without special offers
- **Input:** "DCBA"
- **When:** The checkout receives a string with items "D", "C", "B", and "A".
- **Then:** The total price should be the sum of individual prices: 15 + 20 + 30 + 50 = 115.
