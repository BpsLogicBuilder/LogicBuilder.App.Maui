# LogicBuilder.App.Maui

LogicBuilder.App.Maui consolidates .NET MAUI UI generation functions into a shared library (NuGet package `LogicBuilder.App.Maui`, targeting .NET 10).

It lets MAUI applications build their screens at runtime from LogicBuilder rules and screen descriptors instead of hand-written pages for each entity.

## What's included

- **Views and view factories** – code-behind pages (`DetailFormViewCS`, `EditFormViewCS`, `ListPageViewCS`, `SearchPageViewCS`, `TextPageViewCS`, child form and multi-select pages) plus the flyout/main page and busy indicator, created through factories such as `EditFormFactory`, `DetailFormFactory`, `ListPageFactory`, `SearchPageFactory`, `TextPageFactory` and `PopupFormFactory`.
- **View models** – base and concrete view models for edit, detail, list, search and text pages.
- **Validatable and read-only objects** – field types (entry, picker, multi-select, switch, checkbox, date picker, label, hidden, form, form array) with factories that create them from field descriptors.
- **Validation rules** – required, range, length, pattern, email, password, number/integer, age, "at least one required" and more, created through rule factories.
- **Directives** – `ClearIf`, `HideIf`, `ReloadIf` and `ValidateIf` conditional directives with their managers and builders, driven by LogicBuilder rules.
- **Services** – fields collection builders, collection cell builders and managers, properties and entity updaters, paging selector, HTTP and URL services, scoped flow manager, and AutoMapper services.
- **Behaviors, converters and utilities** – validation behaviors, event-to-command behavior, value converters, template selectors, layout helpers, Font Awesome constants and Polly retry helpers.

## Tests

`LogicBuilder.App.Maui.Test` is an xUnit project that covers:

- fields collection builders (edit, update-only and read-only)
- collection cell items builders and managers
- properties and entity updaters, and entity state updaters
- AutoMapper profiles
- dependency resolution (DI registrations)
- dictionary comparison
- command button and list form settings
- screen descriptors for list, search, text and read-only forms

It uses mocks for the HTTP service, rules cache and app logger. The `Contoso.Data` and `Contoso.Domain` projects provide sample entities for the tests.

## Usage

Reference the `LogicBuilder.App.Maui` package from a .NET MAUI app, register its services with dependency injection, and supply screen descriptors and rules to generate the UI.

## License

MIT