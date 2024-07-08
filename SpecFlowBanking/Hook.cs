using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using SpecFlowBanking.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBanking
{
    [Binding]
    class Hook : TechTalk.SpecFlow.Steps
    {
        private static ExtentTest? featureName;
     
        private static ExtentTest? scenario;
        private static ExtentReports? extent;
        readonly static OneTimeIntialize? oneTimeInitialize = OneTimeIntialize.GetInstance();


        [BeforeTestRun]
        public static void InitializeReport()
        {
             extent = oneTimeInitialize!.GetExtentReport();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent!.CreateTest(featurecontext.FeatureInfo.Title);
        }
        
        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext sc)
        {
           // Console.WriteLine("BeforeScenario");
            scenario = featureName!.CreateNode<Scenario>(sc.ScenarioInfo.Title);
        }
        
        [AfterStep]
        public  void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
          
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario!.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario!.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario!.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario!.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    scenario!.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    scenario!.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    scenario!.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    scenario!.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
        
       

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent!.Flush();
          
        }
    }
}
