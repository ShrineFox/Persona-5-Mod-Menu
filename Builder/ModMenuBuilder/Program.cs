using AtlusScriptHelper;

namespace ModMenuBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string modPath = "../../../../../p5rpc.modmenu/";
            string msgFile = modPath + "ModMenuStrings.msg";
            string fieldFlowPath = modPath + "FEmulator/BF/FIELD/ETC/FIELD.flow";
            string fieldMsgPath = fieldFlowPath.Replace(".flow", ".msg");
            string fieldBfPath = modPath + "P5REssentials/CPK/DUMMYFILES.CPK/FIELD/ETC/FIELD.BF";
            string fieldBfPathRelativeToFlow = "FIELD.BF";

            // Create a copy of the Mod Menu strings file with comments removed
            ScriptHelper.RemoveMsgComments(msgFile, fieldMsgPath);

            // Remove comments from the .flow file (fixes compilation issues for older game versions)
            foreach (var script in Directory.GetFiles(modPath, "*", SearchOption.AllDirectories))
                ScriptHelper.RemoveFlowComments(script);

            // Update the indexes of [ref] blocks and [msg] names to reflect decompiled .bf (fixes menu descriptions)
            ScriptHelper.ReindexMsgs(fieldFlowPath, fieldMsgPath, fieldBfPathRelativeToFlow);
            
            //ScriptHelper.RunCompiler($"-Compile \"{Path.GetFullPath(fieldFlowPath)}\" -Library P5R -Encoding P5R_EFIGS -OutFormat V3BE -Hook -SumBits -Out \"{fieldBfPath}\"");
        }
    }
}
