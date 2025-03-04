using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models;

[Table("Autor")]
public partial class Autor
{
    [Key]
    [Column("id_autor")]
    public int IdAutor { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Column("nacionalidad")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nacionalidad { get; set; }

    [InverseProperty("IdAutorNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
