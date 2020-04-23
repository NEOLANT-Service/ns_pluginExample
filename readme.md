# Пример приложения, которое можно встроить в вид Внешний контент НЕОСИНТЕЗ

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

При запуске из IDE используется appsettings.Development.json
При хостинге - appsettings.json

## Deploy Windows, IIS

Установить на Windows Server 2012 и выше
- IIS 
- Microsoft .NET Core Runtime - 2.2.1 (x86)
- Microsoft .NET Core Runtime - 2.2.1 (x64)
- Microsoft .NET Core 2.2.1 - Windows Server Hosting

Создать пустой сайт и пул для него. Остановить сайт и пул.
В папке сайта разместить собранное в release приложение. Настроить appsettings.json таким образом, чтобы он ссылался на доступный из места расположения приложения экземпляр НЕОСИНТЕЗ.
У пользователя, от имени которого запускается пул приложения (по умолчанию одноименный с пулом) должны быть полные права на папку сайта. Добавить необходимые права можно скриптом cmd от имени Администратора

icacls "{Полный путь к папке/сайту}" /grant "IIS APPPOOL\\{userName}":(OI)(CI)(R,W)

Запустить сайт и пул. Приложение будет доступно по привязке, указанной для сайта.
Чтобы использовать приложение как плагин для НЕОСИНТЕЗ, нужно прописать url, с необходимым интерфейсом приложения в настройки вида Внешний контент НЕОСИНТЕЗ.
