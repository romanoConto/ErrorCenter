using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.ErrorCenter.Models.DTOs
{
    public class ErrorFilterDTO
    {
        public string environment { get; set; }

        public string order { get; set; }

        public string search { get; set; }

        public string searchValue { get; set; }
    }
}
