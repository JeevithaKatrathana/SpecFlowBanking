using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;

namespace SpecFlowBanking.FunctionLibraries
{
    public class FlaBaseUI
    {
        public ConditionFactory cf = new (new UIA3PropertyLibrary());
        public FlaBaseUI()
        { 
        }
    }
}
