## 🧠 Memento Pattern – How It Works

### 🧩 **Purpose**

The Memento Pattern is used to **capture and restore** the **internal state** of an object **without violating encapsulation**. This is especially useful when you need features like **undo**, **rollback**, or **state checkpoints**, but you don’t want other parts of your code accessing or modifying the object’s private data directly.

---

### 🛠️ **Core Components**

1. **Originator**

    * The object whose state needs to be saved.
    * It knows how to **create a snapshot** of its current state.
    * It can **restore itself** from a previously saved state.

2. **Memento**

    * A **snapshot** of the originator’s internal state at a specific point in time.
    * It is **opaque** to other objects: they can store it or pass it around, but **they cannot access its contents**.
    * Only the originator can read or write its state.

3. **Caretaker**

    * This object **manages mementos**.
    * It requests the originator to save its state and **stores** the returned mementos.
    * Later, it can give a memento back to the originator to **undo** or **rollback** changes.
    * It doesn’t inspect or alter the mementos.

---

### 🔄 **How It Works – Step-by-Step**

1. The originator is in some state (e.g., text content, game progress, settings).
2. When a change is about to happen, the caretaker asks the originator to **create a memento** (a snapshot of the current state).
3. The caretaker stores this memento (often in a list or stack for undo functionality).
4. The originator continues changing its state.
5. If a rollback or undo is requested, the caretaker gives a **previously saved memento** back to the originator.
6. The originator uses this memento to **restore itself** to that earlier state.

---

### 🔒 **Encapsulation Preserved**

Unlike approaches where you make the internal state public or expose a bunch of getters, the Memento Pattern:

* **Keeps sensitive data hidden**
* Ensures that **only the originator** has access to its own internal structure
* Lets external objects **manage state changes** without knowing any internal details

---

### 🧠 Real-World Analogy

Imagine writing a document:

* Every time you make a change, you **save a copy** of the document in a safe folder (memento).
* You continue editing.
* If something goes wrong or you don’t like the result, you **retrieve a saved copy** and **replace** the current one with it.
* You never need to look inside the saved copy—you just know it’s a faithful backup.

---

### 📌 When to Use

* When you need **undo/redo** or rollback capabilities.
* When object state is complex, and you want to avoid exposing it publicly.
* When you want to **decouple state management logic** from the object itself.

---