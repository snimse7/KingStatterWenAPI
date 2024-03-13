namespace KingStatterWenAPI.Models
{
    public class Responses
    {
        public class SignInResponse
        {
            public bool isValidCredentidals { get; set; }
            public User user { get; set; }
            public string message { get; set; }
        }

        public class InsertDocumentResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public string? id { get; set; }
        }

        
    }
}
