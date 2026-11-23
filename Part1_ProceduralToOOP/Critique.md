# C++ Source Code – Design Critique

## 1. Global Data and Lack of Encapsulation

The program stores almost all application data in global variables, including customer information, product information, order details, and inventory.

**Why is this a problem?**

Any function can directly access and modify these variables. There is no protection controlling how the data is accessed or changed.

**What could go wrong?**

A function could accidentally modify important information

## 2. Using Parallel Arrays Instead of Objects

Customer information is distributed across separate arrays, such as `customerIds`, `customerNames`, `customerEmails`, `customerCities`, and `customerIsVip`. The same approach is used for products and orders.

**Why is this a problem?**

Related information is separated instead of being grouped into a single logical entity. The relationship between these values depends entirely on maintaining matching array indexes.

**What could go wrong?**

If an element is inserted, deleted, or modified incorrectly in one array, customer information could become inconsistent. For example, an email address could become associated with the wrong customer.

## 3. Weak Input Validation

The interactive menu uses `cin >>` directly without checking whether the entered values are valid.

**Why is this a problem?**

The application assumes that users always provide valid input.

**What could go wrong?**

It causes Errors.

## 4. Unclear Function Responsibilities and Return Values

Some functions perform business operations but return `void`.

**Why is this a problem?**

The caller cannot easily determine whether an operation succeeded or failed without relying on console output.

**What could go wrong?**

Other parts of the application cannot reliably respond to operation failures 

## 5. No Clear Separation of Responsibilities

The application contains customer management, product management, inventory operations, order processing, payment handling, calculations, and console presentation in one procedural structure.

**Why is this a problem?**

Different responsibilities are not organized into independent components.

**What could go wrong?**

As new features are introduced, functions become increasingly dependent on shared data and implementation details. This makes maintenance, debugging, testing, and extending the application more difficult.

---

