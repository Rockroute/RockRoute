using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiTest;

namespace RockRoute.Helper
{

public List<Teacher> UseJArrayParseInNewtonsoftJson()
{
    using StreamReader reader = new(_sampleJsonFilePath);
    var json = reader.ReadToEnd();
    var jarray = JArray.Parse(json);
    List<Teacher> teachers = new();
    foreach (var item in jarray)
    {
        Teacher teacher = item.ToObject<Teacher>();
        teachers.Add(teacher);
    }
    return teachers;
}