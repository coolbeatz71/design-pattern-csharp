## 🧠 Strategy Pattern – How It Works

### 🧩 **Purpose**

The **Strategy Pattern** is used to **define a family of algorithms**, encapsulate each one, and make them **interchangeable** at runtime. Instead of hardcoding different behaviors using conditionals, the pattern promotes composition by delegating behavior to a separate **strategy object**.

It allows a class’s behavior to be selected **dynamically**, without modifying the class itself.

---

### 🛠️ **Core Components**

1. **Context**

    * The object that uses a strategy to perform its behavior.
    * It’s **configured with a strategy** object.
    * It delegates algorithmic behavior to the strategy.

2. **Strategy Interface**

    * Declares the method(s) that all strategies must implement.
    * Defines the contract for behavior the context can use.

3. **Concrete Strategies**

    * Implement the strategy interface with **specific variations of an algorithm**.
    * These are easily interchangeable without modifying the context.

---

### 🔄 **How It Works – Step-by-Step**

1. The context is initialized with a specific strategy (or it can be set later).
2. When the context performs an operation, it **delegates to the strategy object**.
3. The selected strategy executes its version of the algorithm.
4. At runtime, you can **swap the strategy** to change the behavior of the context without altering its structure.

---

### 🧠 Real-World Analogy

Imagine a **navigation app**:

* It offers different **route calculation strategies** — like **fastest**, **shortest**, or **eco-friendly**.
* The user selects a strategy based on preference.
* The app (context) doesn’t know the details of the algorithms. It simply delegates to the chosen strategy.

So you can easily switch from "fastest" to "eco-friendly" **without rewriting the navigation logic**.

---

### 🔧 Without vs With Strategy Pattern

Without the Strategy pattern:

```csharp
if (mode == "fastest") { CalculateFastest(); }
else if (mode == "eco") { CalculateEcoFriendly(); }
else if (mode == "shortest") { CalculateShortest(); }
```

With the Strategy pattern:

```csharp
strategy.CalculateRoute(); // No conditionals, just polymorphism
```

✅ This leads to cleaner code, **open for extension**, and better separation of concerns.

---

### 📌 When to Use

* When you need to **switch between multiple algorithms** dynamically.
* When your class has many conditional statements based on different behaviors.
* When you want to **decouple the behavior implementation** from the class that uses it.
* When behaviors are **independent and reusable**, and you want to avoid duplicating logic.

---