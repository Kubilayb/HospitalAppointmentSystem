using Core.DataAccess;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public string Address { get; set; }

    public Profile Profile { get; set; }
    public Doctor Doctor { get; set; }
    public Admin Admin { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
    public ICollection<AdminAction> AdminActions { get; set; }
}