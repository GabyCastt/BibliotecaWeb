using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models;

[Table("Genero")]
public partial class Genero
{
    [Key]
    [Column("id_genero")]
    public int IdGenero { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("edad_recomendada")]
    public int? EdadRecomendada { get; set; }

    [Column("popularidad")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Popularidad { get; set; }

    [InverseProperty("IdGeneroNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
