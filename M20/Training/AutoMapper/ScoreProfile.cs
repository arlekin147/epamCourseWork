using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.ViewModels;
using Training.Utils;

namespace Training.AutoMapper
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<ScoreTuple, ScoreViewModel>()
            .ForMember("LectionId", opt => opt.MapFrom(c => c.LectionEl.LectionID))
            .ForMember("LectionName", opt => opt.MapFrom(c => c.LectionEl.LectionName))
            .ForMember("StudentId", opt => opt.MapFrom(c => c.StudentEl.ID))
            .ForMember("StudentName", opt => opt.MapFrom(c => c.StudentEl.Name))
            .ForMember("IsVisit", opt => opt.MapFrom(c => c.ScoreEl.IsVisit))
            .ForMember("IsHomework", opt => opt.MapFrom(c => c.ScoreEl.IsHomework))
            .ForMember("Mark", opt => opt.MapFrom(c => c.ScoreEl.Mark));
            CreateMap<ScoreViewModel, Score>()
            .ForMember("LectionId", opt => opt.MapFrom(c => c.LectionId))
            .ForMember("StudentId", opt => opt.MapFrom(c => c.StudentId))
            .ForMember("IsVisit", opt => opt.MapFrom(c => c.IsVisit))
            .ForMember("IsHomework", opt => opt.MapFrom(c => c.IsHomework))
            .ForMember("Mark", opt => opt.MapFrom(c => c.Mark));
        }
    }
}
