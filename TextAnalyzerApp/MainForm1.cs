using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Laba1_PO.Analyzers;
using Laba1_PO.Services;
using Newtonsoft.Json;
using Serilog;

namespace Laba1_PO
{
    public partial class MainForm1 : Form
    {
        // Храним текущий список анализаторов и сервис.
        private List<ITextAnalyzer> _analyzers;
        private TextAnalysisService _service;

        public MainForm1()
        {
            InitializeComponent();

            // 1. Создаём узлы сети (три обязательных анализатора).
            _analyzers = new List<ITextAnalyzer>();
            _analyzers.Add(new WordCounter());
            _analyzers.Add(new SentimentAnalyzer());
            _analyzers.Add(new KeywordExtractor());

            // 2. Формируем сеть: передаём узлы в основной модуль.
            _service = new TextAnalysisService(_analyzers);

            // 3. Логируем запуск и сохраняем список анализаторов в JSON.
            Log.Information("MainForm1 инициализирована. Анализаторов: {Count}", _analyzers.Count);
            SaveAnalyzersToJson();
        }

        // Кнопка "Анализировать".
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            string text = txtInput.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                // Было: MessageBox.Show("Введите текст для анализа.", ...)
                Log.Warning("Попытка анализа с пустым вводом");
                MessageBox.Show("Введите текст для анализа.",
                    "Пустой ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Log.Information("Запуск анализа. Длина текста: {Length} символов", text.Length);

            var results = _service.AnalyzeText(text);
            foreach (var line in results)
            {
                lstResults.Items.Add(line);
                // Было: Console.WriteLine(...) — теперь Log.Information
                Log.Information("Результат анализа: {Result}", line);
            }

            Log.Information("Анализ завершён. Обработано анализаторов: {Count}", results.Count);
        }

        // Кнопка "Добавить LanguageDetector" — демонстрация расширяемости.
        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            // Проверяем, не добавлен ли уже.
            foreach (var a in _analyzers)
            {
                if (a is LanguageDetector)
                {
                    Log.Information("Попытка повторно добавить LanguageDetector — отменено");
                    MessageBox.Show("LanguageDetector уже добавлен.",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Добавляем новый узел БЕЗ изменения TextAnalysisService.
            _analyzers.Add(new LanguageDetector());

            // Пересобираем сервис с новым списком.
            _service = new TextAnalysisService(_analyzers);

            Log.Information("LanguageDetector добавлен. Всего анализаторов: {Count}", _analyzers.Count);

            MessageBox.Show(
                "LanguageDetector добавлен.\n" +
                "TextAnalysisService НЕ изменялся — только передан новый список.",
                "Расширяемость", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Сохраняем обновлённый список в JSON.
            SaveAnalyzersToJson();

            // Сразу выполняем анализ с новым набором.
            btnAnalyze_Click(sender, e);
        }

        // Сохранение списка анализаторов в JSON через Newtonsoft.Json.
        private void SaveAnalyzersToJson()
        {
            try
            {
                // Собираем имена анализаторов
                var analyzerNames = _analyzers.Select(a => a.Name).ToList();

                // Сериализуем в JSON с отступами
                string json = JsonConvert.SerializeObject(analyzerNames, Formatting.Indented);

                // Сохраняем в файл в папке приложения
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "analyzers.json");
                File.WriteAllText(path, json);

                Log.Information("Список анализаторов сохранён в analyzers.json (путь: {Path})", path);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при сохранении analyzers.json");
            }
        }
    }
}