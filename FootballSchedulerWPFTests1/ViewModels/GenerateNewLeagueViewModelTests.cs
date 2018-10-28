using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballSchedulerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSchedulerWPF.ViewModels.Tests
{
    [TestClass()]
    public class GenerateNewLeagueViewModelTests
    {
        [TestMethod()]
        public void GenerateNewLeagueViewModelTest()
        {/*
            GenerateNewLeagueViewModel viewModel = new GenerateNewLeagueViewModel();
            if (viewModel.CheckNameInput(newLeagueNameTextBox.Text))
                viewModel.NewLeagueName = newLeagueNameTextBox.Text;
            else
                throw new ArgumentException();

            if (!viewModel.TrySetYearInput(newLeagueYearOfStartTextBox.Text))
                throw new ArgumentException("Year incorrect.");

            viewModel.TeamsForNewLeague = targetTeamsListBox.Items;

            bool scheduleGenerated = viewModel.GenerateSchedule();
            */
            //if (!scheduleGenerated)
                Assert.Fail();
        }
    }
}