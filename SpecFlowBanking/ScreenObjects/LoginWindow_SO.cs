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

        readonly TestContext? _testContext;
        readonly Window? _PreviosWindow;
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
           
            get { return GetUserNameElement(); }
        }
        public FlaUI.Core.AutomationElements.AutomationElement? TxtPassword
        {
            get { return GetPasswordElement(); }
        }
          
        
        public FlaUI.Core.AutomationElements.AutomationElement? BtnLogin
        {
           
            get { return GetLoginButton();  }
        }
        
        #endregion

        public FlaUI.Core.AutomationElements.AutomationElement? GetUserNameElement()
        {
           return  _testContext!.MainWindow!.FindFirstChild(cf.ByAutomationId("usrtxt")).AsTextBox(); 
        }
        public FlaUI.Core.AutomationElements.AutomationElement? GetPasswordElement()
        {
           return  _testContext!.MainWindow!.FindFirstChild(cf.ByAutomationId("passtxt")).AsTextBox();
        }
        public FlaUI.Core.AutomationElements.AutomationElement? GetLoginButton()
        {
           return _testContext!.MainWindow!.FindFirstChild(cf.ByName("Login")).AsTextBox();
        }
        public void SetContextToMainWindow()
        {
            _testContext!.MainWindow = _PreviosWindow;
        }
    }
    
   
}
