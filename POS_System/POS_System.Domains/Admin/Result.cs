namespace POS_System.Domains.Admin
{
    public class Result
    {
        internal Result(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public static Result Success()
        {
            return new Result(true, "Admin created succeessfully!");
        }

        public static Result Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }
    }
}
