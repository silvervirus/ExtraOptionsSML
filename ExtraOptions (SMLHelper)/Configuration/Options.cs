using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace ExtraOptions.Configuration
{
    public class Options : ModOptions
    {
        private readonly Config config = Main.config;

        public Options() : base("ExtraOptions")
        {
            config.Load();
            SliderChanged += ExtraOptions_SliderChanged;
            ChoiceChanged += ExtraOptions_ChoiceChanged;
            ToggleChanged += ExtraOptions_ToggleChanged;
        }

        public override void BuildModOptions()
        {
            AddSliderOption("ExtraOptions_Murkiness", "Murkiness",  0, 200, config.Murkiness, 100);
            AddChoiceOption("ExtraOptions_TextureQuality", "Texture Quality", new string[] { "0", "1", "2", "3", "4" }, config.TextureQuality);
            AddToggleOption("ExtraOptions_LightShaft", "LightShaft", config.LightShafts);
            AddToggleOption("ExtraOptions_VPS", "Variable Physics Step", config.VariablePhysicsStep);
            AddToggleOption("ExtraOptions_FF", "Fog \"Fix\"", config.FogFix);
        }

        public void ExtraOptions_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (!e.Id.Contains("ExtraOptions_")) return;

            string id = e.Id.Replace("ExtraOptions_", "");
            switch (id)
            {
                case "Murkiness":
                    config.Murkiness = e.IntegerValue;
                    config.Save();
                    Main.ApplyOptions();
                    break;
            }
        }

        private void ExtraOptions_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            if (!e.Id.Contains("ExtraOptions_"))
                return;

            string id = e.Id.Replace("ExtraOptions_", "");
            switch (id)
            {
                case "LightShaft":
                    config.LightShafts = e.Value;
                    config.Save();
                    Main.ApplyOptions();
                    break;
                case "VPS":
                    config.VariablePhysicsStep = e.Value;
                    config.Save();
                    Main.ApplyOptions();
                    break;
                case "FF":
                    config.FogFix = e.Value;
                    config.Save();
                    Main.ApplyOptions();
                    break;
            }
        }

        private void ExtraOptions_ChoiceChanged(object sender, ChoiceChangedEventArgs e)
        {
            if (!e.Id.Contains("ExtraOptions_"))
                return;

            string id = e.Id.Replace("ExtraOptions_", "");
            switch (id)
            {
                case "TextureQuality":
                    config.TextureQuality = e.Index;
                    config.Save();
                    Main.ApplyOptions();
                    break;
            }
        }
    }
}
