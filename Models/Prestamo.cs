using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models;

[Table("Prestamo")]
public partial class Prestamo
{
    [Key]
    [Column("id_prestamo")]
    public int IdPrestamo { get; set; }

    [Column("id_libro")]
    public int? IdLibro { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("fecha_prestamo")]
    public DateOnly FechaPrestamo { get; set; }

    [Column("fecha_devolucion")]
    public DateOnly FechaDevolucion { get; set; }

    [ForeignKey("IdLibro")]
    [InverseProperty("Prestamos")]
    public virtual Libro? IdLibroNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Prestamos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
