#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "Substring", Category = "String", Help = "Basic template with one string in/out", Tags = "")]
	#endregion PluginInfo
	public class StringSubstringNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultString = "hello c#")]
		ISpread<string> FInput;
		
		[Input("From")]
		ISpread<int> FFrom;
		
		[Input("Count", DefaultValue=1)]
		ISpread<int> FCount;

		[Output("Output")]
		ISpread<string> FOutput;

		[Import()]
		ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = SpreadMax;
			

			for (int i = 0; i < SpreadMax; i++){
				string input = FInput[i];
				string sub = input.Substring(FFrom[i], FCount[i]);
				FOutput[i] = sub;
			
			}
			

			//FLogger.Log(LogType.Debug, "Logging to Renderer (TTY)");
		}
	}
}
