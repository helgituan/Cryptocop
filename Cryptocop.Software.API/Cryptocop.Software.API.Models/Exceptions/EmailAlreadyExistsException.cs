namespace Cryptocop.Software.API.Models.Exceptions;
using System;
public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException() : base("The email is already in use by another user") { }
    public EmailAlreadyExistsException(string message) : base(message) { }
    public EmailAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}
