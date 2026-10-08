using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMLight.IService;
using MVVMLight.Model;
using MVVMLight.Model.DTO;
using MVVMLigtDemo.UserControls;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVMLight.ViewModel
{
    public class UserListViewModel:ViewModelBase
    {
        private UserService userService;
        private UCPage uCPage;
        public UserListViewModel(UserService s1,UserControl u1 )
        {
            userService = s1;
            uCPage= (UCPage)u1.FindName("ucPage1");
        }
        private List<ViewUser> users;
        public List<ViewUser> Users
        {
            get {  return users; }
            set { users = value;  RaisePropertyChanged(); }
        }
        private int _userid;
        public int UserId
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
                RaisePropertyChanged();
            }
        }
        private string _account;
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
                RaisePropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _ = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand PageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    GetUsers();
                });
            }
        }
        private int totalPage;
        public int TotalPage
        {
            get
            {
                return totalPage;
            }
            set
            {
                totalPage = value;RaisePropertyChanged();
            }
        }
        public void GetUsers()
        {
            int totalCount = 0;
            var exp = Expressionable.Create<ViewUser>();
            exp.AndIF(!string.IsNullOrWhiteSpace(Account), it => it.Account.Contains(Account));
            Users = userService.GetListByPage(exp, uCPage.Page, uCPage.PageSize, ref totalCount);
            TotalPage = totalCount % uCPage.PageSize == 0 ? totalCount / uCPage.PageSize : totalCount / uCPage.PageSize + 1;
            uCPage.TotalPage = TotalPage;
        }
    }
}
