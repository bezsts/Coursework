﻿namespace WPF.Models.Requests
{
    public class RequestParametres
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Method { get; set; } = "GET";
        public string Url { get; set; } = null!;

        public string ContentType { get; set; } = "application/json";
        public string Body { get; set; } = string.Empty;

        public RequestParametres(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public RequestParametres(string name, string url, string method, string contentType, string body)
        {
            Name = name;
            Url = url;
            Method = method;
            ContentType = contentType;
            Body = body;
        }

        public override string ToString() => Name;
    }
}
