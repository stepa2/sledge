using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using Sledge.Common.Shell.Settings;
using Sledge.Rendering.Cameras;
using Sledge.Rendering.Engine;

namespace Sledge.BspEditor.Rendering
{
    /// <summary>
    /// Bootstraps a renderer instance
    /// </summary>
    [Export(typeof(ISettingsContainer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Renderer : ISettingsContainer
    {
        [Import] private Lazy<EngineInterface> _engine;

        // Renderer settings
        [Setting] public static Color PerspectiveBackgroundColor { get; set; } = Color.Black;
        [Setting] public static Color OrthographicBackgroundColor { get; set; } = Color.Black;

        [Setting] public static Color FractionalGridLineColor { get; set; } = Color.FromArgb(32, 32, 32);
        [Setting] public static Color StandardGridLineColor { get; set; } = Color.FromArgb(75, 75, 75);
        [Setting] public static Color PrimaryGridLineColor { get; set; } = Color.FromArgb(115, 115, 115);
        [Setting] public static Color SecondaryGridLineColor { get; set; } = Color.FromArgb(100, 46, 0);
        [Setting] public static Color AxisGridLineColor { get; set; } = Color.FromArgb(0, 100, 100);
        [Setting] public static Color BoundaryGridLineColor { get; set; } = Color.Red;

        // Settings container

        public string Name => "Sledge.BspEditor.Rendering.Renderer";

        public IEnumerable<SettingKey> GetKeys()
        {
            yield return new SettingKey("Rendering", "PerspectiveBackgroundColor", typeof(Color));
            yield return new SettingKey("Rendering", "OrthographicBackgroundColor", typeof(Color));

            yield return new SettingKey("Rendering/Grid", "FractionalGridLineColor", typeof(Color));
            yield return new SettingKey("Rendering/Grid", "StandardGridLineColor", typeof(Color));
            yield return new SettingKey("Rendering/Grid", "PrimaryGridLineColor", typeof(Color));
            yield return new SettingKey("Rendering/Grid", "SecondaryGridLineColor", typeof(Color));
            yield return new SettingKey("Rendering/Grid", "AxisGridLineColor", typeof(Color));
            yield return new SettingKey("Rendering/Grid", "BoundaryGridLineColor", typeof(Color));
        }

        public void LoadValues(ISettingsStore store)
        {
            store.LoadInstance(this);
            _engine.Value.SetClearColor(CameraType.Perspective, PerspectiveBackgroundColor);
            _engine.Value.SetClearColor(CameraType.Orthographic, OrthographicBackgroundColor);
        }

        public void StoreValues(ISettingsStore store)
        {
            store.StoreInstance(this);
        }
    }
}
