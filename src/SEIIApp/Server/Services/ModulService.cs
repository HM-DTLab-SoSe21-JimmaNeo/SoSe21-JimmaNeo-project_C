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
    public class ModulService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public ModulService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<ModulDefinition> GetQueryableModulDefinition()
        {
            return DatabaseContext.ModulDefinition;
        }

        // Get ALL Moduls
        public ModulDefinition[] GetAllModuls()
        {
            return DatabaseContext.ModulDefinition.ToArray();

        }

        public ModulDefinition GetModulWithId(int id)
        {
            return GetQueryableModulDefinition().Where(modul => modul.ModulId == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        public ModulDefinition Save(ModulDefinition modul)
        {
            DatabaseContext.ModulDefinition.Add(modul);
            DatabaseContext.SaveChanges();
            return modul;
        }

        public ModulDefinition UploadVideo(int ModulId, VideoDefinition video)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Videos.Add(video);
            DatabaseContext.SaveChanges();
            return DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId);
        }

        public void DeleteVideo(int ModulId, VideoDefinition video)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Videos.Remove(video);
            DatabaseContext.SaveChanges();
        }

        public ModulDefinition UploadEssay(int ModulId, EssayDefinition essay)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Essays.Add(essay);
            DatabaseContext.SaveChanges();
            return DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId);
        }

        public void DeleteEssay(int ModulId, EssayDefinition essay)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Essays.Remove(essay);
            DatabaseContext.SaveChanges();
        }

        public ModulDefinition UploadQuiz(int ModulId, QuizDefinition quiz)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Quizes.Add(quiz);
            DatabaseContext.SaveChanges();
            return DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId);
        }

        public void DeleteQuiz(int ModulId, QuizDefinition quiz)
        {
            DatabaseContext.ModulDefinition.SingleOrDefault(x => x.ModulId == ModulId).Quizes.Remove(quiz);
            DatabaseContext.SaveChanges();
        }

    }

}
