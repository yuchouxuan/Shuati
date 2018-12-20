using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    
    public partial class Form1 : Form
    {
       
        private ThreadRun threadX = null;
        public HtmlDocument doc = null;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true; //禁用错误脚本提示 

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            threadX = new ThreadRun(textBox1.Text, textBox2.Text,  this);
            ThreadRun.Begin();
            
            

        }

        private void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
                
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           ;
            if (webBrowser1.ReadyState < WebBrowserReadyState.Complete) return;
            
            if (ThreadRun.Func == 1)
            {
                doc = webBrowser1.Document;
                HtmlElementCollection elems = doc.GetElementsByTagName("a");
                foreach (HtmlElement el in elems)
                {
                    String s = el.OuterHtml;
                   
                    if (s.IndexOf("pbtn04a")>0)
                    {
                        s = s.Split('(')[1];
                        s = s.Split(')')[0];
                        ThreadRun.UrlList.Add(s);
                     }
                    
                }
                textBox3.Text = "";
                int i = 1;
                foreach (String sx in ThreadRun.UrlList)
                {
                    textBox3.Text +=sx + ":" + i;
                    textBox3.Text += "\r\n";
                    i++;
                }



            }

            ThreadRun.wbOK = true;
        }

    }
}
