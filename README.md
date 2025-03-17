# **🍜 NoodleDB – A Lightweight File-Based Database in C#**  

### **🚀 Overview**  
**NoodleDB** is a lightweight, file-based database system implemented in **C#**. It allows you to store, manage, and retrieve structured data using a simple, human-readable `.ndb` file format. It supports **multiple tables, CRUD operations, and optional encryption** to keep your data secure.  

---

## **📌 Features**  
✅ **Simple & Lightweight** – No dependencies, just C# and file I/O.  
✅ **Multiple Tables** – Store structured data in separate tables.  
✅ **CRUD Operations** – Create, Read, Update, and Delete records easily.  
✅ **Human-Readable Format** – `.ndb` files are plain-text and easy to debug.  
✅ **Encryption Support (Coming Soon 🔒)** – Secure your database with AES encryption.  

---

## **📂 NoodleDB File Format (`.ndb`)**  
Example of a **NoodleDB file**:  
```
# NoodleDB v1.0

[TABLE: Users]
columns: ID | Name | Age | Email
1 | Alice | 25 | alice@example.com
2 | Bob | 30 | bob@example.com
3 | Charlie | 22 | charlie@example.com

[TABLE: Products]
columns: ProductID | Name | Price | Stock
101 | Laptop | 1200 | 5
102 | Mouse | 25 | 50
103 | Keyboard | 45 | 30
```

---

## **🛠️ Installation**  
1. Clone the repository:  
   ```sh
   git clone https://github.com/aasemshokr/NoodleDB.git
   cd NoodleDB
   ```
2. Open the project in **Visual Studio** or any **C# IDE**.  
3. Build and run the project.  

---

## **🔹 Usage**  

### **1️⃣ Initialize NoodleDB**  
```csharp
NoodleDatabase db = new NoodleDatabase("database.ndb");
```

### **2️⃣ Create a Table**  
```csharp
db.CreateTable("Users", new List<string> { "ID", "Name", "Age", "Email" });
```

### **3️⃣ Insert a Record**  
```csharp
db.InsertRecord("Users", new Dictionary<string, string> { 
    { "ID", "1" }, { "Name", "Alice" }, { "Age", "25" }, { "Email", "alice@example.com" } 
});
```

### **4️⃣ Read a Table**  
```csharp
List<Record> users = db.ReadTable("Users");
foreach (var user in users)
{
    Console.WriteLine(user);
}
```

### **5️⃣ Update a Record**  
```csharp
db.UpdateRecord("Users", "ID", "1", new Dictionary<string, string> { { "Age", "26" } });
```

### **6️⃣ Delete a Record**  
```csharp
db.DeleteRecord("Users", "ID", "1");
```

### **Don't Forget to save the changes**  
```csharp
db.SaveDatabase();
```

---

## **🔒 Upcoming Features**  
- **AES Encryption** for `.ndb` files  
- **Indexing for Faster Queries**  
- **Basic Query Language (NQL) for Filtering Data**  

---

## **📜 License**  
This project is licensed under the **MIT License**. Feel free to modify and use it in your projects.  

---

## **🤝 Contributing**  
Contributions are welcome! Feel free to submit pull requests or open issues.  

---

## **👨‍💻 Author**  
**Aasem Shokr** – *Computer Scientist, Software Engineer*
