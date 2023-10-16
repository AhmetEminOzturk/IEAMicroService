namespace IEAMicroservice.WebUI.Dtos.RegisterDtos.Requests
{
    public class CreateRegisterRequest
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
