## 🧠 Command Pattern – How It Works

### 🧩 **Purpose**

The **Command Pattern** is used to **encapsulate a request as an object**, thereby allowing you to:

* Parameterize clients with different requests,
* Queue or log requests,
* Support undoable operations.

It promotes decoupling between **sender** and **receiver** by introducing a **command object** that acts as a middleman.

---

### 🛠️ **Core Components**

1. **Command Interface**

    * Declares a method for executing a command (commonly `execute()`).
    * Sometimes includes `undo()` or `redo()` methods.

2. **Concrete Command**

    * Implements the `Command` interface.
    * **Binds a receiver** to an action.
    * Delegates the execution to the appropriate method of the receiver.

3. **Receiver**

    * The object that performs the actual operation when the command is executed.
    * Contains the business logic.

4. **Invoker**

    * Knows how to execute a command but **doesn’t know what it does**.
    * Triggers the command’s `execute()` method.

5. **Client**

    * Creates specific command objects and assigns them to the invoker.
    * Wires everything together (receiver → command → invoker).

---

### 🔄 **How It Works – Step-by-Step**

1. The **client** creates a command object and assigns it to an invoker.
2. The **command** wraps a receiver and a specific action.
3. The **invoker** triggers the command by calling `execute()`.
4. The **command** delegates the action to the **receiver**.
5. (Optional) The command stores state for **undo/redo** functionality.

---

### 🧠 Real-World Analogy

Imagine a **remote control** for a smart home:

* Each button triggers a different command — turn on lights, play music, lock doors.
* The remote (invoker) doesn’t know **how** the light turns on — it just calls `execute()` on a command object.
* The command object knows **what receiver** (e.g., Light) and **what action** (e.g., turn on) to trigger.

This decouples the **button press** from the actual **execution logic**.

---

### 🔧 Without vs With Command Pattern

Without the Command pattern:

```csharp
if (button == "light") { light.TurnOn(); }
else if (button == "music") { music.Play(); }
```

With the Command pattern:

```csharp
button1.Press(); // Internally calls command.Execute()
```

✅ This allows:

* Easy reconfiguration of commands
* History/undo stacks
* Macro commands (combining multiple actions)

---

### 📌 When to Use

* When you want to **parameterize objects** with actions to perform.
* When you need **undo/redo** functionality.
* When you want to **log, queue, or schedule** operations.
* When the invoker should be **decoupled from the logic** of the actions it triggers.
* When implementing **macro commands** (batching multiple commands into one).

---