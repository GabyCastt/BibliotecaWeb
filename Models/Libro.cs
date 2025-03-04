using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models;

[Table("Libro")]
public partial class Libro
{
    [Key]
    [Column("id_libro")]
    public int IdLibro { get; set; }

    [Column("titulo")]
    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("idioma")]
    [StringLength(100)]
    [Unicode(false)]
    public string Idioma { get; set; } = null!;

    [Column("año_publicacion")]
    public int? AñoPublicacion { get; set; }

    [Column("id_genero")]
    public int? IdGenero { get; set; }

    [Column("id_autor")]
    public int? IdAutor { get; set; }

    [ForeignKey("IdAutor")]
    [InverseProperty("Libros")]
    public virtual Autor? IdAutorNavigation { get; set; }

    [ForeignKey("IdGenero")]
    [InverseProperty("Libros")]
    public virtual Genero? IdGeneroNavigation { get; set; }

    [InverseProperty("IdLibroNavigation")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
