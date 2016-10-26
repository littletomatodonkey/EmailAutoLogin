using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAutoLogin
{
    class AccountInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _account;

        private string _passwd;

        private EmailType _type;

        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get
            {
                return this._account;
            }
            set
            {
                this._account = value;
                OnPropertyChanged("Account");
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Passwd
        {
            get
            {
                return this._passwd;
            }
            set
            {
                this._passwd = value;
                OnPropertyChanged("Passwd");
            }
        }

        public EmailType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                OnPropertyChanged("Type");
            }
        }

        public AccountInfo( string acc, string pwd, EmailType type )
        {
            this._account = acc;
            this._passwd = pwd;
            this._type = type;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    enum EmailType
    {
        TYPE_163 = 0,
        TYPE_126 = 1,
        TYPE_QQ  = 2,
    }
}
