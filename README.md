## QrCode.Generator

### Overview 🔍

The QrCode.Generator repository is a .NET 8 solution that provides robust QR code generation capabilities through two main projects: a WPF desktop application and an ASP.NET Core Web API. These projects are designed to address a variety of QR code generation scenarios, including bookmarks, contact information, events, payment codes, email, and WiFi configuration.

---

### Projects 📁

#### 1. QrCode.Generator (WPF Desktop Application) 🖥️

This project is a Windows Presentation Foundation (WPF) application that offers a graphical user interface for generating and exporting QR codes.

**Technical Details:**

- **Target Framework:** .NET 8.0
- **Output Type:** WinExe (Windows desktop application)
- **UI Technology:** WPF with XAML
- **Architecture:** MVVM pattern with dependency injection
- **Deployment:** Single-file publish enabled, includes application icon and embedded resources

**Features:**

- Interactive interface for generating QR codes of various types
- Real-time preview and export of QR codes
- Support for GiroCode, WiFi, bookmarks, contacts, events, and mail QR codes
- Extensible via custom controls and services

**Dependencies:**

- BB84.Extensions
- BB84.Notifications
- DotNetProjects.Extended.Wpf.Toolkit
- Microsoft.Extensions.Hosting
- QRCoder.Xaml

**Structure:**

- **Controls:** Custom WPF controls for QR code types
- **Models:** Data models for QR code content
- **Services:** Business logic and export functionality
- **ViewModels:** MVVM data binding and logic
- **Windows:** Main application windows

---

#### 2. QR-Code.API (ASP.NET Core Web API) 🌐

This project exposes QR code generation functionality via a RESTful API, suitable for integration with other systems and automation.

**Technical Details:**

- **Target Framework:** .NET 8.0
- **Type:** ASP.NET Core Web API
- **Documentation:** Integrated OpenAPI/Swagger
- **Performance:** Concurrent and server garbage collection enabled

**Features:**

- Endpoints for generating QR codes for bookmarks, contacts, events, GiroCode, mail, and WiFi
- OpenAPI/Swagger documentation for easy integration
- Asynchronous processing for scalability

**Dependencies:**

- BB84.Extensions
- Microsoft.AspNetCore.OpenApi
- QRCoder
- Swashbuckle.AspNetCore

**Endpoints:**

- `/bookmark` - Generate bookmark QR codes
- `/contact` - Generate contact QR codes (VCard)
- `/event` - Generate event QR codes
- `/girocode` - Generate payment QR codes (GiroCode)
- `/mail` - Generate mail QR codes
- `/wifi` - Generate WiFi configuration QR codes

**Structure:**

- **Abstractions:** Interface definitions for services
- **Common:** Shared constants and endpoint definitions
- **Contracts:** Request and response models
- **Extensions:** Service registration and application configuration
- **Services:** Core QR code generation logic

---

### Development Environment 🛠️

- **Requirements:** .NET 8.0 SDK, Visual Studio 2022 or newer, Windows OS for WPF development
- **Build:** Both projects target .NET 8.0 and support documentation generation
- **Deployment:** WPF app supports single-file publishing; API is optimized for server environments

---

### Usage 🚀

- **Desktop Application:** Launch the WPF app to interactively generate and export QR codes for various scenarios.
- **Web API:** Integrate with the API by sending HTTP requests to the relevant endpoints with the required data to receive QR code images or data.

---

### Docker Container 🐳

The repository supports containerization for the QR-Code.API project, allowing you to run the Web API in a consistent and isolated environment. Using Docker, you can easily deploy the API without worrying about local dependencies or configuration.

**Key Points:**

- The API project can be built into a Docker image using a standard .NET 8 SDK base image.
- Containerization ensures portability and simplifies deployment to cloud platforms or on-premises servers.
- The container exposes the API endpoints over HTTP, making integration straightforward.

**How to Build and Run:**

1. Make sure Docker is installed on your system.
2. Build the Docker image by running:

```pwsh
docker build -t qrcode-api -f src/QR-Code.API/Dockerfile .
```

3. Start the container with:

```pwsh
docker run -d -p 8080:80 --name qrcode-api qrcode-api
```

4. Access the API at `http://localhost:8080` and use the documented endpoints.

**Notes:**

- The WPF desktop application is not intended to run in a container, as it requires a Windows graphical environment.
- The API container is suitable for automated deployments, CI/CD pipelines, and cloud hosting.

For more details on customizing the container or environment variables, refer to the Dockerfile in the directory.

---
