namespace ApiRest.Dto.Bender.Users
{
    public class LoginRequest
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public bool Success { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; }
    }

    public class Insert
    {
        public long Identification { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }

    public class Edit
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }

    public class GetData
    {
        public long Identification { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }

}
