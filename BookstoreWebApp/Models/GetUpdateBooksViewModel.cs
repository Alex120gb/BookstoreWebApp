﻿namespace BookstoreWebApp.Models
{
    public class GetUpdateBooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string Isbn { get; set; }
    }
}
