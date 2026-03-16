Ecommerce.Admin
│
├── Ecommerce.Admin.Web
│   ├── Controllers
│   │   ├── ProductController.cs
│   │   └── CategoryController.cs
│   │
│   ├── Views
│   │   ├── Shared
│   │   │   └── _Layout.cshtml
│   │   │
│   │   ├── Product
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   └── Details.cshtml
│   │   │
│   │   └── Category
│   │       ├── Index.cshtml
│   │       ├── Create.cshtml
│   │       └── Edit.cshtml
│   │
│   ├── Program.cs
│   └── appsettings.json
│
├── Ecommerce.Application
│   ├── Interfaces
│   │   └── IRepository.cs
│   │
│   └── Services
│       ├── ProductService.cs
│       └── CategoryService.cs
│
├── Ecommerce.Domain
│   ├── Common
│   │   └── BaseEntity.cs
│   │
│   └── Entities
│       ├── Product.cs
│       └── Category.cs
│
├── Ecommerce.Infrastructure
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   └── Repositories
│       └── Repository.cs
│
└── Ecommerce.CrossCutting
    └── Middleware
        └── GlobalExceptionMiddleware.cs