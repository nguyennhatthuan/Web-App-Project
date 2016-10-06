using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebCinema.Models.DataAccess
{
    public static class MyExtensions
    {
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> source, Int32 count)
        {
            return source.OrderBy(s => Guid.NewGuid()).Take(count);
        }
        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value); 

                return new HtmlString(stringWriter.ToString());
            }
        }
    }
}