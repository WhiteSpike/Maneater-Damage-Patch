using HarmonyLib;
using ManeaterDamagePatch.Util;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ManeaterDamagePatch.Patches
{
    [HarmonyPatch(typeof(CaveDwellerAI))]
    internal static class CaveDwellerAIPatcher
    {
        [HarmonyPatch(nameof(CaveDwellerAI.HitEnemy))]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> HitEnemyTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new(instructions);
            int index = 0;
            Tools.FindInteger(ref index, ref codes, findValue: 1, skip: true);
            codes[index - 1] = new CodeInstruction(opcode: OpCodes.Ldarg_1);
            return codes;
        }
    }
}
