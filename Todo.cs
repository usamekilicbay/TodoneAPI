using System.ComponentModel.DataAnnotations;

namespace TodoneAPI
{
    public class Todo
    {
        [Key]
        public string Id { get; set; }
        public string Mission { get; set; }
        public MissionStatus MissionStatus { get; set; }
    }

    public enum MissionStatus
    {
        TODO,
        IN_PROCESS,
        DONE
    }
}
