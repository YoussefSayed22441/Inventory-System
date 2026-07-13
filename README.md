# 📦 Full-Stack Inventory Management System (IMS)

![React 19](https://img.shields.io/badge/React_19-20232A?logo=react&logoColor=61DAFB&style=for-the-badge)
![Vite](https://img.shields.io/badge/Vite-646CFF?logo=vite&logoColor=white&style=for-the-badge)
![Redux Toolkit](https://img.shields.io/badge/Redux-593D88?logo=redux&logoColor=white&style=for-the-badge)
![Three.js](https://img.shields.io/badge/Three.js-000000?logo=three.js&logoColor=white&style=for-the-badge)
![Framer Motion](https://img.shields.io/badge/Framer_Motion-0055FF?logo=framer&logoColor=white&style=for-the-badge)
![.NET 10](https://img.shields.io/badge/.NET_10-512BD4?logo=dotnet&logoColor=white&style=for-the-badge)

> A high-performance, secure, and visually interactive inventory and sales tracking system developed as part of the **Digital Egypt Pioneers Initiative (DEPI)**. Designed to streamline warehouse operations, supplier management, and stock transfers with a focus on cutting-edge UI/UX.

---

## ✨ Standout Features
* **Cinematic 3D Experience:** Utilizes `Three.js` and `Framer Motion` to create a deeply immersive environment, including a custom animated 3D crate intro sequence and an interactive background canvas.
* **Custom Glassmorphism UI:** Built with a highly modular, variables-driven CSS architecture featuring frosted glass panels, ambient neon glow states, and fluid responsive layouts.
* **Robust State Management:** Implements `@reduxjs/toolkit` for predictable, scalable state tracking across inventory, categories, suppliers, and real-time notifications.
* **Stateless Security Architecture:** Fully secured API using JWT (JSON Web Tokens) Bearer authentication via headers, utilizing a custom protected routing system (`ProtectedRoute`) and automated Axios interceptors.
* **Clean Architecture Backend:** Powered by `.NET 10`, separating API, Core, Domain, Infrastructure, and Service layers with CQRS (MediatR), FluentValidation, and AutoMapper.

---

## 🛠️ Tech Stack

### Frontend (Client)
* **Core:** React.js 19 + Vite + React Router DOM
* **State Management:** Redux Toolkit (RTK)
* **Styling & Motion:** Custom CSS3 (Glassmorphism), Three.js, Framer Motion, Lucide Icons
* **Networking:** Axios (with custom auth interceptors)

### Backend (Server)
* **Framework:** C# / .NET 10 Web API
* **ORM:** Entity Framework Core
* **Database:** SQL Server
* **Patterns:** CQRS (MediatR), Repository Pattern

---

## 🚀 Getting Started

### Prerequisites
* [Node.js (LTS)](https://nodejs.org/)
* [.NET 10 SDK](https://dotnet.microsoft.com/)
* SQL Server

### 1. Backend Setup
Navigate to the API directory, apply the database migrations, and start the server:
` ` `bash
cd server/Inventory-System/Inventory-System.API
dotnet ef database update
dotnet run
` ` `

### 2. Frontend Setup
Navigate to the React client, install dependencies, and start the development server:
` ` `bash
cd client/IMS-Front
npm install


npm run dev
` ` `

---

## 👨‍💻 Development Team

  | Team Member | Project Role | GitHub Profile |
  | :--- | :--- | :--- |
  | **Khaled Maher** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/KhaledMaher923) |
  | **Osama Reda** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/osamateama) |
  | **Youssef Sayed** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/YoussefSayed22441) |
  | **Nour Essam** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/nour3ssam) |
  | **Ezzat Karem** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/Ezzatkarem) |
  | **Abdelrahman Ahmed** | Software Engineer | [![GitHub](https://img.shields.io/badge/GitHub-181717?logo=github&style=flat-square)](https://github.com/Ash3nBeast) |

---
