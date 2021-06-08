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
    public class ForumService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public ForumService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<PostDefinition> GetQueryablePostDefinition()
        {
            return DatabaseContext.PostDefinition;
             
        }

        // Get ALL Posts
        public PostDefinition[] GetAllPosts()
        {  
            return DatabaseContext.PostDefinition.ToArray();
        
        }
       


        public PostDefinition GetPostWithId(int id)
        {
            return GetQueryablePostDefinition().Where(post => post.PostId == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        public PostDefinition[] GetPostwithCategory(String category)
        {
            return GetQueryablePostDefinition().Where(post => post.Category == category).ToArray();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        public PostDefinition AddPost(PostDefinition post)
        {
            DatabaseContext.PostDefinition.Add(post);
            DatabaseContext.SaveChanges();
            return post;
        }


            public void DeletePdf(int PostId)
            {
            DatabaseContext.PostDefinition.SingleOrDefault(x => x.PostId == PostId).Attachment = null;
            DatabaseContext.SaveChanges();
            }

            public PostDefinition Save(PostDefinition post)
            {
            DatabaseContext.PostDefinition.Add(post);
            DatabaseContext.SaveChanges();
                return post;
            }









            public PostDefinition UploadPdf(int PostId, byte[] pdf)
            {
            DatabaseContext.PostDefinition.SingleOrDefault(x => x.PostId == PostId).Attachment = pdf;
            DatabaseContext.SaveChanges();
                return DatabaseContext.PostDefinition.SingleOrDefault(x => x.PostId == PostId);
            }

            public void DeletePost(int PostId)
            {
                PostDefinition p = DatabaseContext.PostDefinition.Where(x => x.PostId == PostId).FirstOrDefault();
                DatabaseContext.PostDefinition.Remove(p);
                DatabaseContext.SaveChanges();
            }

    }
}
