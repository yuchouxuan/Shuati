using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication2;

public class ThreadRun
{
    public static String uid = "";
    public static String pws = "888888";
    public static String ret0;
    public static List<String> UrlList;
    private static   Form1  fm  ;
    private static int  count = 10000;
    public static int Func = 0;
    public static bool wbOK = false;
    private static Thread oGetArgThread = null;
    public static int login = 10000;

    public static void Begin()
    {
        if (null != oGetArgThread)
        {
            try
            { oGetArgThread.Abort();}
            catch (Exception)
            {            }
        }
       
       
        oGetArgThread = new Thread(new ThreadStart(run)); 
        oGetArgThread.IsBackground = true;
        oGetArgThread.Start();

    }
    public ThreadRun(String a, String b,Form1 f)
    {
        uid = a;
        pws = b;
        fm = f;
        count = 10000;
        login = 10000;
    UrlList = new List<string>();
  

    }
    static void LogIN()
    {
        wbOK = false;
        Func = 0;
        String url = "http://www.hebgb.gov.cn/j_security_check?j_uri:/portal/index!index.action&yzm=not&j_username=" + uid+ "&j_password="+pws;
        fm.webBrowser1.Navigate(url); 
        while (!wbOK) { Thread.Sleep(100); }



    }
      static void GetList()
    {
        
        UrlList.Clear();
        String[] url = { "http://www.hebgb.gov.cn/student/course!list.action?course.course_type=0&init=yes",
                         "http://www.hebgb.gov.cn/student/course!list.action?course.course_type=1&init=yes" };
        try
        {
            if (login > 4)
            {
                LogIN();
                login = 0;
            }
            login++;
            Func = 1;
            foreach (String ul in url)
            {
                wbOK = false;
                fm.webBrowser1.Navigate(ul);
                while (!wbOK) { Thread.Sleep(100); }
            }
         }
        catch { Func = 0; }
        Func = 0;
    }
    public  static void HartBit()
    {
                     
        String url = "http://www.hebgb.gov.cn/portal/study!play.action?id=" + UrlList[0];

        try
        {
            Func = 2;
            fm.webBrowser2.Navigate(url);
           
            
        }
        catch { }
    }

    public static void run()
    {

      
        while (true) { 

            
                GetList();
                Thread.Sleep(5000);
                count = 0;
                if (UrlList.Count > 0)
                {
                    HartBit();
                    
                }
            Thread.Sleep(300000);
            count++;
        }
        
    }


}
