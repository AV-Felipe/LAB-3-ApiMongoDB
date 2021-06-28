namespace CrudMongo.Models
{
    
    //Este DatabaseSettings.cs serve para extrairmos informações do nosso appsettings.json
    //Poderiamos passa, inclusive o nome da collection, por lá e adicioná-lo por aqui
    public interface IDatabaseSettings
    {
        string ConnectionString {get; set;}
        string DatabaseName{get; set;}
    }

        
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString {get; set;}
        public string DatabaseName{get; set;}
    }


}