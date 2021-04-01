using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _006_Models.ViewModels
{
    public class GamesViewModel
    {
        public IEnumerable<Models._004_ViewModel.PcGame> pcGames;
        public IEnumerable<Models._004_ViewModel.XboxGame> xboxGames;
    }
}
