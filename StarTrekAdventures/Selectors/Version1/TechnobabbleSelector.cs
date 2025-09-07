using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Helpers;
using System.Collections.Generic;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class TechnobabbleSelector
    {
        public static ActionResult<string> GenerateTechnobabble()
        {
            var retVal = string.Empty;

            retVal += GetAction();
            retVal += " the";

            if (Util.GetRandom(100) > 75)
                retVal += " " + GetDescriptor();

            if (Util.GetRandom(100) > 50)
                retVal += " " + GetSource();

            if (Util.GetRandom(100) > 25)
                retVal += " " + GetEffect();

            retVal += " " + GetDevice();

            return retVal;
        }

        public static string GetAction()
        {
            return Actions[Util.GetRandom(Actions.Count - 1)];
        }

        public static string GetDescriptor()
        {
            return Descriptors[Util.GetRandom(Descriptors.Count - 1)];
        }

        public static string GetSource()
        {
            return Sources[Util.GetRandom(Sources.Count - 1)];
        }

        public static string GetEffect()
        {
            return Effects[Util.GetRandom(Effects.Count - 1)];
        }

        public static string GetDevice()
        {
            return Devices[Util.GetRandom(Devices.Count - 1)];
        }

        private static readonly List<string> Actions = new List<string>
        {
            "refocus",
            "amplify",
            "synchronize",
            "redirect",
            "recalibrate",
            "modulate",
            "oscillate",
            "intensify",
            "nullify",
            "boost",
            "reverse",
            "reconfigure",
            "actuate",
            "focus",
            "invert",
            "reroute",
            "modify",
            "restrict",
            "reset",
            "extend",
        };

        private static readonly List<string> Descriptors = new List<string>
        {
            "microscopic",
            "macroscopic",
            "linear",
            "non-linear",
            "isometric",
            "multivariant",
            "nano",
            "phased",
            "master",
            "auxiliary",
            "primary",
            "secondary",
            "tertiary",
            "back-up",
            "polynodal",
            "multiphasic",
            "emergency",
            "tri-fold",
            "balanced",
            "oscillating",
        };

        private static readonly List<string> Sources = new List<string>
        {
            "Quantum",
            "Positronic",
            "thermionic",
            "Osmotic",
            "Neutrino",
            "spatial",
            "resonating",
            "thermal",
            "photon",
            "ionic",
            "plasma",
            "nucleonic",
            "verteron",
            "gravimetric",
            "nadion",
            "subspace",
            "baryon",
            "tetryon",
            "polaron",
            "tachyon",
        };

        private static readonly List<string> Effects = new List<string>
        {
            "flux",
            "reaction",
            "field",
            "particle",
            "gradient",
            "induction",
            "conversion",
            "polarizing",
            "displacement",
            "feed",
            "imagining",
            "reciprocating",
            "frequency",
            "pulse",
            "phased",
            "harmonic",
            "interference",
            "distortion",
            "dampening",
            "invariance",
        };

        private static readonly List<string> Devices = new List<string>
        {
            "inhibitor",
            "equalizer",
            "damper",
            "chamber",
            "catalyst",
            "coil",
            "unit",
            "grid",
            "regulator",
            "sustainer",
            "relay",
            "discriminator",
            "array",
            "coupling",
            "controller",
            "actuator",
            "harmonic",
            "generator",
            "manifold",
            "stabilizer",
        };
    }
}
