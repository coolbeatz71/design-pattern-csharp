
# Fragile Base Class Problem

The **Fragile Base Class Problem (FBCP)** is a common object-oriented design issue that arises when changes made to a base class inadvertently break the behavior of its derived (child) classes. It typically happens in large systems where multiple developers rely on inheritance and where the base class wasn't designed with extensibility in mind.

This is mainly the reason why one can prefer composition over inheritance.

When a base class evolves (e.g., by adding a new method, changing internal state, or modifying control flow), it can cause unexpected side effects in child classes that rely on its previous structure. These changes can break the logic of derived classes even though those classes have not changed themselves.

---

## Problem Breakdown

### 1. Inheritance Coupling

Inheritance creates a strong coupling between the base class and its derived classes. This is known as **inheritance coupling**, and it results in:

- Tight interdependency: Any internal change to the base class (like method refactoring, private field renaming, or side-effect introduction) can unintentionally propagate bugs to subclasses.
- Leaky abstractions: Subclasses may depend on implementation details of the base class instead of its public API. When the implementation changes, these subclasses break.

#### Example (C#)

```csharp
// Base class - Version 1
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}

// Derived class
public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
```

Now suppose the base class evolves:

```csharp
// Base class - Version 2 (modified)
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
        LogSpeaking(); // new behavior
    }

    private void LogSpeaking()
    {
        // logging logic
    }
}
```

Even though `Dog` hasn't changed, the `Speak` behavior may now trigger side-effects like logging. This could result in:

- Duplicated logging if `Dog` also logs.
- Violations of business rules in `Dog` due to unexpected behavior in `Speak`.

---

### 2. Limited Extensibility

Base classes can unintentionally **limit extensibility** when:

- Internal state is not accessible or modifiable by derived classes.
- Methods are not marked as `virtual`, `protected`, or `open` (depending on the language).
- Changes to the base class control flow make assumptions that don’t hold in derived classes.

Developers may avoid making necessary changes due to the fear of breaking existing functionalities. This is known as `Brittle software`.

#### Anti-Example (Java)

```java
public class Report {
    private void generateHeader() {
        // Header generation logic
    }

    private void generateFooter() {
        // Footer generation logic
    }

    public final void generateReport() {
        generateHeader();
        // ... generate body ...
        generateFooter();
    }
}
```

In this design:

- Derived classes cannot override `generateHeader()` or `generateFooter()` to customize behavior.
- `generateReport()` is `final`, so it's completely unextensible.

---

## Mitigation Strategies

### 1. Prefer Composition Over Inheritance

Instead of relying on inheritance, use composition to inject behavior:

```csharp
public interface ISpeakBehavior
{
    void Speak();
}

public class DogSpeak : ISpeakBehavior
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

public class Animal
{
    private readonly ISpeakBehavior _speakBehavior;

    public Animal(ISpeakBehavior speakBehavior)
    {
        _speakBehavior = speakBehavior;
    }

    public void PerformSpeak()
    {
        _speakBehavior.Speak();
    }
}
```

This avoids inheritance coupling and makes it easy to extend or replace behavior at runtime.

---

### 2. Use Template Method Pattern Carefully

If inheritance is required, use the Template Method Pattern while keeping overridable behavior clear and predictable.

```csharp
public abstract class ReportTemplate
{
    public void GenerateReport()
    {
        GenerateHeader();
        GenerateBody();
        GenerateFooter();
    }

    protected abstract void GenerateHeader();
    protected abstract void GenerateBody();
    protected abstract void GenerateFooter();
}
```

This gives derived classes hooks for customization without tightly coupling them to internal base class logic.

---

### 3. Design for Inheritance (Liskov Substitution Principle)

Follow the **Liskov Substitution Principle (LSP)**:

> "Subtypes must be substitutable for their base types."

This means base classes should:

- Be open for extension but closed for modification (Open/Closed Principle).
- Avoid making assumptions about subclass behavior.
- Expose clear extension points via `virtual`, `protected`, or `abstract` methods.

---

### 4. Minimize the Surface Area of Inheritance

- Keep base class logic simple and minimal.
- Use `sealed`/`final` to prevent further inheritance if it’s not needed.
- Don't expose internal details as `protected` unless necessary.

---

### 5. Use Testing to Detect Breakage

Introduce contract tests or integration tests that validate subclass behavior under base class changes. This acts as a safety net for future refactors.

---

## Summary

| Concept                | Description                                                                 |
|------------------------|-----------------------------------------------------------------------------|
| Fragile Base Class     | Changes in base class can break derived class behavior                      |
| Inheritance Coupling   | Tight binding between parent and child leads to brittle design              |
| Limited Extensibility  | Subclasses may be unable to modify or extend behavior                       |
| Mitigation             | Prefer composition, use template methods with care, follow SOLID principles |

---

## Further Reading

- [Effective Java – Item 18: Favor composition over inheritance](https://books.google.com/books/about/Effective_Java.html?id=ka2VUBqHiWkC)
- [Design Patterns: Template Method](https://refactoring.guru/design-patterns/template-method)
- [Liskov Substitution Principle](https://en.wikipedia.org/wiki/Liskov_substitution_principle)
