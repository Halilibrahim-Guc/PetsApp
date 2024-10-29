using BLL.DAL;

namespace BLL.Services.Bases
{
    public abstract class ServiceBase
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty; // or = ""

        protected readonly Db _db;
        protected ServiceBase(Db Db) 
        {
            _db = db;
        }

        public ServiceBase Success(string message = "") // Success() or Success("Record created succesfully")
        {
            IsSuccessful = true;
            Message = message;
            return this; 
        }

        public ServiceBase Error(string message = "")
        {
            IsSuccessful = true;
            Message = message;
            return this;
        }

    }
