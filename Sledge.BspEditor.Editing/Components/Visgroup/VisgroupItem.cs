using System.Drawing;
using System.Windows.Forms;

namespace Sledge.BspEditor.Editing.Components.Visgroup
{
    public class VisgroupItem
    {
        public VisgroupItem Parent { get; set; }
        public string Text { get; set; }
        public CheckState CheckState { get; set; }
        public Color Color { get; set; }
        public object Tag { get; set; }
        public bool Disabled { get; set; }

        public VisgroupItem(string text)
        {
            Text = text;
            CheckState = CheckState.Checked;
            Color = Color.Transparent;
        }
    }
}