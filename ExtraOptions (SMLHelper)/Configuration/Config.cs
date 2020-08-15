using SMLHelper.V2.Json;

namespace ExtraOptions.Configuration
{
    public class Config : ConfigFile
    {
        public float Murkiness = 100.0f;
        public int TextureQuality = 3;
        public bool Console = false;
        public bool LightShafts = true;
        public bool VariablePhysicsStep = true;
        public bool FogFix = false;
    }
}