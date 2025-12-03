using Banking.Domain;
using Serilog;

public class SerilogAdapter : Banking.Domain.ILogger
{
    //kontrak illoger
    public void Log(string message)
    {
        //meneruskan pesan ke serilog
        Serilog.Log.Information(message);
    }

}
