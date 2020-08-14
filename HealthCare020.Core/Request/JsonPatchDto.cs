namespace HealthCare020.Core.Request
{
    public class JsonPatchDto
    {
        public string Op { get; set; }
        public string Path { get; set; }
        public object Value { get; set; }
       
        public JsonPatchDto(string op, string path, object value)
        {
            Op = op;
            Path = path;
            Value = value;
        }

    }
}