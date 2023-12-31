﻿using DataLayer.DataLayerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReservationEF
{
    [Key]
    public int ReservationId { get; set; }

    [Required]
    public UserEF User { get; set; }

    [Required]
    public RestaurantEF Restaurant { get; set; }

    [Required]
    public int ReservationNumber { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan Time { get; set; }

    [Required]
    public int TableNumber { get; set; }

    [Required]
    public int NumberOfSeats { get; set; }
}
