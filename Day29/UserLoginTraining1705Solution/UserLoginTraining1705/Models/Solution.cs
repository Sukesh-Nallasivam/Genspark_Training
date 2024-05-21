using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserLoginTraining1705.Models;

namespace RequestTracker.Models
{
    public class Solution
    {
        [Key]
        public int SolutionID { get; set; }
        [ForeignKey("Request")]
        public int RequestID { get; set; }
        public string SolutionDescription { get; set; } = string.Empty;
        public int SolutionBy {  get; set; }
        public DateTime SolutionGivenTime { get; set; } = DateTime.Now;
        public Request Request { get; set; }
    }
}
