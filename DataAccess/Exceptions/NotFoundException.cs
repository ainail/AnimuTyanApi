namespace DataAccess.Exceptions;

public class NotFoundException : Exception
{
    public override string Message => "Value with that Id was not found";
}