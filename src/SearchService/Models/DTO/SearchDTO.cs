namespace SearchService.Models.DTO
{
    public class SearchDTO
    {
        public int PageSize { get; set; }
        public int PageNumber {  get; set; }    
        public string? OrderBy {  get; set; }    
        public string? FilterBy { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }
}
