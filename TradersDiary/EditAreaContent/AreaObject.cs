namespace TradersDiary.EditAreaContent
{
    public abstract class AreaObject
    {
        public string? Id { get; set; }
        public string? ContentType { get; set; }
        public string? Content { get; set; }
        public IDictionary<string, string>? Style { get; set; }
    }
}
