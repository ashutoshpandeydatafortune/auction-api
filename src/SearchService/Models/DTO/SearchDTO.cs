namespace SearchService.Models.DTO
{
    public class SearchDTO
    {
        public int PageSize { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
        public string? OrderBy {  get; set; }
        public string? FilterBy { get; set; }
        public string? SearchTerm { get; set; } = string.Empty;
    }
}
