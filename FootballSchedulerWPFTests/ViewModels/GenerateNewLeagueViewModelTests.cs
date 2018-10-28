using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballSchedulerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.Entity;

namespace FootballSchedulerWPF.ViewModels.Tests
{
    [TestClass()]
    public class GenerateNewLeagueViewModelTests
    {
        [TestMethod()]
        public void GenerateSchedule_DoesContextTrackChanges()
        {
            #region arrange
            GenerateNewLeagueViewModel viewModel;
            viewModel = new GenerateNewLeagueViewModel();

            String newLeagueName = "Test league";

            if (viewModel.CheckNameInput(newLeagueName))
                viewModel.NewLeagueName = newLeagueName;
            else
                Assert.Fail();

            if (!viewModel.TrySetYearInput("2019"))
                Assert.Fail();

            List<Teams> teamsForLeague = new List<Teams>();

            viewModel.ReadContext.Teams.Where(x => x.Id < 17);


            #endregion

            #region act
            #endregion

            #region assert
            #endregion
            Assert.Fail();
        }
    }
}