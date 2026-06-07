using AtlusScriptHelper;
using AtlusScriptLibrary;
using AtlusScriptLibrary.Common.Text.Encodings;

namespace AtlusScriptBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AtlusScriptHelper.ScriptHelper.DecompileBFToFLOW("FIELD.BF", "FIELD.FLOW");
            //AtlusScriptHelper.ScriptHelper.CompileFLOWToBF("FIELD.FLOW", "FIELD.FLOW.BF");
            //AtlusScriptHelper.ScriptHelper.CompileMSGToBMD("FIELD.msg", "FIELD_2.bmd");
            //AtlusScriptHelper.ScriptHelper.DecompileBMDToMSG("FIELD.bmd", "field_2.msg");

            string modPath = "../../../../../p5rpc.modmenu/";
            string msgFile = modPath + "ModMenuStrings.msg";
            string fieldFlowPath = modPath + "FEmulator/BF/FIELD/ETC/FIELD.flow";
            string fieldMsgPath = fieldFlowPath.Replace(".flow", ".msg");
            string fieldBfPath = modPath + "P5REssentials/CPK/DUMMYFILES.CPK/FIELD/ETC/FIELD.BF";
            string fieldBfPathRelativeToFlow = "../../../../P5REssentials/CPK/DUMMYFILES.CPK/FIELD/ETC/FIELD.BF";

            
            // Create a copy of the Mod Menu strings file with comments removed
            ScriptHelper.RemoveMsgComments(msgFile, fieldMsgPath);

            // Remove comments from the .flow file (fixes compilation issues for older game versions)
            foreach (var script in Directory.GetFiles(modPath, "*.flow", SearchOption.AllDirectories))
                ScriptHelper.RemoveFlowComments(script);

            

            // Update the indexes of [ref] blocks and [msg] names to reflect decompiled .bf (fixes menu descriptions)
            ScriptHelper.ReindexMsgs(fieldFlowPath, fieldMsgPath, fieldBfPathRelativeToFlow);

            //ScriptHelper.RunCompiler($"-Compile \"{Path.GetFullPath(fieldFlowPath)}\" -Library P5R -Encoding P5R_EFIGS -OutFormat V3BE -Hook -SumBits -Out \"{fieldBfPath}\"");
            ScriptHelper.CompileFLOWToBF(fieldFlowPath, "FIELD.FLOW.BF");

        }
    }
}
