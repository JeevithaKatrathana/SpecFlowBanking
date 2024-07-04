using FlaUI.Core.AutomationElements;
using SpecFlowBanking.FunctionLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace SpecFlowBanking.ScreenObjects
{
    [Binding]
    public class LoginWindow_SO : FlaBaseUI
    {
       
        TestContext? _testContext;
        Window? _PreviosWindow;
       // public FlaUI.Core.AutomationElements.AutomationElement? TxtUserName, txtPassword, btnLogin;

        public LoginWindow_SO(TestContext testContext)
        {
            _testContext = testContext;
            _PreviosWindow = _testContext!.MainWindow!;
          //  _testContext!.MainWindow =  _testContext!.MainWindow!.FindFirstDescendant(cf.ByName("Login page")).AsWindow();

        }
        #region getter setter
        public FlaUI.Core.AutomationElements.AutomationElement? TxtUserName
        {
            set { }
            get { return getUserNameElement(); }
        }
        public FlaUI.Core.AutomationElements.AutomationElement? TxtPassword
        {
            set { }
            get { return getPasswordElement(); }
        }
        public FlaUI.Core.AutomationElements.AutomationElement? BtnLogin
        {
            set {  }
            get { return getLoginButton();  }
        }
        #endregion

        public FlaUI.Core.AutomationElements.AutomationElement? getUserNameElement()
        {
           return  _testContext!.MainWindow!.FindFirstChild(cf.ByAutomationId("usrtxt")).AsTextBox(); 
        }
        public FlaUI.Core.AutomationElements.AutomationElement? getPasswordElement()
        {
           return  _testContext!.MainWindow!.FindFirstChild(cf.ByAutomationId("passtxt")).AsTextBox();
        }
        public FlaUI.Core.AutomationElements.AutomationElement? getLoginButton()
        {
           return _testContext!.MainWindow!.FindFirstChild(cf.ByName("Login")).AsTextBox();
        }
        public void setContextToMainWindow()
        {
            _testContext!.MainWindow = _PreviosWindow;
        }
    }
    
   
}
