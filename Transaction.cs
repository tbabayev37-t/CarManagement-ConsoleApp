public class Transaction
{
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime Date {  get; set; }
}