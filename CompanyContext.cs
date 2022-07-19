namespace web_api;

public class CompanyContext {

    
    public CompanyContext(string connection) => _connection = connection;
    
    public string _connection { get; set; }
    
}