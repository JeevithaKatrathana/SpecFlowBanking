using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;

namespace SpecFlowBanking.FunctionLibraries
{
    public class TestContext
    {
        public string? ApplicationPath { get; set; }
        public Window? MainWindow { get; set; }
        public Application? Application { get; set; }
       // public AutomationElement? AutomationElement { get; set; }

    }
}
