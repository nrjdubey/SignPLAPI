namespace SignPLAPI
{
    public class ErrorsModels
    {
        public string Title { get; set; } 
        public int Status {  get; set; }
        public List<string> Errors { get; set; }
    }
}
