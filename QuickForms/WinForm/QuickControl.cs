﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using QuickForms.Core;
using QuickForms.Wpf;

namespace QuickForms.WinForm
{
    public class QuickControl : Panel, IQuickUI
    {
        private readonly Wpf.QuickControl _quickControlWpf;

        public QuickControl()
        {
            _quickControlWpf = new Wpf.QuickControl();

            Controls.Add(new ElementHost
            {
                Child = _quickControlWpf,
                Dock = DockStyle.Fill
            });
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new double Padding
        {
            get => _quickControlWpf.Padding;
            set => _quickControlWpf.Padding = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QuickOptions Options
        {
            get => _quickControlWpf.Options;
            set => _quickControlWpf.Options = value;
        }

        public Parameter<bool> AddCheckBox(string? label = null, Action<bool>? function = null)
        {
            return _quickControlWpf.AddCheckBox(label, function);
        }

        public Parameter<string> AddTextBox(string? label = null, Action<string>? function = null)
        {
            return _quickControlWpf.AddTextBox(label, function);
        }

        public Parameter<double> AddTrackBar(string? label, double min, double max, double? step = null,
            Action<double>? function = null)
        {
            return _quickControlWpf.AddTrackBar(label, min, max, step, function);
        }

        public Parameter<T> AddComboBox<T>(string? label, IEnumerable<T> values, Action<T>? function = null)
        {
            return _quickControlWpf.AddComboBox(label, values, function);
        }

        public void AddButton(string? text, Action function)
        {
            _quickControlWpf.AddButton(text, function);
        }

        public IQuickUI AddCategory(string? title = null)
        {
            return _quickControlWpf.AddCategory(title);
        }

        public Parameter<Color> AddColorPicker(string? label = null, Color? color = null, Action<Color>? function = null)
        {
            return _quickControlWpf.AddColorPicker(label, color, function);
        }

        public IQuickUI[] Split(int n = 2)
        {
            return _quickControlWpf.Split(n);
        }

        public void Clear()
        {
            _quickControlWpf.Clear();
        }

        public void SetTheme(Themes theme)
        {
            _quickControlWpf.SetTheme(theme);
        }
    }
}
