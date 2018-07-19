using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
namespace MANIEDIT
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ファイル名を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }

            XmlDocument document = new XmlDocument();

            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", "yes");  // XML宣言
            XmlElement root = document.CreateElement("assembly");  // ルート要素
            root.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v1");
            root.SetAttribute("manifestVersion", "1.0");
            XmlElement element = document.CreateElement("assemblyIdentity");//assemblyIdentity
            element.SetAttribute("type", "win32");  // 属性
            element.SetAttribute("name", "myOrganization.myDivision.mySampleApp");  // 属性
            element.SetAttribute("version", "6.0.0.0");  // 属性
            element.SetAttribute("processorArchitecture", "x86");  // 属性              
            element.SetAttribute("publicKeyToken", "0000000000000000");  // 属性
            XmlElement decyelement = document.CreateElement("dependency");
            XmlElement decyaelement = document.CreateElement("dependentAssembly");
            XmlElement Aidencomctl = document.CreateElement("assemblyIdentity");
            Aidencomctl.SetAttribute("type", "win32");//アセンブリのタイプを指定
            Aidencomctl.SetAttribute("name", "Microsoft.Windows.Common-Controls");//アセンブリ名を指定
            Aidencomctl.SetAttribute("version", "6.0.0.0");//comctl32のバージョン指定
            Aidencomctl.SetAttribute("processorArchitecture", "*");//アーキテクチャを指定
            Aidencomctl.SetAttribute("publicKeyToken", "6595b64144ccf1df");//識別値を指定
            Aidencomctl.SetAttribute("language", "*");//言語を指定
            decyaelement.AppendChild(Aidencomctl);//ここから
            decyelement.AppendChild(decyaelement);//~~
            element.AppendChild(decyelement);//~~
            root.AppendChild(element);//~~
            document.AppendChild(declaration);//~~
            document.AppendChild(root);//ここまでノードの追加
            if (checkBox1.Checked == true)
            {
                XmlElement trustInfoele = document.CreateElement("trustInfo");
                trustInfoele.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v2");
                XmlElement Secuelement = document.CreateElement("security");
                XmlElement reqelement = document.CreateElement("requestedPrivileges");
                reqelement.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v3");
                XmlElement reqlevelelement = document.CreateElement("requestedExecutionLevel");
                reqlevelelement.SetAttribute("level", "requireAdministrator");//UACを設定!
                reqlevelelement.SetAttribute("uiAccess", "false");
                reqelement.AppendChild(reqlevelelement);//ここから
                Secuelement.AppendChild(reqelement);
                trustInfoele.AppendChild(Secuelement);
                root.AppendChild(trustInfoele);//ここまでノードの追加
            }
            document.Save(textBox1.Text + ".manifest");//書き込み

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "EXEファイル(*.exe)|*.exe|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;

            }
        }
    }
}
