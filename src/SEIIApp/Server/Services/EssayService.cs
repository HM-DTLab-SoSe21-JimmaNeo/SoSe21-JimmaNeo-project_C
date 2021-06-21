using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class EssayService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public EssayService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<EssayDefinition> GetQueryableEssayDefinition()
        {
            return DatabaseContext.EssayDefinition;
        }

        // Get ALL Essays
        public EssayDefinition[] GetAllEssays()
        {
            return DatabaseContext.EssayDefinition.ToArray();
        }

        public EssayDefinition GetEssayWithId(int id)
        {
            return GetQueryableEssayDefinition().Where(essay => essay.EssayId == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück 
        }

        public EssayDefinition AddEssay(EssayDefinition essay)
        {
            DatabaseContext.EssayDefinition.Add(essay);
            DatabaseContext.SaveChanges();
            return essay;
        }

        public EssayDefinition UpdateEssay(EssayDefinition essay)
        {
            var existingEssay = GetEssayWithId(essay.EssayId);

            Mapper.Map(essay, existingEssay); //we can map into the same object type

            DatabaseContext.EssayDefinition.Update(existingEssay);
            DatabaseContext.SaveChanges();
            return existingEssay;
        }

        public void DeleteEssay(int EssayId)
        {
            EssayDefinition e = DatabaseContext.EssayDefinition.Where(x => x.EssayId == EssayId).FirstOrDefault();
            DatabaseContext.EssayDefinition.Remove(e);
            DatabaseContext.SaveChanges();
        }
    }
}
