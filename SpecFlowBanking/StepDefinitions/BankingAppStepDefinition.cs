using FlaUI.Core.Conditions;
using FlaUI.Core;
using FlaUI.UIA3;
using FlaUI.Core.AutomationElements;
using System.Diagnostics;
using TechTalk.SpecFlow;
using SpecFlowBanking.FunctionLibraries;
using TechTalk.SpecFlow.Assist;
using SpecFlowBanking.ScreenObjects;
using SpecFlowBanking.Utilities;
using System.Collections;



namespace SpecFlowBanking.StepDefinitions
{
    [Binding]
    public sealed class BankingAppStepDefinition
    {

        TestContext? _testContext;
        ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        LoginWindow_SO? _objLogin;
        DBFunctions? _dBFunctions;
        public BankingAppStepDefinition(TestContext testContext, LoginWindow_SO objLogin, DBFunctions dBFunctions)
        {
            _testContext = testContext;
            _objLogin = objLogin;
            _dBFunctions = dBFunctions;
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        [Given(@"Launch Banking Application")]
        public void GivenLaunchBankingApplication()
        {
            _testContext!.ApplicationPath = @"C:\Users\jeevitha_j\Downloads\BankingApplication\BankingApplication\bin\Debug\BankingApplication";
            LaunchOrAttach_Application(_testContext!.ApplicationPath, "BankingApplication");
           
        }
        public void LaunchOrAttach_Application(string applicationPath, string processname)
        {

            var process = System.Diagnostics.Process.GetProcessesByName(processname).FirstOrDefault();
            if (process != null)
            {
                var application = Application.Attach(process);
                _testContext!.MainWindow = application.GetMainWindow(new UIA3Automation());
                Console.WriteLine("Application already open.");
            }
            else
            {
                var processStartInfo = new ProcessStartInfo(applicationPath);
                //_testContext.application = Application.AttachOrLaunch(processStartInfo);
                _testContext!.Application = Application.Launch(processStartInfo);
                _testContext.MainWindow = _testContext.Application.GetMainWindow(new UIA3Automation());
                Console.WriteLine("Launch Application!");
            }

        }

        [When(@"User Enters Valid UserName ,Password and clicks Login button")]
        public void WhenUserEntersValidUserNamePasswordAndClicksLoginButton(Table table)
        {
            var tablecontent = table.CreateSet<TestdataTable>();

            /*_objLogin!.getUserNameElement();
            _objLogin!.getPasswordElement();
             _objLogin.getLoginButton();*/

            foreach (var item in tablecontent)
            {
                // item.UserName;
                _objLogin!.TxtUserName.AsTextBox().Enter(item.UserName);
                _objLogin!.TxtPassword.AsTextBox().Enter(item.Password);
                _objLogin!.BtnLogin.AsButton().Click();
                            
            }

           }
        public record TestdataTable //using record type .
        {
            public string? UserName { set; get; }
            public string? Password { set; get; }
            
            public string? TestdataName { set; get; }

        }
        
        [Then(@"User is on the HomePage")]
        public void ThenUserIsOnTheHomePage()
        {
           
        }

        [Given(@"Find a CSV file")]
        public void GivenFindACSVFile()
        {
            Console.WriteLine("not ready");
        }

        [When(@"Read Data from CSV to arraylist")]
        public void WhenReadDataFromCSVToArraylist()
        {
            string filePath = "C:\\Users\\jeevitha_j\\Documents\\customers-09.txt";
            _dBFunctions!.ReadCSVDataIntoDataTable(filePath);
        }
        [Given(@"Find a txt file")]
        public void GivenFindATxtFile()
        {
           
        }

        [When(@"Read Data from txt")]
        public void WhenReadDataFromTxt()
        {
          
        }

        [Given(@"A arraylist and a list")]
        public void GivenAArraylistAndAList()
        {
           
        }

        [When(@"compare arraylist and list")]
        public void WhenCompareArraylistAndList()
        {
            //both are dynamically sized
            var arraylist = new ArrayList(); //not type specific
            var list = new List<int>(); //type specific

            //add elements
            arraylist.Add(1);
            arraylist.Add("Hello");
            list.Add(1);
            list.Add(2);
            // list.Add("Hello"); //does not allow cant add a type of string, throws compiler error

            //display elements : no difference
            Console.WriteLine("arraylist after adding 2 elements");
            displayArraylistElements(arraylist);
            Console.WriteLine("List after adding 2 elements");
            displayListElements(list);

            //remove elements : removes first occurance if 1
            arraylist.Remove(1);
            list.Remove(1);
            Console.WriteLine("arraylist after removing item with value 1");
            displayArraylistElements(arraylist);
            Console.WriteLine("list after removing item with value 1");
            displayListElements(list);


        }
        public void displayArraylistElements(ArrayList arraylist)
        {
            foreach (var item in arraylist)
                Console.WriteLine(item);
        }
        public void displayListElements(List<int> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
