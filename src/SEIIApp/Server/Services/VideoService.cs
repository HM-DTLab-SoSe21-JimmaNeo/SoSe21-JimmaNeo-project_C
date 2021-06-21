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
    public class VideoService
    {

        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public VideoService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<VideoDefinition> GetQueryableVideoDefinition()
        {
            return DatabaseContext.VideoDefinition;
        }

        // Get ALL Videos
        public VideoDefinition[] GetAllVideos()
        {
            return DatabaseContext.VideoDefinition.ToArray();
        }

        public VideoDefinition GetVideoWithId(int id)
        {
            return GetQueryableVideoDefinition().Where(video => video.VideoId == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück 
        }

        public VideoDefinition AddVideo(VideoDefinition video)
        {
            DatabaseContext.VideoDefinition.Add(video);
            DatabaseContext.SaveChanges();
            return video;
        }

        public VideoDefinition UpdateVideo(VideoDefinition video)
        {
            var existingVideo = GetVideoWithId(video.VideoId);

            Mapper.Map(video, existingVideo); //we can map into the same object type

            DatabaseContext.VideoDefinition.Update(existingVideo);
            DatabaseContext.SaveChanges();
            return existingVideo;
        }

        public void DeleteVideo(int VideoId)
        {
            VideoDefinition v = DatabaseContext.VideoDefinition.Where(x => x.VideoId == VideoId).FirstOrDefault();
            DatabaseContext.VideoDefinition.Remove(v);
            DatabaseContext.SaveChanges();
        }
    }
}
