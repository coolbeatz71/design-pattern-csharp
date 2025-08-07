## 🧠 Template Method Pattern – How It Works

### 🧩 **Purpose**

The **Template Method Pattern** defines the **skeleton of an algorithm** in a base class and lets **subclasses override specific steps** without changing the overall structure.

It’s all about **inversion of control**: the base class controls the algorithm structure, but allows the subclasses to plug in specific behaviors.

This ensures **consistency of algorithm structure** while allowing **customizable steps**.

---

### 🛠️ **Core Components**

1. **Abstract Class (Template)**

    * Defines the **template method** – a final method that outlines the overall algorithm.
    * Implements **default behavior** for some steps (optional).
    * Leaves some steps as **abstract or overridable**, so subclasses can customize them.

2. **Concrete Subclasses**

    * Override one or more **primitive operations** (i.e., steps in the algorithm).
    * Customize parts of the algorithm without changing its structure.

---

### 🔄 **How It Works – Step-by-Step**

1. The abstract class defines a method (the **template method**) that outlines the full algorithm.
2. The template method calls other methods (some implemented, some abstract).
3. Subclasses inherit the structure but override specific methods to vary behavior.
4. The algorithm runs in a **controlled and predictable sequence**, with custom behavior injected via overridden methods.

---

### 🧠 Real-World Analogy

Imagine you're making **coffee or tea**:

* There’s a general recipe: **boil water → brew → pour → add condiments**.
* The structure stays the same, but the **brewing step differs** for tea and coffee.
* The base class (Recipe) provides the full structure.
* Subclasses (CoffeeRecipe, TeaRecipe) **override `brew()`** to specify what to do.

So the **template method** ensures the steps run in the right order, even though the details differ.

---

### 🔧 Without vs With Template Method

Without the Template Method pattern:

```csharp
void MakeBeverage(string type) {
    BoilWater();
    if (type == "tea") BrewTea();
    else if (type == "coffee") BrewCoffee();
    PourInCup();
    AddCondiments();
}
```

With the Template Method pattern:

```csharp
abstract class Beverage {
    public void Make() {
        BoilWater();
        Brew();          // Abstract – subclass implements
        PourInCup();
        AddCondiments(); // Optional override
    }

    protected abstract void Brew();
    protected virtual void AddCondiments() {}
}
```

✅ This removes conditionals, ensures consistent structure, and **pushes responsibility to subclasses** for behavior-specific logic.

---

### 📌 When to Use

* When you have **common algorithm structure** with variations in some steps.
* When you want to **avoid code duplication** across multiple classes doing similar work.
* When you want to **preserve algorithm control flow** while allowing flexibility.
* When behavior should be enforced in a certain **sequence**.

---
