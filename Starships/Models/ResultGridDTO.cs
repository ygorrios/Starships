using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Starships.Models
{
    public class GridResultDTO
    {
        public string MGLTView { get; set; }
        public string count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public virtual List<ResultDTO> resultDTO { get; set; }
    }
}