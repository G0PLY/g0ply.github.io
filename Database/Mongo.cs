using MongoDB.Driver;
using UnityEngine;

public class Mongo
{//
    //mongodb+srv://TeaThyme:<password>@teathyme0.qcc2h.mongodb.net/myFirstDatabase??w=majority-shard-00-01
    //private const string MONGO_URI = "mongodb://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net:27017/TeaThyme0";
    //private const string MONGO_URI = "mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net/TeaThyme0";
    //private const string MONGO_URI = "mongodb://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0-shard-00-01.qcc2h.mongodb.net:27017/TeaThyme0";
    private const string MONGO_URI = "mongodb://TeaThyme:jdks8gysnekd92jFSAgw@datalake0-qcc2h.a.query.mongodb.net:27017/TeaThyme0";


    //private const string MONGO_URI = "mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0-shard-00-01.qcc2h.mongodb.net/TeaThyme0";
    //private const string MONGO_URI = "mongodb://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0-shard-00-01.qcc2h.mongodb.net:27017/TeaThyme0";
    //private const string MONGO_URI = "mongodb://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0-shard-00-01.qcc2h.mongodb.net:27017/TeaThyme0";
    //private const string MONGO_URI = "mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net/TeaThyme0"; //?retryWrites=true&w=majority";
    //private const string MONGO_URI = "mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net:27017/TeaThyme0"; //"mongodb://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0-shard-00-01.qcc2h.mongodb.net:27017/TeaThyme0"; //,teathyme0-shard-00-01.qcc2h.mongodb.net:27017/TeaThyme";  //"mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net:27017/TeaThyme0"; //"mongodump --uri mongodb+srv://TeaThyme:jdks8gysnekd92jFSAgw@teathyme0.qcc2h.mongodb.net:27017/TeaThyme0"; //teathyme0-shard-00-01.qcc2h.mongodb.net
    private const string DATABASE_NAME = "TeaThyme0";

    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;

    private MongoCollection accounts;

    public void Init()
    {
        client = new MongoClient(MONGO_URI);
        server = client.GetServer();
        db = server.GetDatabase(DATABASE_NAME);

        //initialize collection
        accounts = db.GetCollection<Model_Account>("account");

        Debug.Log("server initialized");
    }
    public void Shutdown()
    {
        client = null;
        server.Shutdown();
        db = null;
    }

    #region Insert
    public bool InsertAccount(string username, string password, string email, string discriminator)
    {
        Model_Account newAccount = new Model_Account();
        newAccount.Username = username;
        newAccount.ShaPassword = password;
        newAccount.Email = email;
        newAccount.Discriminator = "0000";

        accounts.Insert(newAccount);

        return true;
    }
    #endregion
    /*#region Fetch
    #endregion
    #region Update
    #endregion
    #region Delete
    #endregion*/
}
