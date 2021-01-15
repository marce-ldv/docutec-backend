
namespace Helper.MessageStatusCode
{
    public class ProblemDetailsCustom
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }

        public static ProblemDetailsCustom GetProblemDetails(string type, string title, int? status,
                                                       string detail, string instance)
        {
            return new ProblemDetailsCustom()
            {
                Type = type,
                Title = title,
                Status = status,
                Detail = detail,
                Instance = instance
            };
        }
    }
}
