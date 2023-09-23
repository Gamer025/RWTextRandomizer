using BepInEx;
using System.Diagnostics;
using System;
using System.Security.Permissions;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace TextRandomizer;

[BepInPlugin(MOD_ID, "Text Randomizer", "1.0.0")]
public class TextRandomizer : BaseUnityPlugin
{
    public const string MOD_ID = "Gamer025.TextRandomizer";
   
    public void OnEnable()
    {
        On.InGameTranslator.Translate += InGameTranslator_Translate;
    }

    private string InGameTranslator_Translate(On.InGameTranslator.orig_Translate orig, InGameTranslator self, string s)
    {
        orig(self, s);
        return self.shortStrings.ElementAt(UnityEngine.Random.Range(0, self.shortStrings.Count - 1)).Value;
    }
}