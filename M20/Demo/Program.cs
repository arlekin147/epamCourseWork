using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;
using Training.Exceptions;
using Training.Repositories;
using Training.Models;
using Training.Utils;
using Training.Servises;
using Training.AutoMapper;
using AutoMapper;
using log4net;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = LogManager.GetLogger("LOGGER");
            var configString = @"C:\Users\14714\source\repos\M20\Training\config.xml";
            var mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            var lectionServ = new LectionServise(
                 new LectionRepository(configString, null),
                 new LectorServise(new LectorRepository()),
                 new CourseServise(new CourseRepository(configString, null), mapper),
                 mapper
             );
            var courseServ = new CourseServise(new CourseRepository(configString, null), mapper);
            var studentServ = new StudentService(new StudentRepository(), mapper);
            Console.WriteLine(courseServ.Get(1));
            Console.WriteLine(lectionServ.Get(1));
            Console.WriteLine(studentServ.Get(1));
            Console.ReadKey();
        }
    }
}
