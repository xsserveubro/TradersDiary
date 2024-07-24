namespace TradersDiary.EditAreaContent
{
    public class AreaObject
    {
        public string? Id { get; set; }
        public string? ContentType { get; set; }
        public string? Content { get; set; }

        public AreaObject()
        {
            
        }

        public AreaObject(string id, string contentType, string content)
        {
            Id = id;
            ContentType = contentType;
            Content = content;
        }
    }
}
