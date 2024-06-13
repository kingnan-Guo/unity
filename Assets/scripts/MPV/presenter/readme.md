PureMVC 框架 使用


[PureMVC 框架](https://puremvc.org/docs/PureMVC_IIBP_Chinese.pdf)


数据代理 存入到 对象中



==============

### 1. 创建一个MVC框架

```csharp
// 创建一个MVC框架
var app = new PureMVC.Patterns.Facade();
```

### 2. 创建一个Model

```csharp
// 创建一个Model
var model = new PureMVC.Patterns.Model();
```

### 3. 创建一个View

```csharp
// 创建一个View



var view = new PureMVC.Patterns.View();
```

### 4. 创建一个Controller

```csharp
// 创建一个Controller
var controller = new PureMVC.Patterns.Controller();
```

### 5. 注册Model, View, Controller

```csharp
// 注册Model, View, Controller
app.RegisterProxy(model);
app.RegisterMediator(view);
app.RegisterCommand(controller);
```
    
`