﻿using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MultiWindowTextEditor
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        // Метод відкриття файлу
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створення діалогового вікна відкриття файлу
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Завантаження файлу у різному форматі залежно від розширення
                if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        // Метод збереження файлу
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створення діалогового вікна збереження файлу
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Збереження файлу у різному форматі залежно від розширення
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        // Метод створення нового вікна
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditorForm newForm = new TextEditorForm();
            newForm.Show();
        }

        // Метод вихід з програми
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Метод зміни шрифту тексту
        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        // Метод вирівнювання тексту ліворуч
        private void alignLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        // Метод вирівнювання тексту по центру
        private void alignCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        // Метод вирівнювання тексту праворуч
        private void alignRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        // Метод вставки зображення
        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetImage(Image.FromFile(openFileDialog.FileName));
                richTextBox1.Paste();
            }
        }

        // Метод виділення синтаксичних ключових слів
        private void syntaxHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax();
        }

        // Метод виділення синтаксичних ключових слів у тексті
        private void HighlightSyntax()
        {
            string[] keywords = { "int", "string", "float", "if", "else", "for", "while" };
            string pattern = @"\b(" + string.Join("|", keywords) + @")\b";

            MatchCollection matches = Regex.Matches(richTextBox1.Text, pattern);

            int originalIndex = richTextBox1.SelectionStart;
            int originalLength = richTextBox1.SelectionLength;
            Color originalColor = Color.Black;

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = originalColor;

            foreach (Match match in matches)
            {
                richTextBox1.Select(match.Index, match.Length);
                richTextBox1.SelectionColor = Color.Blue;
            }

            richTextBox1.SelectionStart = originalIndex;
            richTextBox1.SelectionLength = originalLength;
            richTextBox1.SelectionColor = originalColor;
        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
