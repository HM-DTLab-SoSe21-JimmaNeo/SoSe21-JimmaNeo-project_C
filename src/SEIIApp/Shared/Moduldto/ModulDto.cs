using System.Collections.Generic;

namespace SEIIApp.Shared.Moduldto
{
    public class ModulDto
    {
        public int ModulId { get; set; }

        public string Title { get; set; }

        public List<EssayDto> Essays { get; set; } = new List<EssayDto>();

        public List<VideoDto> Videos { get; set; } = new List<VideoDto>();
        public List<QuizDto> Quizes { get; set; } = new List<QuizDto>();

        public ModulDto(string title)
        {
            Title = title;
        }
        
        
    }
}
