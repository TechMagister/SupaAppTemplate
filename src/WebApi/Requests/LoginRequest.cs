// Copyright (c) Tech Magister

using System.ComponentModel.DataAnnotations;

namespace TechMagister.Starter.WebApi.Requests;

public class LoginRequest
{
    [Required]
    public string? Password { get; init; }
    
    [Required]
    public string? Email { get; init; }
}
