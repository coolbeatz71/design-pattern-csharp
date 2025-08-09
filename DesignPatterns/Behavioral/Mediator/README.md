## 🧠 Mediator Pattern – How It Works

### 🧩 **Purpose**

The **Mediator Pattern** is used to **reduce direct dependencies between interacting objects** by introducing a **mediator object** that handles all communication.
Instead of objects calling each other directly, they **send messages through the mediator**, which then routes them appropriately.

This promotes **loose coupling**, making the system **easier to maintain, extend, and test**.

---

### 🛠️ **Core Components**

1. **Mediator Interface**

    * Declares methods for communication between **colleague objects**.
    * Defines the contract for coordinating actions.

2. **Concrete Mediator**

    * Implements the mediator interface.
    * Knows all the **colleagues** and coordinates their interactions.
    * Acts as the **central hub** for communication.

3. **Colleague Interface (or Abstract Class)**

    * Represents participants that communicate through the mediator.
    * Holds a reference to the mediator to send messages.

4. **Concrete Colleagues**

    * Implement the colleague interface.
    * Instead of talking to each other directly, they **delegate communication** to the mediator.

---

### 🔄 **How It Works – Step-by-Step**

1. Colleagues are registered with a **mediator**.
2. When one colleague wants to interact with another, it **sends a message to the mediator**.
3. The mediator receives the message, **figures out who should receive it**, and forwards it.
4. Colleagues **never directly reference each other** — only the mediator.

---

### 🧠 Real-World Analogy

Imagine an **air traffic control tower**:

* Planes (colleagues) **don’t talk to each other directly** to coordinate landings.
* Instead, they **communicate with the tower** (mediator).
* The tower knows the status of every plane and **tells each one what to do**.

If a new type of plane is added, you just update the tower’s logic — not every plane’s code.

---

### 🔧 Without vs With Mediator Pattern

Without the Mediator pattern:

```csharp
// Each colleague directly knows others
pilot1.SendMessageTo(pilot2);
pilot2.SendMessageTo(pilot3);
pilot3.SendMessageTo(pilot1);
```

With the Mediator pattern:

```csharp
mediator.SendMessage(sender, "Request to land");
```

✅ Now, **communication rules live in one place** — the mediator — reducing tangled dependencies.

---

### 📌 When to Use

* When **many objects** interact in complex ways.
* When adding/removing participants would cause **ripple effects** in other classes.
* When you want **centralized control** of interactions.
* When you need to **decouple components** for easier maintenance.
