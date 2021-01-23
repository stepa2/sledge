﻿using System;
using System.Collections.Generic;

namespace Sledge.DataStructures.GameData
{
    public class Property
    {
        public string Name { get; set; }
        public VariableType VariableType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public List<Option> Options { get; set; }
        public bool ReadOnly { get; set; }
        public bool ShowInEntityReport { get; set; }

        public Property(string name, VariableType variableType)
        {
            Name = name;
            VariableType = variableType;
            Options = new List<Option>();
        }

        public string DisplayText()
        {
            return String.IsNullOrWhiteSpace(ShortDescription) ? Name : ShortDescription;
        }
    }
}
