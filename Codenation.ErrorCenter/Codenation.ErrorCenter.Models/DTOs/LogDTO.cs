namespace Codenation.ErrorCenter.Models.DTOs
{
    public class LogDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Origin { get; set; }

        public string Level { get; set; }

        public string Data { get; set; }

        public string Environment { get; set; }

        public int Frequency { get; set; }

        public string Date { get; set; }

        public bool IsArchived { get; set; }
    }
}
