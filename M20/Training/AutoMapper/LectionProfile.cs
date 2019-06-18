using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Training.Models;
using Training.ViewModels;
using Training.Utils;

namespace Training.AutoMapper
{
    public class LectionProfile : Profile
    {
        public LectionProfile()
        {
            CreateMap<LectionTuple, LectionViewModel>()
            .ForMember("LectionID", opt => opt.MapFrom(c => c.LectionEl.ID))
            .ForMember("LectionName", opt => opt.MapFrom(c => c.LectionEl.Name))
            .ForMember("Date", opt => opt.MapFrom(c => c.LectionEl.Date))
            .ForMember("LectorID", opt => opt.MapFrom(c => c.LectorEl.ID))
            .ForMember("LectorName", opt => opt.MapFrom(c => c.LectorEl.Surname + " " + c.LectorEl.Name))
            .ForMember("CourseID", opt => opt.MapFrom(c => c.CourseEl.ID))
            .ForMember("CourseName", opt => opt.MapFrom(c => c.CourseEl.Name));
            CreateMap<LectionViewModel, Lection>()
            .ForMember("ID", opt => opt.MapFrom(c => c.LectionID))
            .ForMember("Name", opt => opt.MapFrom(c => c.LectionName))
            .ForMember("Date", opt => opt.MapFrom(c => c.Date))
            .ForMember("LectorID", opt => opt.MapFrom(c => c.LectorID))
            .ForMember("CourseId", opt => opt.MapFrom(c => c.CourseID));
        }
    }
}
