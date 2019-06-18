using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Training.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ScoreProfile());
                cfg.AddProfile(new LectionProfile());
                cfg.AddProfile(new CourseProfile());
                cfg.AddProfile(new StudentProfile());
                cfg.AddProfile(new LectorProfile());
            });
        }
    }
}
