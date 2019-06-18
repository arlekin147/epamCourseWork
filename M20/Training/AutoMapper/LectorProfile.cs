using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Training.Models;
using Training.ViewModels;

namespace Training.AutoMapper
{
    public class LectorProfile : Profile
    {
        public LectorProfile()
        {
            CreateMap<Lector, LectorViewModel>();
            CreateMap<LectorViewModel, Lector>();
        }
    }
}
