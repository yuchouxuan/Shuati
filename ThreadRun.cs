using System;

public class ThreadRun 
{
    public String uid = "";
    public String pws = "888888";
    public Thread runThread = null;
    public String ret0;
     


    private void Begin()
    {
        try
        {
            if (null != runThread)
            { runThread.Abort();  }
            
        }
        catch (Exception)
        {}
        Thread runThread = new Thread(new ThreadStart(CoreFunction));
        runThread.Start();
    }
    public ThreadRun(String a ,sting b)
	{
        uid = a;
        pws = b;
        
	}
    public ThreadRun(String a)
    {
        uid = a;
    }

    

    static void CoreFunction()
  {
        var request = (HttpWebRequest)WebRequest.Create(url); //Create:创建WebRequest对象  
        var response = (HttpWebResponse)request.GetResponse(); //GetResponse:获取答复  
        Stream stream = response.GetResponseStream();//GetResponseStream:获取应答流  
        StreamReader sr = new StreamReader(stream);  //从字节流中读取字符  
        string content = sr.ReadToEnd();

    }


}
