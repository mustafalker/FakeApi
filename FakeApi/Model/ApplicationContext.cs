﻿namespace FakeApi.Model
{
    public class User
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
    public class Comment
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string  email { get; set; }
        public string body { get; set; }
    }
}