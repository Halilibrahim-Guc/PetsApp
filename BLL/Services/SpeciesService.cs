using Azure.Identity;
using BLL.DAL;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface ISpeciesService 
    {
        public IQueryable<SpeciesModel> Query();

        public ServiceBase Create(Species record);

        public ServiceBase Update(Species record);

        public ServiceBase Delete(Species record);
    }


    public class SpeciesService : ServiceBase, ISpeciesService
    {
        public SpeciesService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Species record)
        {
            if (_db.Species.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Species with the same name exists!");
            record.Name = record.Name?.Trim(); //aslında ? kullanmaya gerek yok, çünkü isim null olmayacak, ama diyelim ki oldu, error almamak için koyduk
            _db.Species.Add(record);
            _db.SaveChanges(); // commit to the database
            return Success("Species created succesfully!");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Species.Include()(s => s.Pets).SingleOrDefault(s => s.Id == id)
            if (entity is null)
                return Error("Species cannot be found!");
            if (entity.Pets.Any()) // Count > 0
                return Error("Species has relational pets!");
            _db.Species.Remove(entity);
            _db.SaveChanges(); // commit to database
            return Success("Species deleted succesfully!");

        }

        public IQueryable<SpeciesModel> Query()
        {
            return _db.Species.OrderBy(s => s.Name).Select(s => new SpeciesModel() { Record = s});
        }

        public ServiceBase Update(Species record)
        {
            if (_db.Species.Any(s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Species with the same name exists!");

            //way 1 : var entity = _db.Species.Find(record.Id);
            //way 2:
            var entity = _db.Species.SingleOrDefault(s => s.Id == record.Id);
            if (entity == null) // entity is null yazabilirsin
                return Error("Species cannot be found!");
            entity.Name = record.Name?.Trim();
            _db.Species.Add(record);
            _db.SaveChanges(); // commit to the database
            return Success("Species updated succesfully!");
        }
    }
}
