namespace Store.Manager.Sell.Report
{
    public class SaleReportItem
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<ProductReportItem> Products { get; set; }
    }
}
