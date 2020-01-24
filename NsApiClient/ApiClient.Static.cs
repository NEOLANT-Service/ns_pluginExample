using System.Net.Http;
using System.Threading.Tasks;
using NsApiModels;

namespace NsApiClient
{
    public partial class Client
    {
        private static string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString(value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            return System.Convert.ToString(value, cultureInfo);
        }

        /// <summary>
        /// Читает ответ от сервера как файл
        /// </summary>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        private static async Task<ContentValue> ReadAsContent(HttpContent httpContent)
        {
            var result = new ContentValue()
            {
                Stream = await httpContent.ReadAsStreamAsync(),
                Size = httpContent.Headers.ContentLength,
                Name = httpContent.Headers.ContentDisposition.Name,
                MediaType = httpContent.Headers.ContentType.MediaType
            };
            return result;
        }
    }
}
