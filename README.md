# Порядок настрйоки и развертывания приложения
## Порядок настройки файла конфигурации (DataProcessor/App.config)
1. В случае изменений, связанных с подключением SQLite - изменить атрибут "value" тега с ключом "connectionString"
2. Ввести актуальные параметры подключения RabbitMQ. Теги с ключами:
   - hostName
   - virtualHost
   - port
   - username
   - password

## Порядок развертывания на сервере
1. Установить на сервер .NET 8.0
2. Загрузить на сервер файлы приложения в контексте директории DataProcessor/
3. Выполнить команды (в контексте DataProcessor/):
   - установка пакетов необходимых для работы приложения
   ```
   dotnet restore
   ```
   - запуск приложения
   ```
   dotnet run
   ```