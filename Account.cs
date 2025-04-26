namespace PasswordManager;

public class Account
{
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public bool IsLocked { get; private set; }
    public List<Entry> Entries { get; private set; }

    public Account(string name, string password)
    {
        Name = name;
        PasswordSalt = Hasher.GenerateSalt();
        PasswordHash = Hasher.Hash(password + "$" + PasswordSalt);
        IsLocked = true;
        Entries = new List<Entry>();
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

    public void ChangePassword(string newPassword)
    {
        PasswordHash = Hasher.Hash(newPassword + "$" + PasswordSalt);
    }

    public void Lock()
    {
        IsLocked = true;
    }

    public void Unlock()
    {
        IsLocked = false;
    }

    public void AddEntry(Entry entry)
    {
        if (Entries.Contains(entry))
            throw new Exception("Entry already exists");
        Entries.Add(entry);
    }

    public void RemoveEntry(Entry entry)
    {
        if (!Entries.Contains(entry))
            throw new Exception("Entry not found");
        Entries.Remove(entry);
    }
}