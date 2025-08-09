---

## 👀 Observer Pattern – How It Works

### 🧩 **Purpose**

The **Observer Pattern** is used to **establish a one-to-many relationship** between objects, so that when **one object (the subject) changes state**, all its **dependents (observers)** are **automatically notified** and updated.

It promotes **loose coupling** between the subject and its observers, allowing either side to vary independently.

---

### 🛠️ **Core Components**

1. **Subject (Observable)**

    * Maintains a list of observers.
    * Provides methods to **attach** or **detach** observers.
    * Notifies all observers whenever its state changes.

2. **Observer Interface**

    * Declares the **update method** that subjects call when notifying changes.
    * Defines the contract for all observers.

3. **Concrete Observers**

    * Implement the observer interface.
    * React to state changes in the subject in their own way.

---

### 🔄 **How It Works – Step-by-Step**

1. Observers register themselves with the subject to receive updates.
2. When the subject’s state changes, it **calls `update()`** on all registered observers.
3. Each observer decides how to handle the new state.
4. Observers can **unsubscribe** if they no longer need updates.

---

### 🧠 Real-World Analogy

Imagine a **YouTube channel**:

* The channel is the **subject**.
* Subscribers are **observers**.
* When a new video is uploaded, the channel **notifies all subscribers** automatically.
* Subscribers can unsubscribe at any time without affecting the channel.

So the channel doesn’t need to know *who* the subscribers are or *what* they’ll do with the update—it just sends the notification.

---

### 🔧 Without vs With Observer Pattern

Without the Observer pattern:

```csharp
class WeatherStation {
    public void UpdateData() {
        screen1.Display();
        screen2.Display();
        mobileApp.Display();
    }
}
```

❌ Tight coupling – the subject knows **all** observers directly.

With the Observer pattern:

```csharp
weatherStation.RegisterObserver(screen);
weatherStation.RegisterObserver(mobileApp);
weatherStation.NotifyObservers();
```

✅ Loose coupling – the subject **only knows** it has observers, not their details.

---

### 📌 When to Use

* When changes to one object require updates to others **without tightly coupling them**.
* When an object should be able to notify others **without knowing their concrete types**.
* When you have **event-driven systems**, like UI frameworks or messaging systems.
* When you want **dynamic subscription** and unsubscription.

---