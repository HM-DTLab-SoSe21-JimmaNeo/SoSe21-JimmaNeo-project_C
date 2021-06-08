using AutoMapper;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {

        public DomainMapper()
        {
            // Create PostDto
            CreateMap<PostDto, PostDefinition>();
            CreateMap<PostDefinition, PostDto>();


            // Create ModulDto
            CreateMap<ModulDto, ModulDefinition>();
            CreateMap<ModulDefinition, ModulDto>();

            // Modul components

            // Create EssayDto
            CreateMap<EssayDto, EssayDefinition>();
            CreateMap<EssayDefinition, EssayDto>();

            // Create VideoDto
            CreateMap<VideoDto, VideoDefinition>();
            CreateMap<VideoDefinition, VideoDto>();

            // Create QuizDto
            CreateMap<QuizDto, QuizDefinition>();
            CreateMap<QuizDefinition, QuizDto>();

            // Create QuestionDto
            CreateMap<QuestionDto, QuestionDefinition>();
            CreateMap<QuestionDefinition, QuestionDto>();

            // Create AnswerOptionDto
            CreateMap<AnswerOptionDto, AnswerOptionDefinition>();
            CreateMap<AnswerOptionDefinition, AnswerOptionDto>();





        }

    }
}
