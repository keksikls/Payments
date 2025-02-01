namespace Payments.Orders.Web.Models
{
    public class ApiErrorRespone
    {
        public required string Message { get; set; }
        public required int Code { get; set; }
        public string? Description { get; set; }
    }
}
