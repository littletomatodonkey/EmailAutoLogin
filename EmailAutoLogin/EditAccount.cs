using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailAutoLogin
{
    public partial class EditAccount : Form
    {
        public delegate void DelegateAccounce(string account, string passwd, int type);

        public DelegateAccounce AnnounceHandler;

        /// <summary>
        /// 邮箱帐号信息
        /// </summary>
        private string _account;

        /// <summary>
        /// 邮箱密码
        /// </summary>
        private string _passwd;

        /// <summary>
        /// 邮箱类型
        /// </summary>
        private int _type;

        /// <summary>
        /// 本次编辑是否为添加新的AccountInfo类
        /// </summary>
        public bool _isAdd;


        public EditAccount(string account, string passwd, int type, bool isAdd)
        {
            InitializeComponent();
            this._account = account;
            this._passwd = passwd;
            this._type = type;
            this._isAdd = isAdd;
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            cbType.DataSource = GlobalSettings.EmailAddressTypeStr;
            cbType.SelectedIndex = _type;

            tbAccount.Text = _account;
            tbPasswd.Text = _passwd;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(GetAllInputValue())
            {
                AnnounceHandler(_account, _passwd, _type);
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 将文本框内的值赋值给变量
        /// 加上返回值，方便之后的扩展，比如对邮箱的验证等
        /// </summary>
        /// <returns></returns>
        private bool GetAllInputValue()
        {
            bool res = true;

            _account = tbAccount.Text;
            _passwd = tbPasswd.Text;
            _type = cbType.SelectedIndex;

            return res;
        }

        
    }
}
