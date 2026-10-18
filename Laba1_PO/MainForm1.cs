using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Laba1_PO.Analyzers;
using Laba1_PO.Services;

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
        }

        // Кнопка "Анализировать".
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            string text = txtInput.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите текст для анализа.",
                    "Пустой ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = _service.AnalyzeText(text);
            foreach (var line in results)
                lstResults.Items.Add(line);
        }

        // Кнопка "Добавить LanguageDetector" — демонстрация расширяемости.
        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            // Проверяем, не добавлен ли уже.
            foreach (var a in _analyzers)
            {
                if (a is LanguageDetector)
                {
                    MessageBox.Show("LanguageDetector уже добавлен.",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Добавляем новый узел БЕЗ изменения TextAnalysisService.
            _analyzers.Add(new LanguageDetector());

            // Пересобираем сервис с новым списком.
            _service = new TextAnalysisService(_analyzers);

            MessageBox.Show(
                "LanguageDetector добавлен.\n" +
                "TextAnalysisService НЕ изменялся — только передан новый список.",
                "Расширяемость", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Сразу выполняем анализ с новым набором.
            btnAnalyze_Click(sender, e);
        }
    }
}