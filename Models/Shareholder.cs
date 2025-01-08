// 🔷 file: "Shareholder.cs" 🔷

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWebAPI_6.Models;

public class Shareholder
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(127)]
    public string FirstName { get; set; }

    [Required, StringLength(127)]
    public string LastName { get; set; }

    [StringLength(8)]
    public string Sex { get; set; }

    [StringLength(127)]
    public string Address { get; set; }

    [StringLength(127)]
    public string City { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Shares { get; set; }

    [Required]
    public DateTime JoinDate { get; set; }
}
