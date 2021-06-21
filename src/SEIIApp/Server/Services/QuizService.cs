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
    public class QuizService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public QuizService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<QuizDefinition> GetQueryableQuizDefinition()
        {
            return DatabaseContext.QuizDefinition;
        }

        // Get ALL Quizes
        public QuizDefinition[] GetAllQuizes()
        {
            return DatabaseContext.QuizDefinition.ToArray();
        }

        public QuizDefinition GetQuizWithId(int id)
        {
            return GetQueryableQuizDefinition().Where(quiz => quiz.QuizId == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück 
        }

        public QuizDefinition AddQuiz(QuizDefinition quiz)
        {
            DatabaseContext.QuizDefinition.Add(quiz);
            DatabaseContext.SaveChanges();
            return quiz;
        }

        public QuizDefinition UpdateQuiz(QuizDefinition quiz)
        {
            var existingQuiz = GetQuizWithId(quiz.QuizId);

            Mapper.Map(quiz, existingQuiz); //we can map into the same object type

            DatabaseContext.QuizDefinition.Update(existingQuiz);
            DatabaseContext.SaveChanges();
            return existingQuiz;
        }

        public void DeleteQuiz(int QuizId)
        {
            QuizDefinition q = DatabaseContext.QuizDefinition.Where(x => x.QuizId == QuizId).FirstOrDefault();
            DatabaseContext.QuizDefinition.Remove(q);
            DatabaseContext.SaveChanges();
        }
    }
}
