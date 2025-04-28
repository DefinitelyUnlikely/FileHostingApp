namespace Backend.Exceptions;

public class MissingRequiredDataException(string message) : Exception(message);
