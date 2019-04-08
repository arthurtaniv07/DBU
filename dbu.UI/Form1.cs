using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using dbu.DAL;
using dbu.Build;
using dbu.Model;
using System.IO;
using St.IO;
using St.TemplateEngine;
using System.Text.RegularExpressions;
using St;
using System.Globalization;

namespace dbu.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isLineSuccess = false;

        string serverAddress = "";
        string passWord = "";
        string name = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest">是否是测试连接 为false则获取数据库名称列表</param>
        /// <returns></returns>
        List<string> LineToServer(bool isTest, bool isShouSuccessMsg = true)
        {
            isLineSuccess = false;

            if (string.IsNullOrWhiteSpace(serverAddress = this.txtServerAddress.Text) || string.IsNullOrWhiteSpace(name = this.txtuserName.Text) || string.IsNullOrWhiteSpace(passWord = this.txtpassWord.Text))
            {
                MessageBox.Show("请将连接信息填写完整");
                return null;
            }
            if (isTest)
            {
                if (DBHelper.TextLineToServer(serverAddress, name, passWord))
                {
                    if (isShouSuccessMsg)
                        MessageBox.Show("测试连接成功");
                    return new List<string>();
                }
                else
                {
                    if (isShouSuccessMsg)
                        MessageBox.Show("测试连接失败");
                    else
                        MessageBox.Show("连接失败");
                    return null;
                }
            }

            //不是测试连接  获取数据库
            return DBHelper.getAlldbName(serverAddress, name, passWord, !this.checkBox3.Checked);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LineToServer(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.comBoxDBList.DataSource = null;

            if (LineToServer(true, false) == null)
            {
                ChangeCurrState("服务器连接失败");
                return;
            }

            ChangeCurrState("开始加载数据...");
            isLineSuccess = false;
            List<string> dbList = null;
            dbList = LineToServer(false);

            //连接数据库成功  ，将数据库名称列表添加到下拉框
            this.comBoxDBList.DataSource = dbList;
            ChangeCurrState("数据库列表加载成功");

        }
        private void ChangeCurrState(string msg)
        {
            this.lblCurrState.Text = msg;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool istrue = !string.IsNullOrWhiteSpace(this.txtProName.Text);
            if (istrue)
            {
                isLineSuccess = istrue;
            }
            this.txtProBllName.Enabled = istrue;
            this.txtProDalName.Enabled = istrue;
            this.txtProModelName.Enabled = istrue;
        }

        void txtProModel__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tt.Text))
            {
                tt.Text = ".";
            }
            if (tt.Text.Trim().Length == 2 && tt.Text.Trim().Substring(0, 1) == ".")
            {
                isLineSuccess = false;
                e.Handled = true;
            }
        }


        public class a
        {
            public int? id { get; set; }
        }

        /// <summary>
        /// 程序是否在调试
        /// </summary>
        private bool IsDebug = false;
        //private bool IsDebug = System.Configuration.sett;


        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsDebug)
            {
                this.txtServerAddress.Text = this.txtServerAddress.Tag + "";
                this.txtuserName.Text = this.txtuserName.Tag + "";
                this.txtpassWord.Text = this.txtpassWord.Tag + "";
            }
            else
            {
                //this.txtServerAddress.Text = "(local)";
                this.txtServerAddress.Text = "(local)";
                this.txtuserName.Text = "sa";
                this.txtpassWord.Text = "123456";
            }
            this.txtServerAddress.Text = "(local)";
            this.txtuserName.Text = "sa";
            this.txtpassWord.Text = "123456";

            //this.txtServerAddress.Text = "(local)";
            //this.txtuserName.Text = "sa";
            //this.txtpassWord.Text = "123456";

            //this.panel1.Location = new Point(-496, 294);

            this.button5.Tag = (St.StEnvironment.IsRunAsAdmin && St.StEnvironment.IsServiceStart("MSSQLSERVER")) ? "1" : "0";
            this.button5.Text = this.button5.Tag + "" == "0" ? "开启本地服务" : "关闭本地服务";
            this.button5.Visible = St.StEnvironment.IsRunAsAdmin;


            //string sql = DbSqlBuild.GetPading("tms_order", "*", "id", "", 10, 2, "order by id desc", "", PaddingType.RowNumber3);
            string conf_s = "files/config.ini";
            bool configExists = File.Exists(conf_s);
            if (configExists)
            {
                string d = File.ReadAllLines(conf_s)[0];
                this.txtDirPath.Text = d;
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("id");
            //dt.Rows.Add(new object[] { null });
            //if (dt.Rows[0][0] is DBNull)
            //{
            //    a a = new a();
            //    a.id = dt.Rows[0][0] as int?;
            //    MessageBox.Show(a.id == null?"null":"");
            //}

            this.txtProName.Text = "";
            this.txtProModelName.Text = ".Model";
            this.txtProDalName.Text = ".DAL";
            this.txtProBllName.Text = ".BLL";
            //this.txtProModelName.KeyPress += txtProModel__KeyPress;
            //this.txtProDalName.KeyPress += txtProModel__KeyPress;
            //this.txtProBllName.KeyPress += txtProModel__KeyPress;
            this.txtProModelName.KeyUp += TxtProModelName_KeyUp;
            this.txtProDalName.KeyUp += TxtProModelName_KeyUp;
            this.txtProBllName.KeyUp += TxtProModelName_KeyUp;
            isLineSuccess = false;
            this.txtpassWord.PasswordChar = '*';
            this.lblCurrState.Text = "";
        }

        private void TxtProModelName_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tt.Text))
            {
                tt.Text = ".";
                tt.Select(1, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog opd = new FolderBrowserDialog();
            opd.Description = "请选择文件路径";
            string conf_s = "files/config.ini";
            bool configExists = File.Exists(conf_s);
            if (!string.IsNullOrWhiteSpace(this.txtDirPath.Text))
            {
                opd.SelectedPath = this.txtDirPath.Text;
            }
            if (opd.ShowDialog() == DialogResult.OK)
            {
                this.txtDirPath.Text = opd.SelectedPath;
            }
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (IsDebug)
            {
                Yanzheng();
            }
            else
            {
                System.Threading.Thread t = new System.Threading.Thread(Yanzheng);
                t.Start();
            }
        }

        public void Yanzheng()
        {
            #region 验证输入

            ChangeCurrState("正在验证输入...");
            //点击生成
            if (this.comBoxDBList.DataSource == null || String.IsNullOrWhiteSpace(this.comBoxDBList.Text))
            {
                ChangeCurrState("您还没有选择数据库");
                MessageBox.Show("您还没有选择数据库");
                return;
            }
            if (this.listBox1.Items.Count == 0 && this.listBox2.Items.Count == 0)
            {
                ChangeCurrState("您还没有加载表");
                MessageBox.Show("您还没有加载表");
                return;
            }
            if (this.listBox2.Items.Count == 0)
            {
                ChangeCurrState("请选择需要生成的表");
                MessageBox.Show("请选择需要生成的表");
                return;
            }
            if (this.txtProName.Text.Trim().Length == 0)
            {
                ChangeCurrState("请输入项目名");
                MessageBox.Show("请输入项目名称");
                return;
            }
            string[] ss = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (ss.Contains(this.txtProName.Text.Trim().Substring(0, 1)))
            {
                ChangeCurrState("项目名称第一位不能是数字");
                MessageBox.Show("项目名称第一位不能是数字");
                return;
            }

            if (this.txtProBllName.Text.Trim('.').Trim().Length == 0 ||
                this.txtProDalName.Text.Trim('.').Trim().Length == 0 ||
                this.txtProModelName.Text.Trim('.').Trim().Length == 0)
            {
                ChangeCurrState("请输入命名空间");
                MessageBox.Show("请输入命名空间");
                return;
            }
            if (
                ss.Contains(this.txtProBllName.Text.Trim('.').Trim().Substring(0, 1)) ||
                ss.Contains(this.txtProDalName.Text.Trim('.').Trim().Substring(0, 1)) ||
                ss.Contains(this.txtProModelName.Text.Trim('.').Trim().Substring(0, 1))
                )
            {
                ChangeCurrState("命名空间第一位不能是数字");
                MessageBox.Show("命名空间第一位不能是数字");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtDirPath.Text))
            {
                ChangeCurrState("请选择文件生成路径");
                MessageBox.Show("请选择文件生成路径");
                return;
            }

            #endregion


            //验证通过
            string modelStr = this.txtProName.Text.Trim() + "." + this.txtProModelName.Text.Trim('.').Trim();
            string bllStr = this.txtProName.Text.Trim() + "." + this.txtProBllName.Text.Trim('.').Trim();
            string dalStr = this.txtProName.Text.Trim() + "." + this.txtProDalName.Text.Trim('.').Trim();
            string dbName = this.comBoxDBList.Text;
            string serverAddress = this.txtServerAddress.Text.Trim();
            string userName = this.txtuserName.Text.Trim();
            string passWord = this.txtpassWord.Text.Trim();
            //开始生成文件

            string[] conf_s = File.ReadAllLines("files/config.ini");
            string path = conf_s[0];//路径
            if (!string.IsNullOrWhiteSpace(this.txtDirPath.Text))
            {
                path = this.txtDirPath.Text;
            }
            string reStr = conf_s[1];//路径
            List<string> r = new List<string>();
            foreach (var item in reStr)
            {
                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    r.Add(item.ToString());
                }
            }

            path = path.Replace("{yy}", DateTime.Now.ToString("yy"));
            path = path.Replace("{yyyy}", DateTime.Now.ToString("yyyy"));
            path = path.Replace("{MM}", DateTime.Now.ToString("MM"));
            path = path.Replace("{dd}", DateTime.Now.ToString("dd"));

            string mStr = path + "/" + this.txtProName.Text + ".Model";
            string dStr = path + "/" + this.txtProName.Text + ".DAL";
            string bStr = path + "/" + this.txtProName.Text + ".BLL";
            string hStr = path + "/" + this.txtProName.Text + ".HTML";
            string sqlStr = path + "/" + this.txtProName.Text + ".SQL";

            List<string> types = new List<string>();
            if (this.checkBox1.Checked)
            {
                types.Add("U");
            }
            if (this.checkBox2.Checked)
            {
                types.Add("V");
            }


            ChangeCurrState("正在获取数据库字段信息...");
            Dictionary<string, List<StObjField>> fss_Create = new Dictionary<string, List<StObjField>>();

            foreach (string item in fss.Keys)
            {
                if (this.listBox2.Items.Contains(item))
                {
                    fss_Create.Add(item, fss[item]);
                }
            }
            

            //Dictionary<string, List<StObjField>> fss = new Dictionary<string, List<StObjField>>();
            //List<string> tabs = DBHelper.GetAllTableName(serverAddress, dbName, userName, passWord);
            //foreach (string tabName in tabs)
            //{
            //    List<StObjField> fs = DBHelper.GetTableFieldInfo(serverAddress, dbName, tabName, userName, pssWord);
            //    fss.Add(tabName, fs);
            //}
            //生成实体类
            if (this.checkBox4.Checked)
            {
                if (Directory.Exists(mStr))
                    Directory.Delete(mStr, true);
                Directory.CreateDirectory(mStr);
                ChangeCurrState("正在创建实体类...");
                List<string> mfiles = DBUFileHelper.CreateModels(mStr, modelStr, fss_Create, serverAddress);
            }

            //生成DAL
            if (this.checkBox5.Checked)
            {
                if (Directory.Exists(dStr))
                    Directory.Delete(dStr, true);
                Directory.CreateDirectory(dStr);
                ChangeCurrState("正在创建数据访问层...");
                List<string> dfiles = DBUFileHelper.CreateDAL(dStr, dalStr, modelStr, fss_Create);
            }

            //生成BLL
            if (this.checkBox6.Checked)
            {
                if (Directory.Exists(bStr))
                    Directory.Delete(bStr, true);
                Directory.CreateDirectory(bStr);
                ChangeCurrState("正在创建业务逻辑层...");
                List<string> bfiles = DBUFileHelper.CreateBLL(bStr, bllStr, modelStr, dalStr, fss_Create);
            }

            //生成HTML
            if (this.checkBox7.Checked)
            {
                if (Directory.Exists(hStr))
                    Directory.Delete(hStr, true);
                Directory.CreateDirectory(hStr);

                ChangeCurrState("正在创建HTML...");
                DBUFileHelper.CreateHTML(hStr, fss_Create);
            }

            //生成SQL
            if (this.checkBox8.Checked)
            {
                var StObjects_1 = DBHelper.GetAllTableObjectsInfo2(serverAddress, dbName, userName, passWord);
                DBUFileHelper.StObjects_1 = StObjects_1;

                if (Directory.Exists(sqlStr))
                    Directory.Delete(sqlStr, true);
                Directory.CreateDirectory(sqlStr);

                ChangeCurrState("正在创建SQL...");
                var hou_ = DBHelper.SortByFOREIGN_KEY(fss_Create);
                DBUFileHelper.CreateSQL(sqlStr, dbName,hou_);
            }

            ChangeCurrState("生成成功");

        }




        private void comBoxDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.txtProName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((string)this.comBoxDBList.SelectedValue);
        }

        private void comBoxDBList_TextChanged(object sender, EventArgs e)
        {
            this.txtProName.Text = this.comBoxDBList.SelectedText;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Threading.Thread th = new System.Threading.Thread(ChangeServer);
            th.Start();
        }

        public void ChangeServer()
        {
            this.Enabled = false;
            string rel = OpenOrCloseServer(this.button5.Tag + "");
            if (rel != "")
            {
                if (this.button5.Tag + "" == rel) { MessageBox.Show("操作失败"); }
                this.button5.Tag = rel;
                if (rel == "1") { MessageBox.Show("开启成功"); this.button5.Text = "关闭本地服务"; }
                else if (rel == "0") { MessageBox.Show("关闭成功"); this.button5.Text = "开启本地服务"; }
            }
            this.Enabled = true;
            this.Activate();
        }

        /// <summary>
        /// this.button5.Tag
        /// </summary>
        /// <param name="open"></param>
        public string OpenOrCloseServer(string tag = "")
        {
            if (St.StEnvironment.IsRunAsAdmin)
            {
                bool sopen = St.StEnvironment.IsServiceStart("MSSQLSERVER");
                if (tag == "" && sopen)
                {
                    return "1";
                }
                if (tag == "1" && sopen)
                {
                    //需要关闭
                    if (St.StEnvironment.StopService("MSSQLSERVER", 30)) { return "0"; }
                    else { return "1"; }
                }
                if (tag == "0" && !sopen)
                {
                    //需要开启
                    if (St.StEnvironment.StartService("MSSQLSERVER", 30)) { return "1"; }
                    else { return "0"; }
                }
                return "2";
            }
            else
            {
                MessageBox.Show("请以管理员身份运行");
                return "";
            }
        }


        public void Add(bool all, bool toRight)
        {
            if (all)
            {

                if (toRight)
                {
                    foreach (string item in this.listBox1.Items)
                    {
                        this.listBox2.Items.Add(item);
                    }
                    listBox1.Items.Clear();
                }
                else
                {
                    foreach (string item in this.listBox2.Items)
                    {
                        this.listBox1.Items.Add(item);
                    }
                    listBox2.Items.Clear();
                }
            }
            else
            {
                int? temp_index = null;
                if (toRight)
                {
                    foreach (string item in this.listBox1.SelectedItems)
                    {
                        if (temp_index == null) { temp_index = this.listBox1.SelectedIndex; }
                        this.listBox2.Items.Add(item);
                    }
                    RemoveSelectItems<object>(this.listBox1);
                    SortListBoxItem(this.listBox2);
                    if (temp_index != null && this.listBox1.Items.Count > 0 && temp_index < this.listBox1.Items.Count - this.listBox1.SelectedItems.Count)
                    {
                        this.listBox1.SelectedIndex = temp_index.Value;
                    }
                }
                else
                {
                    foreach (string item in this.listBox2.SelectedItems)
                    {
                        if (temp_index == null) { temp_index = this.listBox2.SelectedIndex; }
                        this.listBox1.Items.Add(item);
                    }
                    RemoveSelectItems<object>(this.listBox2);
                    SortListBoxItem(this.listBox1);
                    if (temp_index != null && this.listBox2.Items.Count > 0 && temp_index < this.listBox1.Items.Count - this.listBox1.SelectedItems.Count)
                    {
                        this.listBox2.SelectedIndex = temp_index.Value;
                    }
                }
            }

        }
        public void SortListBoxItem(ListBox listControl)
        {
            List<string> rel = new List<string>();
            foreach (string item in listControl.Items)
            {
                rel.Add(item);
            }
            rel.Sort();
            listControl.Items.Clear();
            listControl.Items.AddRange(rel.ToArray());
        }
        public void RemoveSelectItems<T>(ListBox listControl)
        {
            int[] selItems = new int[listControl.SelectedIndices.Count];
            listControl.SelectedIndices.CopyTo(selItems, 0);
            for (int i = selItems.Length - 1; i > -1; i--)
            {
                listControl.Items.RemoveAt(selItems[i]);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add(true, false);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Add(true, true);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add(false, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add(false, false);
        }

        //加载表
        private void button10_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();

            ChangeCurrState("正在加载数据...");
            //点击生成
            if (this.comBoxDBList.DataSource == null || String.IsNullOrWhiteSpace(this.comBoxDBList.Text))
            {
                ChangeCurrState("您还没有选择数据库");
                MessageBox.Show("您还没有选择数据库");
                return;
            }

            //验证通过
            string modelStr = this.txtProName.Text.Trim() + "." + this.txtProModelName.Text.Trim('.').Trim();
            string bllStr = this.txtProName.Text.Trim() + "." + this.txtProBllName.Text.Trim('.').Trim();
            string dalStr = this.txtProName.Text.Trim() + "." + this.txtProDalName.Text.Trim('.').Trim();
            string dbName = this.comBoxDBList.Text;
            string serverAddress = this.txtServerAddress.Text.Trim();
            string userName = this.txtuserName.Text.Trim();
            string passWord = this.txtpassWord.Text.Trim();
            //开始生成文件

            string[] conf_s = File.ReadAllLines("files/config.ini");
            string path = conf_s[0];//路径
            if (!string.IsNullOrWhiteSpace(this.txtDirPath.Text))
            {
                path = this.txtDirPath.Text;
            }
            string reStr = conf_s[1];//路径
            List<string> r = new List<string>();
            foreach (var item in reStr)
            {
                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    r.Add(item.ToString());
                }
            }

            path = path.Replace("{yy}", DateTime.Now.ToString("yy"));
            path = path.Replace("{yyyy}", DateTime.Now.ToString("yyyy"));
            path = path.Replace("{MM}", DateTime.Now.ToString("MM"));
            path = path.Replace("{dd}", DateTime.Now.ToString("dd"));

            string mStr = path + "/" + this.txtProName.Text + ".Model";
            string dStr = path + "/" + this.txtProName.Text + ".DAL";
            string bStr = path + "/" + this.txtProName.Text + ".BLL";

            List<string> types = new List<string>();
            if (this.checkBox1.Checked)
            {
                types.Add("U");
            }
            if (this.checkBox2.Checked)
            {
                types.Add("V");
            }

            int temp = 0;

            //var aaa = DBHelper.GetAllTableFieldInfo2(serverAddress, dbName, userName, passWord, types, conf_s[2], r.ToArray());
            ChangeCurrState("正在获取数据库字段信息...");
            fss = DBHelper.GetAllTableFieldInfo(serverAddress, dbName, userName, passWord, types, conf_s[2], r.ToArray());

            string connStr2 = DBHelper.GetLineStr(serverAddress, dbName, userName, passWord);
            //排序引用视图
            List<string> views = new List<string>();
            DBHelper.GetAllViewSortInfo(connStr2, ref views);
            fss = Util.DictionarySort(fss, views);

            //排序引用表
            List<string> tabSort = DBHelper.GetAllTableSortInfo(serverAddress, dbName, name, passWord);
            fss = Util.DictionarySort(fss, tabSort);


            this.listBox1.Items.Clear();
            List<string> rel = fss.Keys.ToList();
            rel.Sort();
            this.listBox1.Items.AddRange(rel.ToArray());

            ChangeCurrState("数据表加载成功");

        }

        Dictionary<string, List<StObjField>> fss = null;

        private void txtDirPath_DoubleClick(object sender, EventArgs e)
        {

            string[] conf_s = File.ReadAllLines("files/config.ini");
            string path = conf_s[0];//路径
            if (!string.IsNullOrWhiteSpace(this.txtDirPath.Text))
            {
                path = this.txtDirPath.Text;
            }

            path = path.Replace("{yy}", DateTime.Now.ToString("yy"));
            path = path.Replace("{yyyy}", DateTime.Now.ToString("yyyy"));
            path = path.Replace("{MM}", DateTime.Now.ToString("MM"));
            path = path.Replace("{dd}", DateTime.Now.ToString("dd"));
            StDirectory.ExistsDirectory(path, true);

            //OpenDic(path);

            //return;

            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        public void OpenDic(string path)
        {

            //string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            int hwCurr = FindWindow(null, "Main");
            bool re = ShowWindow((IntPtr)hwCurr, 3|1);
        }
    }
    public enum OpenDicEnum
    {
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        SW_HIDE = 0,

        /// <summary>
        /// 正常。保持原有状态
        /// </summary>
        SW_SHOWNORMAL = 1,
        /// <summary>
        /// 激活窗口并将其最小化。
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// 激活窗口并将其最大化。
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
        /// <summary>
        /// 最大化指定的窗口。
        /// </summary>
        SW_MAXIMIZE = 3,
        /// <summary>
        /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// 在窗口原来的位置以原来的尺寸激活和显示窗口。
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// 最小化指定的窗口并且激活在Z序中的下一个顶层窗口。
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
        /// </summary>
        SW_RESTORE = 9,
    }
}
