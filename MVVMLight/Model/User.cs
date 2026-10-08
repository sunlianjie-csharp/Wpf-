using GalaSoft.MvvmLight;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight.Model
{
    [SugarTable("User")]
    public class User:ObservableObject
    {
        private int _userid;
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]

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

    }
    }
