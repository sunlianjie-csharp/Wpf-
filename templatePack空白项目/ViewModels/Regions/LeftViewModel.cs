using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace templatePack空白项目.ViewModels.Regions
{
    public class LeftViewModel : BindableBase
    {
        private IRegionManager _i1;
        public LeftViewModel(IRegionManager r1)

        {
            _i1 = r1;
        }

        public DelegateCommand<string> Move
        {
            get
            {
                return new DelegateCommand<string>((obj) =>
                {
                    _i1.Regions["ContentRegion"].RequestNavigate(obj);
                });
            }
        }
    }
}

