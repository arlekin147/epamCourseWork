using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Training.Exceptions.ConfigExceptions;

namespace Training.Utils
{
    public class Config
    {
        public string ConnectionString { get; private set; }
        public string Factory { get; private set; }

        public string GetAllCoursesQuery { get; private set; }
        public string CreateCourseQuery { get; private set; }
        public string DeleteCourseQuery { get; private set; }
        public string GetCourseQuery { get; private set; }
        public string UpdateCourseQuery { get; private set; }

        public string GetAllScoresQuery { get; private set; }
        public string CreateScoreQuery { get; private set; }
        public string DeleteScoreQuery { get; private set; }
        public string GetScoreQuery { get; private set; }
        public string UpdateScoreQuery { get; private set; }
        public string GetAllScoresByStudentIdQuery { get; private set; }
        public string GetAllScoresByLectionIdQuery { get; private set; }


        public string GetAllLectionsQuery { get; private set; }
        public string CreateLectionQuery { get; private set; }
        public string DeleteLectionQuery { get; private set; }
        public string GetLectionQuery { get; private set; }
        public string UpdateLectionQuery { get; private set; }

        public Config(string path)
        {
            XDocument xDoc = XDocument.Load(path);

            XAttribute factory = xDoc.Element("configuration").Element("appSettings")
                .Element("factory").Attribute("value");
            if (factory.Value == null) throw new FactoryNameDoesNotExistsException("Не найдено имя фабрики");
            this.Factory = factory.Value;

            XAttribute connectionStrAttr = xDoc.Element("configuration").Element("connectionStrings")
                .Element("connection").Attribute("connectionString");
            if (connectionStrAttr.Value == null) throw new ConnectionStringDoesNotExistsException("Не найдена строка подключения");
            this.ConnectionString = connectionStrAttr.Value;

            XAttribute getAllCoursesQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getAllCoursesQuery").Attribute("value");
            if (getAllCoursesQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getAllCoursesQuery");
            this.GetAllCoursesQuery = getAllCoursesQueryAttr.Value;

            XAttribute createCourseQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("createCourseQuery").Attribute("value");
            if (getAllCoursesQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос CreateCourseQuery");
            this.CreateCourseQuery = createCourseQueryAttr.Value;

            XAttribute deleteCourseQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("deleteCourseQuery").Attribute("value");
            if (getAllCoursesQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос DeleteCourseQuery");
            this.DeleteCourseQuery = deleteCourseQueryAttr.Value;

            XAttribute updateCourseQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("updateCourseQuery").Attribute("value");
            if (updateCourseQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос UpdateCourseQuery");
            this.UpdateCourseQuery = updateCourseQueryAttr.Value;

            XAttribute getCourseQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getCourseQuery").Attribute("value");
            if (getCourseQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос GetCourseQuery");
            this.GetCourseQuery = getCourseQueryAttr.Value;

            XAttribute getAllLectionsQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getAllLectionsQuery").Attribute("value");
            if (getAllLectionsQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getAllLectionsQuery");
            this.GetAllLectionsQuery = getAllLectionsQueryAttr.Value;

            XAttribute createLectionQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("createLectionQuery").Attribute("value");
            if (createLectionQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос createLectionQuery");
            this.CreateLectionQuery = createLectionQueryAttr.Value;

            XAttribute deleteLectionsQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("deleteLectionQuery").Attribute("value");
            if (deleteLectionsQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос deleteLectionQuery");
            this.DeleteLectionQuery = deleteLectionsQueryAttr.Value;

            XAttribute updateLectionQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("updateLectionQuery").Attribute("value");
            if (updateLectionQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос updateLectionQuery");
            this.UpdateLectionQuery = updateLectionQueryAttr.Value;

            XAttribute getLectionQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getLectionQuery").Attribute("value");
            if (getLectionQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getLectionQuery");
            this.GetLectionQuery = getLectionQueryAttr.Value;

            XAttribute getAllScoresQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getAllScoresQuery").Attribute("value");
            if (getAllScoresQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getAllScoresQuery");
            this.GetAllScoresQuery = getAllScoresQueryAttr.Value;

            XAttribute createScoreQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("createScoreQuery").Attribute("value");
            if (createScoreQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос createScoreQuery");
            this.CreateScoreQuery = createScoreQueryAttr.Value;

            XAttribute deleteScoreQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("deleteScoreQuery").Attribute("value");
            if (deleteScoreQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос deleteScoreQuery");
            this.DeleteScoreQuery = deleteScoreQueryAttr.Value;

            XAttribute updateScoreQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("updateScoreQuery").Attribute("value");
            if (updateScoreQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос updateScoreQuery");
            this.UpdateScoreQuery = updateScoreQueryAttr.Value;

            XAttribute getScoreQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getScoreQuery").Attribute("value");
            if (getScoreQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getScoreQuery");
            this.GetScoreQuery = getScoreQueryAttr.Value;

            XAttribute getAllScoresByStudentIdQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getAllScoresByStudentIdQuery").Attribute("value");
            if (getAllScoresByStudentIdQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getScoreQuery");
            this.GetAllScoresByStudentIdQuery = getAllScoresByStudentIdQueryAttr.Value;

            XAttribute getAllScoresByLectionIdQueryAttr = xDoc.Element("configuration").Element("appSettings")
                .Element("getAllScoresByLectionIdQuery").Attribute("value");
            if (getAllScoresByLectionIdQueryAttr.Value == null) throw new QueryDoesNotExistsException("Не найден запрос getScoreQuery");
            this.GetAllScoresByLectionIdQuery = getAllScoresByLectionIdQueryAttr.Value;
        }
    }
}
