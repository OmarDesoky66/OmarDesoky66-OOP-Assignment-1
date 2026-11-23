# Task 3.1 — The Class

## Question 1: Why is a single constructor with 20 parameters a problem?

- **Poor readability:** It is difficult to understand what each argument represents.
- **Wrong argument order:** Parameters with the same data type can easily be mixed up without causing compilation errors.
- **Difficult maintenance:** Adding or changing properties requires updating the constructor and its usages.

## Question 2: Is the problem only the long constructor, or is there a deeper design issue?

There is a deeper design issue. The `Invoice` class contains several different concepts, such as customer information, addresses, and order details.

A better design is to separate them into smaller classes:

- `Address`: Handles billing and shipping address information.
- `Order`: Handles order and payment information.
- `Invoice`: Combines customer information, addresses, and order details.

