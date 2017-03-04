using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace EmailAutoLogin
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 所有账号
        /// </summary>
        private BindingList<AccountInfo> accounts;

        private const int hotKeyID = 100;

        public Form1()
        {
            InitializeComponent();

            if( !Directory.Exists( GlobalSettings.JsonDir ) )
            {
                Directory.CreateDirectory(GlobalSettings.JsonDir);
            }

            try
            {
                using (StreamReader sr = new StreamReader(GlobalSettings.JsonDir + GlobalSettings.JsonFileName))
                {
                    accounts = new BindingList<AccountInfo>();
                    string str = sr.ReadToEnd();
                    accounts = JsonConvert.DeserializeObject<BindingList<AccountInfo>>(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if( accounts == null )
            {
                accounts = new BindingList<AccountInfo>();
            }

            dgAccountBrowser.AutoGenerateColumns = false;
            dgAccountBrowser.Columns[0].DataPropertyName = "Account";
            dgAccountBrowser.Columns[1].DataPropertyName = "Passwd";
            dgAccountBrowser.Columns[2].DataPropertyName = "Type";
            dgAccountBrowser.DataSource = accounts;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HotKeys.RegisterHotKey(this.Handle, hotKeyID, (int)HotKeys.KeyModifiers.Ctrl + (int)HotKeys.KeyModifiers.Alt, Keys.F);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if( dgAccountBrowser.SelectedRows == null )
            {
                MessageBox.Show("have not selected any email account as now~");
                return;
            }
            int index = dgAccountBrowser.SelectedRows[0].Index;

            string address = GlobalSettings.EmailAddress[(int)accounts[index].Type];
            Process proc = Process.Start(address);
        }

        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            EditAccount editWnd = new EditAccount("", "", (int)EmailType.TYPE_163, true);
            editWnd.AnnounceHandler = AddAccountInfo;
            editWnd.ShowDialog();
        }

        private void btnChangeAccountInfo_Click(object sender, EventArgs e)
        {
            if (dgAccountBrowser.CurrentRow == null)
            {
                return;
            }

            int index = dgAccountBrowser.CurrentRow.Index;
            EditAccount editWnd = new EditAccount(accounts[index].Account, accounts[index].Passwd, (int)accounts[index].Type, false);
            editWnd.AnnounceHandler = UpdateAccountInfo;
            editWnd.ShowDialog();
        }

        private void btnDelAccount_Click(object sender, EventArgs e)
        {
            if( dgAccountBrowser.CurrentRow == null )
            {
                return;
            }
            int selectIndex = dgAccountBrowser.CurrentRow.Index;
            if (accounts != null)
            {
                string warning = String.Format("确定要删除{0}的账号信息吗？", accounts[selectIndex].Account);
                if( MessageBox.Show(this, warning, "warning", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK )
                {
                    accounts.RemoveAt(selectIndex);
                }
            }
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            SaveAccountsInfo();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case hotKeyID:    //press the hotkey
                            SimulateFiilInfo();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 根据当前选择的邮箱账号信息，模拟键盘的键入信息事件进行登录
        /// </summary>
        private void SimulateFiilInfo()
        {
            if( dgAccountBrowser.CurrentRow == null )
            {
                return;
            }
            int index = dgAccountBrowser.CurrentRow.Index;

            Thread.Sleep(300);
            Clipboard.SetText(accounts[index].Account);
            SendKeys.Send("^a"); //Ctrl + A : 全选，全选后再删除，可以删除浏览器可能存在的缓存信息
            SendKeys.SendWait("^v");

            SendKeys.SendWait("{tab}");

            Clipboard.SetText(accounts[index].Passwd);
            SendKeys.SendWait("^v");

            SendKeys.SendWait("{ENTER}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( cbSaveInfoBeforeQuit.Checked && MessageBox.Show(this, "正在关闭程序，需要保存当前的账号信息吗？", "closing...", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK )
            {
                SaveAccountsInfo();
            }
            HotKeys.UnregisterHotKey(this.Handle, hotKeyID);
        }

        private bool SaveAccountsInfo()
        {
            bool res = true;
            try
            {
                using (StreamWriter sw = new StreamWriter(GlobalSettings.JsonDir + GlobalSettings.JsonFileName))
                {
                    using (JsonWriter js = new JsonTextWriter(sw))
                    {
                        (new JsonSerializer()).Serialize(js, accounts);
                    }
                }
            }
            catch (Exception ex)
            {
                res = false;
                Console.WriteLine(ex);
            }
            return res;
        }

        /// <summary>
        /// 更新选中的AccountInfo类的内容
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="passwd"></param>
        /// <param name="type"></param>
        private void UpdateAccountInfo( string acc, string passwd, int type)
        {
            if( dgAccountBrowser.SelectedRows == null )
            {
                return;
            }
            int index = dgAccountBrowser.SelectedRows[0].Index;
            accounts[index].Account = acc;
            accounts[index].Passwd = passwd;
            accounts[index].Type = (EmailType)type;
        }
        
        private void AddAccountInfo( string acc, string passwd, int type )
        {
            AccountInfo account = new AccountInfo( acc, passwd, (EmailType)type );
            accounts.Add( account );
        }

        
    }
}
