using System.ComponentModel.DataAnnotations;

namespace WebService810.Models
{
    public class WebServiceUsage
    {
        [Key]
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime InvocationDate { get; set; }
        public string Content { get; set; }

    }
}
