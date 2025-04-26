using System;

namespace PasswordManager;

public class Manager
{
    public List<Account> Accounts { get; private set; }

    public Manager()
    {
        Accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        if (Accounts.Contains(account))
            throw new Exception("Account already exists");
        Accounts.Add(account);
    }

    public void RemoveAccount(Account account)
    {
        if (!Accounts.Contains(account))
            throw new Exception("Account not found");
        Accounts.Remove(account);
    }
}