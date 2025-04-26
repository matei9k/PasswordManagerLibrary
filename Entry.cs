namespace PasswordManager;

public class Entry(string title, string username, string email, string password)
{
    public string Title { get; private set; } = title;
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public List<Field> Fields { get; private set; } = new();

    public void AddField(Field field)
    {
        if (Fields.Contains(field))
            throw new Exception("Field already exists");
        Fields.Add(field);
    }

    public void RemoveField(Field field)
    {
        if (!Fields.Contains(field))
            throw new Exception("Field not found");
        Fields.Add(field);
    }
}