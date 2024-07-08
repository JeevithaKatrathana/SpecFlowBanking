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
//using NUnit.Framework;



namespace SpecFlowBanking.StepDefinitions
{
    [Binding]
    public sealed class BankingAppStepDefinition
    {

        readonly TestContext? _testContext;
        // ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        readonly LoginWindow_SO? _objLogin;
       readonly DBFunctions?  _dBFunctions;
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
           // _testContext!.ApplicationPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")!.FullName + "\\TestDataFiles\\customers-09.txt";
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
                NUnit.Framework.Assert.AreEqual(item.UserName, _objLogin!.TxtUserName.AsTextBox().Text, " User name not entered as expected");
               
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
        
       


        [When(@"Read Data from CSV to arraylist")]
        public void WhenReadDataFromCSVToArraylist()
        {
            string? filePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")!.FullName + "\\TestDataFiles\\customers-09.txt";
           // string filePath = "C:\\Users\\jeevitha_j\\Documents\\customers-09.txt";
            _dBFunctions!.ReadCSVDataIntoDataTable(filePath);
        }
        
        [When(@"compare arraylist and list")]
        public static void WhenCompareArraylistAndList()
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
            DisplayArraylistElements(arraylist);
            Console.WriteLine("List after adding 2 elements");
            DisplayListElements(list);

            //remove elements : removes first occurance if 1
            arraylist.Remove(1);
            list.Remove(1);
            Console.WriteLine("arraylist after removing item with value 1");
            DisplayArraylistElements(arraylist);
            Console.WriteLine("list after removing item with value 1");
            DisplayListElements(list);


        }
        public static void DisplayArraylistElements(ArrayList arraylist)
        {
            foreach (var item in arraylist)
                Console.WriteLine(item);
        }
        public static  void DisplayListElements(List<int> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);
        }

        [Given(@"Find a CSV file")]
        public void GivenFindACSVFile()
        {
            Console.WriteLine("GivenFindACSVFile");
        }

        [Given(@"Find a txt file")]
        public void GivenFindATxtFile()
        {
            Console.WriteLine("GivenFindATxtFile");
        }

        [When(@"Read Data from txt")]
        public void WhenReadDataFromTxt()
        {
            Console.WriteLine("WhenReadDataFromTxt");
        }

        [Given(@"A arraylist and a list")]
        public void GivenAArraylistAndAList()
        {
            Console.WriteLine("GivenAArraylistAndAList");
        }

    }
}
