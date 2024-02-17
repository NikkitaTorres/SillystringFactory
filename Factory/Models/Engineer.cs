using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "The engineers's description can't be empty!")]
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your enigneer to a machine. Have you created a machine yet?")]
    public int MachineId { get; set; }
    public Machine Machine { get; set; }
    public List<EngineerLicense> JoinEntities { get;}
  }
}