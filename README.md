# WT-5 Razor Pages

Лабораторная работа WT-5: ASP.NET Core Razor Pages, предметная область «Банковская система».

## Возможности

- общая коллекция счетов в `Data/AccountStore.cs`;
- Razor Pages и PageModel;
- `OnGet()` и `OnPost()`;
- список счетов, Details, Create, Edit и Delete;
- `[BindProperty]`, валидация и Razor Tag Helpers;
- Bootstrap и адаптивный интерфейс;
- Dockerfile и подготовка к Render.

## Основные страницы

- `/` — главная;
- `/Accounts/Index` — список счетов;
- `/Accounts/Create` — создание;
- `/Accounts/Details?id=1` — подробности;
- `/Accounts/Edit?id=1` — редактирование;
- `/Accounts/Delete?id=1` — удаление.

## Локальный запуск

```bash
dotnet run
```

## Docker

```bash
docker build -t wt-lab5 .
docker run --rm -p 10000:10000 wt-lab5
```

После запуска открыть `http://localhost:10000`.

## Репозиторий

https://github.com/mizantropiya/wt-lab5-5razor-shilets

## Опубликованное приложение

https://ТВОЙ-АДРЕС.onrender.com
