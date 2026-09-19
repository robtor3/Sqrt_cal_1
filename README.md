# 📐 Sqrt_cal_1 — Калькулятор корней

![.NET](https://img.shields.io/badge/.NET-10.0-blueviolet)
![MAUI](https://img.shields.io/badge/.NET_MAUI-10.0-blue)
![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20Windows%20%7C%20macOS-lightgrey)

**Sqrt_cal_1** — это учебное кроссплатформенное приложение на .NET MAUI, предназначенное для вычисления корней любой степени,
включая работу с комплексными числами.

## 📱 Скриншоты

Вычисление действительных корней

<img width="1422" height="812" alt="{A877B82B-A566-4AAC-91DF-07451BBDDF68}" src="https://github.com/user-attachments/assets/05100597-9624-4ef3-a324-123e08a9036c" />

Вычисление комплексных корней

<img width="1424" height="814" alt="{62D60C55-3848-421A-B1FE-F39264C03EFE}" src="https://github.com/user-attachments/assets/b522b7f6-e5a4-406b-aad1-7f6a11fd4d52" />

Настройки

<img width="1424" height="815" alt="{1A4465C2-999A-4709-99C3-12B5396328D9}" src="https://github.com/user-attachments/assets/f7adf13e-96eb-4fd7-b2ea-6c5158f747dd" />

## ✨ Возможности

- 🔢 **Вычисление корня любой степени:** Поддержка n-й степени для действительных чисел.
- 🧮 **Комплексные числа:** Полноценная поддержка вычисления корней из комплексных чисел.
- 🌍 **Локализация:** Поддержка русского и английского языков (реализована через `LocalizationManager`).
- ⚙️ **Настройки:** Экран настроек для управления точностью вычислений и смены языка.
- 📱 **Кроссплатформенность:** Работает на Android, Windows.
- 🏗 **Архитектура MVVM:** Чистое разделение логики, представления и данных

## 🏗 Архитектура

Приложение построено на паттерне **MVVM (Model-View-ViewModel) (вместе с фреймворком CommunityToolkit.Mvvm)**:
- **View:** XAML-страницы (`MainPage`, `SecondPage`, `SettingsPage`), отвечающие за отображение.
- **ViewModel:** Логика представления (`MainViewModel`, `SecondViewModel`, `SettingsModel`), привязка данных, команды и логика вычислений.
- **Resources:** Стили, шрифты и изображения.

## 🚀 Установка и запуск

1. **Клонируйте репозиторий:**
   ```bash
   git clone https://github.com/[ваш_username]/Sqrt_cal_1.git
   cd Sqrt_cal_1
   ```

2. **Восстановите зависимости:**
   ```bash
   dotnet restore
   ```

3. **Запустите приложение под нужную платформу:**

   **Windows:**
   ```powershell
   dotnet build -t:Run -f net8.0-windows10.0.19041.0
   ```

   **Android:**
   ```bash
   dotnet build -t:Run -f net8.0-android
   ```

