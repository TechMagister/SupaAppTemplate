// Copyright (c) Tech Magister

using System.ComponentModel.DataAnnotations;

namespace TechMagister.Starter.WebApi.Requests;

public class RegisterRequest
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
