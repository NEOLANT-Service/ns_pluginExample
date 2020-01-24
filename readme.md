# Пример внешнего вида для объекта НЕОСИНТЕЗ

## Средства разработки
- Microsoft Visual Studio 2017 и выше
- Visual Studio Code

## Особенности

  - Язык разработки backend - c# (.NET Core 2.2)
  - Язык разработки frontend - TypeScript ([Angular](https://angular.io/))
  - CSS Framework [Angular Material](https://material.angular.io/)
  - СУБД - MS SQL (не обязательно)

## Техническое описание
| Сборка | Назначение  | Описание  |
|--|--|--|
| NsPluginExample |Web приложение  | |
| NsPluginExample.Domain.Contracts | Контракты бизнес-логики приложения |  |
| NsPluginExample.Domain.Models | Бизнес-модели приложения |  |
| NsPluginExample.DAL | Слой доступа к БД |  |
| NsPluginExample.Application| Реализация бизнес-логики приложения|
| NsApiClient| Клиент доступа к НЕОСИНТЕЗ||
| NsApiModels| Модели API НЕОСИНТЕЗ||
| NsPluginExample/frontend/angular| Web клиент Angular 8.0 | ||


## Сборка Web клиента

- Установить [Node.js](https://nodejs.org/ "Node.js")

```
cd .\NsPluginExample\frontend\angular\my-app
npm install
npm run build
```

## Сборка и запус Web приложения

- Установить [.NET Core](https://www.microsoft.com/net/download ".NET Core")
```
dotnet restore NsPluginExample
dotnet build NsPluginExample
dotnet NsPluginExample
```

## Сборка и запуск приложения в IDE 

Приложение разделено на две части (backend и frontend).  
Backend запускается в MS VS как любое другое .NET Core приложение.  
Frontend запускается командой 
```
npm run start
```
