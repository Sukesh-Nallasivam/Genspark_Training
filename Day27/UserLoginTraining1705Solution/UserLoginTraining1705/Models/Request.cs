using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserLoginTraining1705.Models;

namespace RequestTracker.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }  = DateTime.Now;
        public bool RequestStatus { get; set; }
        public bool SolutionAvailable { get; set; } = false;
        public User User { get; set; }
    }
}
