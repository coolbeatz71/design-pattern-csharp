## 🧠 State Pattern – How It Works

### 🧩 **Purpose**

The **State Pattern** is used to **allow an object to change its behavior when its internal state changes**, as if the object **morphs into a different class**. Instead of using long `if/else` or `switch` statements to handle state-dependent behavior, the pattern promotes cleaner design by encapsulating state-specific logic into dedicated classes.

---

### 🛠️ **Core Components**

1. **Context**

    * The object whose behavior changes based on its state.
    * It holds a reference to the current state object and delegates behavior to it.
    * It can switch to a different state dynamically.

2. **State Interface**

    * Declares methods that represent behavior depending on the state.
    * All concrete state classes implement this interface.

3. **Concrete States**

    * Each class represents a specific state and its behavior.
    * They override methods declared in the state interface to define **state-specific behavior**.
    * They may also trigger **state transitions**.

---

### 🔄 **How It Works – Step-by-Step**

1. The context starts with an initial state.
2. When the context receives a request (e.g. `Handle()` or `Request()`), it **delegates the call** to its current state object.
3. The current state object handles the logic **specific to that state**.
4. The state object may decide to **change the context’s state**, causing the behavior to shift.
5. From the outside, it looks like the object changed its class — even though the object itself remained the same.

---

### 🧠 Real-World Analogy

Imagine a **document editor**:

* It can be in **"Read-only"**, **"Edit"**, or **"Preview"** mode.
* Each mode changes **what actions are allowed** (e.g., typing is disabled in read-only).
* When you click a toolbar button, the editor transitions to a different state.
* The editor object remains the same, but its behavior is driven by the current mode.

---

### 🔒 Why Use It Instead of Switch Statements?

Without the State pattern:

```csharp
if (state == "editing") { ... }
else if (state == "readonly") { ... }
else if (state == "preview") { ... }
```

With the State pattern:

```csharp
state.Handle(); // Polymorphism replaces conditionals
```

✅ It’s cleaner, open for extension, and reduces complexity.

---

### 📌 When to Use

* When an object’s behavior depends heavily on its **current internal state**.
* When you find yourself writing complex conditionals that check a `state` field.
* When states have **distinct responsibilities**, and you want to separate them cleanly.
* When you need **runtime flexibility** to switch behavior without changing the context's class.